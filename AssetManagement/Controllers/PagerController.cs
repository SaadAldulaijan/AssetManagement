using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssetManagement.Data;
using AssetManagement.Models;


//TODO:  Handle Pager assignment with employee - update - delete

namespace AssetManagement.Controllers
{
    public class PagerController : Controller
    {
        private readonly DataContext _context;

        public PagerController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Pager.Include(p => p.Employee);
            return View(await dataContext.ToListAsync());
        }

        public async Task<IActionResult> Details(string serialNo)
        {
            if (serialNo == null)
            {
                return NotFound();
            }

            var pager = await _context.Pager
                .Include(p => p.Employee)
                .FirstOrDefaultAsync(m => m.SerialNo == serialNo);
            if (pager == null)
            {
                return NotFound();
            }

            return View(pager);
        }

        public IActionResult Create()
        {
            ViewData["BadgeNo"] = new SelectList(_context.Employee, "BadgeNo", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Number,Capcode,BadgeNo,Comment,Cust,RateCode,SerialNo,Status,MailCode,Facility")] Pager pager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BadgeNo"] = new SelectList(_context.Employee, "BadgeNo", "Name", pager.EmployeeBadgeNo);
            return View(pager);
        }

        public async Task<IActionResult> Edit(string serialNo)
        {
            if (serialNo == null)
            {
                return NotFound();
            }

            var pager = await _context.Pager.FindAsync(serialNo);
            if (pager == null)
            {
                return NotFound();
            }
            ViewData["BadgeNo"] = new SelectList(_context.Employee, "BadgeNo", "Name", pager.EmployeeBadgeNo);
            return View(pager);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string serialNo, [Bind("Number,Capcode,BadgeNo,Comment,Cust,RateCode,SerialNo,Status,MailCode,Facility")] Pager pager)
        {
            if (serialNo != pager.SerialNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagerExists(pager.SerialNo))
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
            ViewData["BadgeNo"] = new SelectList(_context.Employee, "BadgeNo", "Name", pager.EmployeeBadgeNo);
            return View(pager);
        }

        public async Task<IActionResult> Delete(string serialNo)
        {
            if (serialNo == null)
            {
                return NotFound();
            }

            var pager = await _context.Pager
                .Include(p => p.Employee)
                .FirstOrDefaultAsync(m => m.SerialNo == serialNo);
            if (pager == null)
            {
                return NotFound();
            }

            return View(pager);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string serialNo)
        {
            var pager = await _context.Pager.FindAsync(serialNo);
            _context.Pager.Remove(pager);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagerExists(string serialNo)
        {
            return _context.Pager.Any(e => e.SerialNo == serialNo);
        }
    }
}
