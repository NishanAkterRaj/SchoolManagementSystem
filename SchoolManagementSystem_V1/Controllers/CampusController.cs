using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem_V1.Data;
using SchoolManagementSystem_V1.Models;

namespace SchoolManagementSystem_V1.Controllers
{
    public class CampusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CampusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Campus
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Campuses.Include(c => c.Branch).Include(c => c.Shift);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Campus/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Campuses == null)
            {
                return NotFound();
            }

            var campus = await _context.Campuses
                .Include(c => c.Branch)
                .Include(c => c.Shift)
                .FirstOrDefaultAsync(m => m.CampusId == id);
            if (campus == null)
            {
                return NotFound();
            }

            return View(campus);
        }

        // GET: Campus/Create
        public IActionResult Create()
        {
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "BranchId");
            ViewData["ShiftId"] = new SelectList(_context.Shifts, "ShiftId", "ShiftId");
            return View();
        }

        // POST: Campus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CampusId,BranchId,ShiftId,CampusName,Location")] Campus campus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(campus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "BranchId", campus.BranchId);
            ViewData["ShiftId"] = new SelectList(_context.Shifts, "ShiftId", "ShiftId", campus.ShiftId);
            return View(campus);
        }

        // GET: Campus/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Campuses == null)
            {
                return NotFound();
            }

            var campus = await _context.Campuses.FindAsync(id);
            if (campus == null)
            {
                return NotFound();
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "BranchId", campus.BranchId);
            ViewData["ShiftId"] = new SelectList(_context.Shifts, "ShiftId", "ShiftId", campus.ShiftId);
            return View(campus);
        }

        // POST: Campus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("CampusId,BranchId,ShiftId,CampusName,Location")] Campus campus)
        {
            if (id != campus.CampusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampusExists(campus.CampusId))
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
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "BranchId", campus.BranchId);
            ViewData["ShiftId"] = new SelectList(_context.Shifts, "ShiftId", "ShiftId", campus.ShiftId);
            return View(campus);
        }

        // GET: Campus/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Campuses == null)
            {
                return NotFound();
            }

            var campus = await _context.Campuses
                .Include(c => c.Branch)
                .Include(c => c.Shift)
                .FirstOrDefaultAsync(m => m.CampusId == id);
            if (campus == null)
            {
                return NotFound();
            }

            return View(campus);
        }

        // POST: Campus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Campuses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Campuses'  is null.");
            }
            var campus = await _context.Campuses.FindAsync(id);
            if (campus != null)
            {
                _context.Campuses.Remove(campus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampusExists(long id)
        {
          return (_context.Campuses?.Any(e => e.CampusId == id)).GetValueOrDefault();
        }
    }
}
