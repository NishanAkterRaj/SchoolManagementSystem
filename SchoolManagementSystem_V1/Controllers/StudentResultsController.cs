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
    public class StudentResultsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentResultsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentResults
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StudentResults.Include(s => s.Grade).Include(s => s.Student).Include(s => s.Subject);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudentResults/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.StudentResults == null)
            {
                return NotFound();
            }

            var studentResult = await _context.StudentResults
                .Include(s => s.Grade)
                .Include(s => s.Student)
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(m => m.StudentResultId == id);
            if (studentResult == null)
            {
                return NotFound();
            }

            return View(studentResult);
        }

        // GET: StudentResults/Create
        public IActionResult Create()
        {
            ViewData["GradeId"] = new SelectList(_context.GradingSystems, "GradeId", "GradeId");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId");
            return View();
        }

        // POST: StudentResults/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentResultId,StudentId,SubjectId,GradeId,ObtainedMark")] StudentResult studentResult)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentResult);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GradeId"] = new SelectList(_context.GradingSystems, "GradeId", "GradeId", studentResult.GradeId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentResult.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", studentResult.SubjectId);
            return View(studentResult);
        }

        // GET: StudentResults/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.StudentResults == null)
            {
                return NotFound();
            }

            var studentResult = await _context.StudentResults.FindAsync(id);
            if (studentResult == null)
            {
                return NotFound();
            }
            ViewData["GradeId"] = new SelectList(_context.GradingSystems, "GradeId", "GradeId", studentResult.GradeId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentResult.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", studentResult.SubjectId);
            return View(studentResult);
        }

        // POST: StudentResults/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("StudentResultId,StudentId,SubjectId,GradeId,ObtainedMark")] StudentResult studentResult)
        {
            if (id != studentResult.StudentResultId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentResult);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentResultExists(studentResult.StudentResultId))
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
            ViewData["GradeId"] = new SelectList(_context.GradingSystems, "GradeId", "GradeId", studentResult.GradeId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentResult.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", studentResult.SubjectId);
            return View(studentResult);
        }

        // GET: StudentResults/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.StudentResults == null)
            {
                return NotFound();
            }

            var studentResult = await _context.StudentResults
                .Include(s => s.Grade)
                .Include(s => s.Student)
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(m => m.StudentResultId == id);
            if (studentResult == null)
            {
                return NotFound();
            }

            return View(studentResult);
        }

        // POST: StudentResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.StudentResults == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StudentResults'  is null.");
            }
            var studentResult = await _context.StudentResults.FindAsync(id);
            if (studentResult != null)
            {
                _context.StudentResults.Remove(studentResult);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentResultExists(long id)
        {
          return (_context.StudentResults?.Any(e => e.StudentResultId == id)).GetValueOrDefault();
        }
    }
}
