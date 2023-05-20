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
    public class StudentExamRoutinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentExamRoutinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentExamRoutines
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StudentExamRoutines.Include(s => s.Exam).Include(s => s.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudentExamRoutines/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.StudentExamRoutines == null)
            {
                return NotFound();
            }

            var studentExamRoutine = await _context.StudentExamRoutines
                .Include(s => s.Exam)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentExamRoutineId == id);
            if (studentExamRoutine == null)
            {
                return NotFound();
            }

            return View(studentExamRoutine);
        }

        // GET: StudentExamRoutines/Create
        public IActionResult Create()
        {
            ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "ExamId");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            return View();
        }

        // POST: StudentExamRoutines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentExamRoutineId,ExamId,StudentId")] StudentExamRoutine studentExamRoutine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentExamRoutine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "ExamId", studentExamRoutine.ExamId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentExamRoutine.StudentId);
            return View(studentExamRoutine);
        }

        // GET: StudentExamRoutines/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.StudentExamRoutines == null)
            {
                return NotFound();
            }

            var studentExamRoutine = await _context.StudentExamRoutines.FindAsync(id);
            if (studentExamRoutine == null)
            {
                return NotFound();
            }
            ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "ExamId", studentExamRoutine.ExamId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentExamRoutine.StudentId);
            return View(studentExamRoutine);
        }

        // POST: StudentExamRoutines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("StudentExamRoutineId,ExamId,StudentId")] StudentExamRoutine studentExamRoutine)
        {
            if (id != studentExamRoutine.StudentExamRoutineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentExamRoutine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExamRoutineExists(studentExamRoutine.StudentExamRoutineId))
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
            ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "ExamId", studentExamRoutine.ExamId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentExamRoutine.StudentId);
            return View(studentExamRoutine);
        }

        // GET: StudentExamRoutines/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.StudentExamRoutines == null)
            {
                return NotFound();
            }

            var studentExamRoutine = await _context.StudentExamRoutines
                .Include(s => s.Exam)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentExamRoutineId == id);
            if (studentExamRoutine == null)
            {
                return NotFound();
            }

            return View(studentExamRoutine);
        }

        // POST: StudentExamRoutines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.StudentExamRoutines == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StudentExamRoutines'  is null.");
            }
            var studentExamRoutine = await _context.StudentExamRoutines.FindAsync(id);
            if (studentExamRoutine != null)
            {
                _context.StudentExamRoutines.Remove(studentExamRoutine);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExamRoutineExists(long id)
        {
          return (_context.StudentExamRoutines?.Any(e => e.StudentExamRoutineId == id)).GetValueOrDefault();
        }
    }
}
