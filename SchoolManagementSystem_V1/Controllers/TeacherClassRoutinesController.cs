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
    public class TeacherClassRoutinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherClassRoutinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TeacherClassRoutines
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TeacherClassRoutines.Include(t => t.ClassRoutine).Include(t => t.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TeacherClassRoutines/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.TeacherClassRoutines == null)
            {
                return NotFound();
            }

            var teacherClassRoutine = await _context.TeacherClassRoutines
                .Include(t => t.ClassRoutine)
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.TeacherClassRoutineId == id);
            if (teacherClassRoutine == null)
            {
                return NotFound();
            }

            return View(teacherClassRoutine);
        }

        // GET: TeacherClassRoutines/Create
        public IActionResult Create()
        {
            ViewData["ClassRoutineId"] = new SelectList(_context.ClassRoutines, "ClassRoutineId", "ClassRoutineId");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId");
            return View();
        }

        // POST: TeacherClassRoutines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherClassRoutineId,ClassRoutineId,TeacherId")] TeacherClassRoutine teacherClassRoutine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacherClassRoutine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassRoutineId"] = new SelectList(_context.ClassRoutines, "ClassRoutineId", "ClassRoutineId", teacherClassRoutine.ClassRoutineId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", teacherClassRoutine.TeacherId);
            return View(teacherClassRoutine);
        }

        // GET: TeacherClassRoutines/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.TeacherClassRoutines == null)
            {
                return NotFound();
            }

            var teacherClassRoutine = await _context.TeacherClassRoutines.FindAsync(id);
            if (teacherClassRoutine == null)
            {
                return NotFound();
            }
            ViewData["ClassRoutineId"] = new SelectList(_context.ClassRoutines, "ClassRoutineId", "ClassRoutineId", teacherClassRoutine.ClassRoutineId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", teacherClassRoutine.TeacherId);
            return View(teacherClassRoutine);
        }

        // POST: TeacherClassRoutines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("TeacherClassRoutineId,ClassRoutineId,TeacherId")] TeacherClassRoutine teacherClassRoutine)
        {
            if (id != teacherClassRoutine.TeacherClassRoutineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherClassRoutine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherClassRoutineExists(teacherClassRoutine.TeacherClassRoutineId))
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
            ViewData["ClassRoutineId"] = new SelectList(_context.ClassRoutines, "ClassRoutineId", "ClassRoutineId", teacherClassRoutine.ClassRoutineId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", teacherClassRoutine.TeacherId);
            return View(teacherClassRoutine);
        }

        // GET: TeacherClassRoutines/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.TeacherClassRoutines == null)
            {
                return NotFound();
            }

            var teacherClassRoutine = await _context.TeacherClassRoutines
                .Include(t => t.ClassRoutine)
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.TeacherClassRoutineId == id);
            if (teacherClassRoutine == null)
            {
                return NotFound();
            }

            return View(teacherClassRoutine);
        }

        // POST: TeacherClassRoutines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.TeacherClassRoutines == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TeacherClassRoutines'  is null.");
            }
            var teacherClassRoutine = await _context.TeacherClassRoutines.FindAsync(id);
            if (teacherClassRoutine != null)
            {
                _context.TeacherClassRoutines.Remove(teacherClassRoutine);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherClassRoutineExists(long id)
        {
          return (_context.TeacherClassRoutines?.Any(e => e.TeacherClassRoutineId == id)).GetValueOrDefault();
        }
    }
}
