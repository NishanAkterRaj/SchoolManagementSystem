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
    public class TeacherPortalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherPortalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TeacherPortals
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TeacherPortals.Include(t => t.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TeacherPortals/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.TeacherPortals == null)
            {
                return NotFound();
            }

            var teacherPortal = await _context.TeacherPortals
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.TeacherPortalId == id);
            if (teacherPortal == null)
            {
                return NotFound();
            }

            return View(teacherPortal);
        }

        // GET: TeacherPortals/Create
        public IActionResult Create()
        {
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId");
            return View();
        }

        // POST: TeacherPortals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherPortalId,TeacherId,UserName,Password")] TeacherPortal teacherPortal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacherPortal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", teacherPortal.TeacherId);
            return View(teacherPortal);
        }

        // GET: TeacherPortals/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.TeacherPortals == null)
            {
                return NotFound();
            }

            var teacherPortal = await _context.TeacherPortals.FindAsync(id);
            if (teacherPortal == null)
            {
                return NotFound();
            }
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", teacherPortal.TeacherId);
            return View(teacherPortal);
        }

        // POST: TeacherPortals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("TeacherPortalId,TeacherId,UserName,Password")] TeacherPortal teacherPortal)
        {
            if (id != teacherPortal.TeacherPortalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherPortal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherPortalExists(teacherPortal.TeacherPortalId))
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
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", teacherPortal.TeacherId);
            return View(teacherPortal);
        }

        // GET: TeacherPortals/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.TeacherPortals == null)
            {
                return NotFound();
            }

            var teacherPortal = await _context.TeacherPortals
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.TeacherPortalId == id);
            if (teacherPortal == null)
            {
                return NotFound();
            }

            return View(teacherPortal);
        }

        // POST: TeacherPortals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.TeacherPortals == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TeacherPortals'  is null.");
            }
            var teacherPortal = await _context.TeacherPortals.FindAsync(id);
            if (teacherPortal != null)
            {
                _context.TeacherPortals.Remove(teacherPortal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherPortalExists(long id)
        {
          return (_context.TeacherPortals?.Any(e => e.TeacherPortalId == id)).GetValueOrDefault();
        }
    }
}
