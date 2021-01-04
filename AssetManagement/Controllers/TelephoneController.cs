using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssetManagement.Data;
using AssetManagement.Models;

namespace AssetManagement.Controllers
{
    public class TelephoneController : Controller
    {
        private readonly DataContext _context;

        public TelephoneController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Telephone.Include(t => t.SubCategory);
            return View(await dataContext.ToListAsync());
        }

        public async Task<IActionResult> Details(string serialNo)
        {
            if (serialNo == null)
            {
                return NotFound();
            }

            var telephone = await _context.Telephone
                .Include(t => t.SubCategory)
                .ThenInclude(c => c.Category)
                .FirstOrDefaultAsync(m => m.SerialNo == serialNo);
            if (telephone == null)
            {
                return NotFound();
            }

            return View(telephone);
        }

        public IActionResult Create()
        {
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategory, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MAC,SerialNo,Tag,Status,Remark,SubCategoryId")] Telephone telephone)
        {
            if (ModelState.IsValid)
            {
                if (!TelephoneExists(telephone.SerialNo))
                {
                    _context.Add(telephone);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Telephone Already Exists");
                }
            }
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategory, "Id", "Name", telephone.SubCategoryId);
            return View(telephone);
        }

        public async Task<IActionResult> Edit(string serialNo)
        {
            if (serialNo == null)
            {
                return NotFound();
            }

            var telephone = await _context.Telephone.FindAsync(serialNo);
            if (telephone == null)
            {
                return NotFound();
            }
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategory, "Id", "Name", telephone.SubCategoryId);
            return View(telephone);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string serialNo, [Bind("MAC,SerialNo,Tag,Status,Remark,SubCategoryId")] Telephone telephone)
        {
            if (serialNo != telephone.SerialNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //TODO: if telephone status updated to faulty, telephone should be deleted from asset.
                    _context.Update(telephone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelephoneExists(telephone.SerialNo))
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
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategory, "Id", "Name", telephone.SubCategoryId);
            return View(telephone);
        }

        public async Task<IActionResult> Delete(string serialNo)
        {
            if (serialNo == null)
            {
                return NotFound();
            }

            var telephone = await _context.Telephone
                .Include(t => t.SubCategory)
                .FirstOrDefaultAsync(m => m.SerialNo == serialNo);
            if (telephone == null)
            {
                return NotFound();
            }

            return View(telephone);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string serialNo)
        {
            var telephone = await _context.Telephone.FindAsync(serialNo);
            _context.Telephone.Remove(telephone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelephoneExists(string serialNo)
        {
            return _context.Telephone.Any(e => e.SerialNo == serialNo);
        }
    }
}
