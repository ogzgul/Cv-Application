using System;
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
    public class ReferencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReferencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: References
        public async Task<IActionResult> Index()
        {
              return _context.Reference != null ? 
                          View(await _context.Reference.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Reference'  is null.");
        }

        // GET: References/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reference == null)
            {
                return NotFound();
            }

            var reference = await _context.Reference
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reference == null)
            {
                return NotFound();
            }

            return View(reference);
        }

        // GET: References/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: References/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SurName,JobTitle,Organisation,Email,PhoneNumber")] Reference reference)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reference);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reference);
        }

        // GET: References/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reference == null)
            {
                return NotFound();
            }

            var reference = await _context.Reference.FindAsync(id);
            if (reference == null)
            {
                return NotFound();
            }
            return View(reference);
        }

        // POST: References/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SurName,JobTitle,Organisation,Email,PhoneNumber")] Reference reference)
        {
            if (id != reference.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reference);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferenceExists(reference.Id))
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
            return View(reference);
        }

        // GET: References/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reference == null)
            {
                return NotFound();
            }

            var reference = await _context.Reference
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reference == null)
            {
                return NotFound();
            }

            return View(reference);
        }

        // POST: References/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reference == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Reference'  is null.");
            }
            var reference = await _context.Reference.FindAsync(id);
            if (reference != null)
            {
                _context.Reference.Remove(reference);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReferenceExists(int id)
        {
          return (_context.Reference?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
