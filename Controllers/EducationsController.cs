﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cv.Data;
using Cv.Models;

namespace Cv.Controllers
{
    public class EducationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EducationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Educations
        public async Task<IActionResult> Index()
        {
              return _context.Education != null ? 
                          View(await _context.Education.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Education'  is null.");
        }

        // GET: Educations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Education == null)
            {
                return NotFound();
            }

            var education = await _context.Education
                .FirstOrDefaultAsync(m => m.Id == id);
            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        // GET: Educations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Educations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Degree,SchoolName,SchoolSection,GNO,City,Country,StartTime,EndTime,Description")] Education education)
        {
            if (ModelState.IsValid)
            {
                _context.Add(education);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(education);
        }

        // GET: Educations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Education == null)
            {
                return NotFound();
            }

            var education = await _context.Education.FindAsync(id);
            if (education == null)
            {
                return NotFound();
            }
            return View(education);
        }

        // POST: Educations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Degree,SchoolName,SchoolSection,GNO,City,Country,StartTime,EndTime,Description")] Education education)
        {
            if (id != education.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(education);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationExists(education.Id))
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
            return View(education);
        }

        // GET: Educations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Education == null)
            {
                return NotFound();
            }

            var education = await _context.Education
                .FirstOrDefaultAsync(m => m.Id == id);
            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        // POST: Educations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Education == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Education'  is null.");
            }
            var education = await _context.Education.FindAsync(id);
            if (education != null)
            {
                _context.Education.Remove(education);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EducationExists(int id)
        {
          return (_context.Education?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
