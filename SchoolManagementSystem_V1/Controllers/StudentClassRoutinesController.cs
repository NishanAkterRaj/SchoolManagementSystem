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
    public class StudentClassRoutinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentClassRoutinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentClassRoutines
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StudentClassRoutines.Include(s => s.ClassRoutine).Include(s => s.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudentClassRoutines/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.StudentClassRoutines == null)
            {
                return NotFound();
            }

            var studentClassRoutine = await _context.StudentClassRoutines
                .Include(s => s.ClassRoutine)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentClassRoutineId == id);
            if (studentClassRoutine == null)
            {
                return NotFound();
            }

            return View(studentClassRoutine);
        }

        // GET: StudentClassRoutines/Create
        public IActionResult Create()
        {
            ViewData["ClassRoutineId"] = new SelectList(_context.ClassRoutines, "ClassRoutineId", "ClassRoutineId");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            return View();
        }

        // POST: StudentClassRoutines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentClassRoutineId,ClassRoutineId,StudentId")] StudentClassRoutine studentClassRoutine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentClassRoutine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassRoutineId"] = new SelectList(_context.ClassRoutines, "ClassRoutineId", "ClassRoutineId", studentClassRoutine.ClassRoutineId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentClassRoutine.StudentId);
            return View(studentClassRoutine);
        }

        // GET: StudentClassRoutines/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.StudentClassRoutines == null)
            {
                return NotFound();
            }

            var studentClassRoutine = await _context.StudentClassRoutines.FindAsync(id);
            if (studentClassRoutine == null)
            {
                return NotFound();
            }
            ViewData["ClassRoutineId"] = new SelectList(_context.ClassRoutines, "ClassRoutineId", "ClassRoutineId", studentClassRoutine.ClassRoutineId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentClassRoutine.StudentId);
            return View(studentClassRoutine);
        }

        // POST: StudentClassRoutines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("StudentClassRoutineId,ClassRoutineId,StudentId")] StudentClassRoutine studentClassRoutine)
        {
            if (id != studentClassRoutine.StudentClassRoutineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentClassRoutine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentClassRoutineExists(studentClassRoutine.StudentClassRoutineId))
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
            ViewData["ClassRoutineId"] = new SelectList(_context.ClassRoutines, "ClassRoutineId", "ClassRoutineId", studentClassRoutine.ClassRoutineId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentClassRoutine.StudentId);
            return View(studentClassRoutine);
        }

        // GET: StudentClassRoutines/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.StudentClassRoutines == null)
            {
                return NotFound();
            }

            var studentClassRoutine = await _context.StudentClassRoutines
                .Include(s => s.ClassRoutine)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentClassRoutineId == id);
            if (studentClassRoutine == null)
            {
                return NotFound();
            }

            return View(studentClassRoutine);
        }

        // POST: StudentClassRoutines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.StudentClassRoutines == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StudentClassRoutines'  is null.");
            }
            var studentClassRoutine = await _context.StudentClassRoutines.FindAsync(id);
            if (studentClassRoutine != null)
            {
                _context.StudentClassRoutines.Remove(studentClassRoutine);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentClassRoutineExists(long id)
        {
          return (_context.StudentClassRoutines?.Any(e => e.StudentClassRoutineId == id)).GetValueOrDefault();
        }
    }
}
