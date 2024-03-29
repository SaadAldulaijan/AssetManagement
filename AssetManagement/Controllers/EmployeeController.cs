﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssetManagement.Data;
using AssetManagement.Models;
using AssetManagement.ViewModels;

namespace AssetManagement.Controllers
{
    // this should be employee including department
    public class EmployeeController : Controller
    {
        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Employee.Include(e => e.Department);
            return View(await dataContext.ToListAsync());
        }

        private async Task<EmployeeAssetViewModel> GetEmployeeAsset(int? badgeNo) =>
            await _context.Employee.Where(x=>x.BadgeNo == badgeNo)
                .Include(x => x.Extensions)
                    .ThenInclude(x=>x.Assets)
                        .ThenInclude(x=>x.Telephone)
                .Include(x => x.Pagers)
                .Include(x => x.OtherAssets)
                .Select(x => new EmployeeAssetViewModel
                {
                    Id = x.BadgeNo,
                    Name = x.Name,
                    BadgeNo = x.BadgeNo,
                    Email = x.Email,
                    Department = x.Department.Name,
                    Extensions = x.Extensions.ToList(),
                    Telephones = null,
                    Pagers = x.Pagers.ToList(),
                    OtherAssets = x.OtherAssets.ToList()
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

        public async Task<IActionResult> Details(int? badgeNo)
        {
            if (badgeNo == null)
            {
                return NotFound();
            }

            var employee = await GetEmployeeAsset(badgeNo);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BadgeNo,Name,Email,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (!EmployeeExists(employee.BadgeNo))
                {
                    _context.Add(employee);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee Already Exists");
                }
                
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        public async Task<IActionResult> Edit(int? badgeNo)
        {
            if (badgeNo == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(badgeNo);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int badgeNo, [Bind("BadgeNo,Name,Email,DepartmentId")] Employee employee)
        {
            if (badgeNo != employee.BadgeNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.BadgeNo))
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
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        public async Task<IActionResult> Delete(int? badgeNo)
        {
            if (badgeNo == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Department)
                .FirstOrDefaultAsync(m => m.BadgeNo == badgeNo);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int badgeNo)
        {
            var employee = await _context.Employee.FindAsync(badgeNo);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int badgeNo)
        {
            return _context.Employee.Any(e => e.BadgeNo == badgeNo);
        }
    }
}
