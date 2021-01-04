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
    // TODO: Remove the creation , deletion, and limits the update of extension
    public class ExtensionController : Controller
    {
        private readonly DataContext _context;

        public ExtensionController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Extension.Include(e => e.Employee);
            return View(await dataContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? number)
        {
            if (number == null)
            {
                return NotFound();
            }

            var extension = await _context.Extension
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.Number == number);
            if (extension == null)
            {
                return NotFound();
            }

            return View(extension);
        }

        public IActionResult Create()
        {
            ViewData["BadgeNo"] = new SelectList(_context.Employee, "BadgeNo", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Number,Usage,BadgeNo")] Extension extension)
        {
            if (ModelState.IsValid)
            {
                if (!ExtensionExists(extension.Number))
                {
                    _context.Add(extension);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Extension Already Exists");
                }
            }
            ViewData["BadgeNo"] = new SelectList(_context.Employee, "BadgeNo", "Name", extension.EmployeeBadgeNo);
            return View(extension);
        }

        public async Task<IActionResult> Edit(int? number)
        {
            if (number == null)
            {
                return NotFound();
            }

            var extension = await _context.Extension.FindAsync(number);
            if (extension == null)
            {
                return NotFound();
            }
            ViewData["BadgeNo"] = new SelectList(_context.Employee, "BadgeNo", "Name", extension.EmployeeBadgeNo);
            return View(extension);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int number, [Bind("Number,Usage,BadgeNo")] Extension extension)
        {
            if (number != extension.Number)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(extension);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExtensionExists(extension.Number))
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
            ViewData["BadgeNo"] = new SelectList(_context.Employee, "BadgeNo", "Name", extension.EmployeeBadgeNo);
            return View(extension);
        }

        public async Task<IActionResult> Delete(int? number)
        {
            if (number == null)
            {
                return NotFound();
            }

            var extension = await _context.Extension
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.Number == number);
            if (extension == null)
            {
                return NotFound();
            }

            return View(extension);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int number)
        {
            var extension = await _context.Extension.FindAsync(number);
            _context.Extension.Remove(extension);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExtensionExists(int number)
        {
            return _context.Extension.Any(e => e.Number == number);
        }
    }
}