using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenHoangViet0689.Models;

namespace NguyenHoangViet0689.Controllers
{
    public class NHVstudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NHVstudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NHVstudent
        public async Task<IActionResult> Index()
        {
              return _context.NHVstudent != null ? 
                          View(await _context.NHVstudent.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.NHVstudent'  is null.");
        }

        // GET: NHVstudent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NHVstudent == null)
            {
                return NotFound();
            }

            var nHVstudent = await _context.NHVstudent
                .FirstOrDefaultAsync(m => m.NHVMaSV == id);
            if (nHVstudent == null)
            {
                return NotFound();
            }

            return View(nHVstudent);
        }

        // GET: NHVstudent/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NHVstudent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NHVMaSV,NHVTenSV,NHVsdt")] NHVstudent nHVstudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nHVstudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nHVstudent);
        }

        // GET: NHVstudent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NHVstudent == null)
            {
                return NotFound();
            }

            var nHVstudent = await _context.NHVstudent.FindAsync(id);
            if (nHVstudent == null)
            {
                return NotFound();
            }
            return View(nHVstudent);
        }

        // POST: NHVstudent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NHVMaSV,NHVTenSV,NHVsdt")] NHVstudent nHVstudent)
        {
            if (id != nHVstudent.NHVMaSV)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nHVstudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NHVstudentExists(nHVstudent.NHVMaSV))
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
            return View(nHVstudent);
        }

        // GET: NHVstudent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NHVstudent == null)
            {
                return NotFound();
            }

            var nHVstudent = await _context.NHVstudent
                .FirstOrDefaultAsync(m => m.NHVMaSV == id);
            if (nHVstudent == null)
            {
                return NotFound();
            }

            return View(nHVstudent);
        }

        // POST: NHVstudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NHVstudent == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NHVstudent'  is null.");
            }
            var nHVstudent = await _context.NHVstudent.FindAsync(id);
            if (nHVstudent != null)
            {
                _context.NHVstudent.Remove(nHVstudent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NHVstudentExists(int id)
        {
          return (_context.NHVstudent?.Any(e => e.NHVMaSV == id)).GetValueOrDefault();
        }
    }
}
