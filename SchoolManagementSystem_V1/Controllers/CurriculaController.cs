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
    public class CurriculaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CurriculaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Curricula
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Curricula.Include(c => c.Campus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Curricula/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Curricula == null)
            {
                return NotFound();
            }

            var curriculum = await _context.Curricula
                .Include(c => c.Campus)
                .FirstOrDefaultAsync(m => m.CurriculumId == id);
            if (curriculum == null)
            {
                return NotFound();
            }

            return View(curriculum);
        }

        // GET: Curricula/Create
        public IActionResult Create()
        {
            ViewData["CampusId"] = new SelectList(_context.Campuses, "CampusId", "CampusId");
            return View();
        }

        // POST: Curricula/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CurriculumId,CampusId,CurriculumName")] Curriculum curriculum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curriculum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CampusId"] = new SelectList(_context.Campuses, "CampusId", "CampusId", curriculum.CampusId);
            return View(curriculum);
        }

        // GET: Curricula/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Curricula == null)
            {
                return NotFound();
            }

            var curriculum = await _context.Curricula.FindAsync(id);
            if (curriculum == null)
            {
                return NotFound();
            }
            ViewData["CampusId"] = new SelectList(_context.Campuses, "CampusId", "CampusId", curriculum.CampusId);
            return View(curriculum);
        }

        // POST: Curricula/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("CurriculumId,CampusId,CurriculumName")] Curriculum curriculum)
        {
            if (id != curriculum.CurriculumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curriculum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurriculumExists(curriculum.CurriculumId))
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
            ViewData["CampusId"] = new SelectList(_context.Campuses, "CampusId", "CampusId", curriculum.CampusId);
            return View(curriculum);
        }

        // GET: Curricula/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Curricula == null)
            {
                return NotFound();
            }

            var curriculum = await _context.Curricula
                .Include(c => c.Campus)
                .FirstOrDefaultAsync(m => m.CurriculumId == id);
            if (curriculum == null)
            {
                return NotFound();
            }

            return View(curriculum);
        }

        // POST: Curricula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Curricula == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Curricula'  is null.");
            }
            var curriculum = await _context.Curricula.FindAsync(id);
            if (curriculum != null)
            {
                _context.Curricula.Remove(curriculum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurriculumExists(long id)
        {
          return (_context.Curricula?.Any(e => e.CurriculumId == id)).GetValueOrDefault();
        }
    }
}
