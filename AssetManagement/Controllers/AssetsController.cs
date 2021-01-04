using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssetManagement.Data;
using AssetManagement.Models;
using Microsoft.EntityFrameworkCore.Query;
using AssetManagement.ViewModels;
using static AssetManagement.Models.Extension;
using AssetManagement.Models.Abstraction.Enums;

namespace AssetManagement.Controllers
{
    public class AssetsController : Controller
    {
        private readonly DataContext _context;

        public AssetsController(DataContext context)
        {
            _context = context;
        }

        private async Task<List<AssetViewModel>> GetAssetsAsync()
        {
            var data = await _context.Asset
               .Include(x => x.Extension)
                   .ThenInclude(x => x.Employee)
                       .ThenInclude(x => x.Department)
               .Include(x => x.Telephone)
                   .ThenInclude(x => x.SubCategory)
                       .ThenInclude(x => x.Category)
               .Select(x => new AssetViewModel
               {
                   TelephoneId = x.TelephoneSerialNo,
                   ExtensionId = x.ExtensionNumber,
                   Employee = x.Extension.Employee.Name,
                   BadgeNo = x.Extension.Employee.BadgeNo,
                   SerialNo = x.Telephone.SerialNo,
                   MAC = x.Telephone.MAC,
                   Model = x.Telephone.SubCategory.Name,
                   Brand = x.Telephone.SubCategory.Category.Name,
                   Extension = x.Extension.Number,
                   Department = x.Extension.Employee.Department.Name
               })
               .AsNoTracking()
               .ToListAsync();
            return data;
        }
        public async Task<IActionResult> Index() => View(await GetAssetsAsync());

        public async Task<IActionResult> Details(string serialNo, int? number)
        {
            if (serialNo == null || number == null)
            {
                return NotFound();
            }

            var asset = await _context.Asset
                .Include(a => a.Extension)
                    .ThenInclude(a => a.Employee)
                        .ThenInclude(a => a.Department)
                .Include(a => a.Telephone)
                    .ThenInclude(a => a.SubCategory)
                        .ThenInclude(a => a.Category)
                .FirstOrDefaultAsync(m => m.TelephoneSerialNo == serialNo && m.ExtensionNumber == number);
            if (asset == null)
            {
                return NotFound();
            }

            return View(asset);
        }

        public IActionResult Create()
        {
            var extension = _context.Extension.Where(x => x.Usage == ExtensionUsage.EndUser);
            var telephone = _context.Telephone.Where(x => x.Status == Status.Stock);
            ViewData["Number"] = new SelectList(extension, "Number", "Number");
            ViewData["SerialNo"] = new SelectList(telephone, "SerialNo", "SerialNo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TelephoneSerialNo,ExtensionNumber")] Asset asset)
        {
            if (ModelState.IsValid)
            {
                // 1. Remove telephone from stock, update telephone status to used;
                var telephone = _context.Telephone.FirstOrDefault(x => x.SerialNo == asset.TelephoneSerialNo);
                telephone.Status = Status.Used;
                _context.Update(telephone);
                await _context.SaveChangesAsync();
                // 2. Add asset
                _context.Add(asset);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Number"] = new SelectList(_context.Extension, "Id", "Number", asset.ExtensionNumber);
            ViewData["SerialNo"] = new SelectList(_context.Telephone, "Id", "SerialNo", asset.TelephoneSerialNo);
            return View(asset);
        }

        public async Task<IActionResult> Edit(string serialNo, int? number)
        {
            if (serialNo == null || number == null)
            {
                return NotFound();
            }

            var asset = await _context.Asset
                .Where(x => x.TelephoneSerialNo == serialNo && x.ExtensionNumber == number)
                .FirstOrDefaultAsync();
            if (asset == null)
            {
                return NotFound();
            }
            ViewData["Number"] = new SelectList(_context.Extension, "Id", "Number", asset.ExtensionNumber);
            ViewData["SerialNo"] = new SelectList(_context.Telephone, "Id", "SerialNo", asset.TelephoneSerialNo);
            return View(asset);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string serialNo, int number, [Bind("TelephoneSerialNo,ExtensionNumber")] Asset asset)
        {
            if (serialNo != asset.TelephoneSerialNo || number != asset.ExtensionNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // problem here - handle extension usage. 
                    _context.Update(asset);
                    await _context.SaveChangesAsync();
                    var extension = UpdateExtensionStatus(asset);
                    _context.Update(extension);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetExists(asset.TelephoneSerialNo, asset.ExtensionNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Number"] = new SelectList(_context.Extension, "Id", "Number", asset.ExtensionNumber);
            ViewData["SerialNo"] = new SelectList(_context.Telephone, "Id", "SerialNo", asset.TelephoneSerialNo);
            return View(asset);
        }

        public async Task<IActionResult> Delete(string serialNo, int? number)
        {
            if (serialNo == null || number == null)
            {
                return NotFound();
            }

            var asset = await _context.Asset
                .Include(a => a.Extension)
                .Include(a => a.Telephone)
                .FirstOrDefaultAsync(m => m.TelephoneSerialNo == serialNo && m.ExtensionNumber == number);
            if (asset == null)
            {
                return NotFound();
            }

            return View(asset);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string serialNo, int number)
        {
            // 1. Change extension status to Available
            var extension = UpdateExtensionOnDelete(number);
            _context.Update(extension);
            await _context.SaveChangesAsync();
            // 2. Add telephone back to stock.
            var telephone = AddTelephoneToStock(serialNo);
            _context.Update(serialNo);
            await _context.SaveChangesAsync();
            // 3. Remove asset
            var asset = _context.Asset
                .Where(x => x.TelephoneSerialNo == serialNo && x.ExtensionNumber == number)
                .FirstOrDefault();
            _context.Asset.Remove(asset);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetExists(string serialNo, int number)
        {
            return _context.Asset.Any(e => e.TelephoneSerialNo == serialNo && e.ExtensionNumber == number);
        }
        private Extension UpdateExtensionStatus(Asset asset)
        {
            var extension = _context.Extension.Find(asset.ExtensionNumber);
            extension.Usage = ExtensionUsage.EndUser;
            return extension;
        }

        private Extension UpdateExtensionOnDelete(int number)
        {
            var extension = _context.Extension.Find(number);
            extension.Usage = ExtensionUsage.Available;
            return extension;
        }

        private Telephone AddTelephoneToStock(string serialNo)
        {
            var telephone = _context.Telephone.Find(serialNo);
            telephone.Status = Status.Stock;
            return telephone;
        }

    }
}
