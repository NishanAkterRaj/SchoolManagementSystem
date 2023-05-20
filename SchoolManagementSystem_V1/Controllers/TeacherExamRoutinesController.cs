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
    public class TeacherExamRoutinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherExamRoutinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TeacherExamRoutines
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TeacherExamRoutines.Include(t => t.Exam).Include(t => t.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TeacherExamRoutines/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.TeacherExamRoutines == null)
            {
                return NotFound();
            }

            var teacherExamRoutine = await _context.TeacherExamRoutines
                .Include(t => t.Exam)
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.TeacherExamRoutineId == id);
            if (teacherExamRoutine == null)
            {
                return NotFound();
            }

            return View(teacherExamRoutine);
        }

        // GET: TeacherExamRoutines/Create
        public IActionResult Create()
        {
            ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "ExamId");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId");
            return View();
        }

        // POST: TeacherExamRoutines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherExamRoutineId,ExamId,TeacherId")] TeacherExamRoutine teacherExamRoutine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacherExamRoutine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "ExamId", teacherExamRoutine.ExamId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", teacherExamRoutine.TeacherId);
            return View(teacherExamRoutine);
        }

        // GET: TeacherExamRoutines/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.TeacherExamRoutines == null)
            {
                return NotFound();
            }

            var teacherExamRoutine = await _context.TeacherExamRoutines.FindAsync(id);
            if (teacherExamRoutine == null)
            {
                return NotFound();
            }
            ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "ExamId", teacherExamRoutine.ExamId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", teacherExamRoutine.TeacherId);
            return View(teacherExamRoutine);
        }

        // POST: TeacherExamRoutines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("TeacherExamRoutineId,ExamId,TeacherId")] TeacherExamRoutine teacherExamRoutine)
        {
            if (id != teacherExamRoutine.TeacherExamRoutineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherExamRoutine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExamRoutineExists(teacherExamRoutine.TeacherExamRoutineId))
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
            ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "ExamId", teacherExamRoutine.ExamId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", teacherExamRoutine.TeacherId);
            return View(teacherExamRoutine);
        }

        // GET: TeacherExamRoutines/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.TeacherExamRoutines == null)
            {
                return NotFound();
            }

            var teacherExamRoutine = await _context.TeacherExamRoutines
                .Include(t => t.Exam)
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.TeacherExamRoutineId == id);
            if (teacherExamRoutine == null)
            {
                return NotFound();
            }

            return View(teacherExamRoutine);
        }

        // POST: TeacherExamRoutines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.TeacherExamRoutines == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TeacherExamRoutines'  is null.");
            }
            var teacherExamRoutine = await _context.TeacherExamRoutines.FindAsync(id);
            if (teacherExamRoutine != null)
            {
                _context.TeacherExamRoutines.Remove(teacherExamRoutine);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExamRoutineExists(long id)
        {
          return (_context.TeacherExamRoutines?.Any(e => e.TeacherExamRoutineId == id)).GetValueOrDefault();
        }
    }
}
