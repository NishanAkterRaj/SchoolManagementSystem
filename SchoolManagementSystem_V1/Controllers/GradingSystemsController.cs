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
    public class GradingSystemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GradingSystemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GradingSystems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GradingSystems.Include(g => g.Class);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GradingSystems/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.GradingSystems == null)
            {
                return NotFound();
            }

            var gradingSystem = await _context.GradingSystems
                .Include(g => g.Class)
                .FirstOrDefaultAsync(m => m.GradeId == id);
            if (gradingSystem == null)
            {
                return NotFound();
            }

            return View(gradingSystem);
        }

        // GET: GradingSystems/Create
        public IActionResult Create()
        {
            ViewData["Classid"] = new SelectList(_context.Classes, "ClassId", "ClassId");
            return View();
        }

        // POST: GradingSystems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GradeId,Classid,GradeName,MaxMarks,MinimumMarks")] GradingSystem gradingSystem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gradingSystem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Classid"] = new SelectList(_context.Classes, "ClassId", "ClassId", gradingSystem.Classid);
            return View(gradingSystem);
        }

        // GET: GradingSystems/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.GradingSystems == null)
            {
                return NotFound();
            }

            var gradingSystem = await _context.GradingSystems.FindAsync(id);
            if (gradingSystem == null)
            {
                return NotFound();
            }
            ViewData["Classid"] = new SelectList(_context.Classes, "ClassId", "ClassId", gradingSystem.Classid);
            return View(gradingSystem);
        }

        // POST: GradingSystems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("GradeId,Classid,GradeName,MaxMarks,MinimumMarks")] GradingSystem gradingSystem)
        {
            if (id != gradingSystem.GradeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gradingSystem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradingSystemExists(gradingSystem.GradeId))
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
            ViewData["Classid"] = new SelectList(_context.Classes, "ClassId", "ClassId", gradingSystem.Classid);
            return View(gradingSystem);
        }

        // GET: GradingSystems/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.GradingSystems == null)
            {
                return NotFound();
            }

            var gradingSystem = await _context.GradingSystems
                .Include(g => g.Class)
                .FirstOrDefaultAsync(m => m.GradeId == id);
            if (gradingSystem == null)
            {
                return NotFound();
            }

            return View(gradingSystem);
        }

        // POST: GradingSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.GradingSystems == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GradingSystems'  is null.");
            }
            var gradingSystem = await _context.GradingSystems.FindAsync(id);
            if (gradingSystem != null)
            {
                _context.GradingSystems.Remove(gradingSystem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GradingSystemExists(long id)
        {
          return (_context.GradingSystems?.Any(e => e.GradeId == id)).GetValueOrDefault();
        }
    }
}
