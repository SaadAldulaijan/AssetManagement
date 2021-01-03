using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssetManagement.Data;
using AssetManagement.Models;


// Handle Pager assignment with employee - update - delete
// When employee id is null, InStock is true
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

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pager = await _context.Pager
                .Include(p => p.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pager == null)
            {
                return NotFound();
            }

            return View(pager);
        }

        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Capcode,EmployeeId,Comment,Cust,RateCode,SerialNo,Status,MailCode,Facility")] Pager pager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Name", pager.EmployeeId);
            return View(pager);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pager = await _context.Pager.FindAsync(id);
            if (pager == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Name", pager.EmployeeId);
            return View(pager);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Capcode,EmployeeId,Comment,Cust,RateCode,SerialNo,Status,MailCode,Facility")] Pager pager)
        {
            if (id != pager.Id)
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
                    if (!PagerExists(pager.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Name", pager.EmployeeId);
            return View(pager);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pager = await _context.Pager
                .Include(p => p.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pager == null)
            {
                return NotFound();
            }

            return View(pager);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pager = await _context.Pager.FindAsync(id);
            _context.Pager.Remove(pager);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagerExists(int id)
        {
            return _context.Pager.Any(e => e.Id == id);
        }
    }
}
