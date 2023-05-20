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
    public class StudentPortalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentPortalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentPortals
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StudentPortals.Include(s => s.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudentPortals/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.StudentPortals == null)
            {
                return NotFound();
            }

            var studentPortal = await _context.StudentPortals
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentPortalId == id);
            if (studentPortal == null)
            {
                return NotFound();
            }

            return View(studentPortal);
        }

        // GET: StudentPortals/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            return View();
        }

        // POST: StudentPortals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentPortalId,StudentId,UserName,Password")] StudentPortal studentPortal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentPortal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentPortal.StudentId);
            return View(studentPortal);
        }

        // GET: StudentPortals/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.StudentPortals == null)
            {
                return NotFound();
            }

            var studentPortal = await _context.StudentPortals.FindAsync(id);
            if (studentPortal == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentPortal.StudentId);
            return View(studentPortal);
        }

        // POST: StudentPortals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("StudentPortalId,StudentId,UserName,Password")] StudentPortal studentPortal)
        {
            if (id != studentPortal.StudentPortalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentPortal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentPortalExists(studentPortal.StudentPortalId))
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
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentPortal.StudentId);
            return View(studentPortal);
        }

        // GET: StudentPortals/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.StudentPortals == null)
            {
                return NotFound();
            }

            var studentPortal = await _context.StudentPortals
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentPortalId == id);
            if (studentPortal == null)
            {
                return NotFound();
            }

            return View(studentPortal);
        }

        // POST: StudentPortals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.StudentPortals == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StudentPortals'  is null.");
            }
            var studentPortal = await _context.StudentPortals.FindAsync(id);
            if (studentPortal != null)
            {
                _context.StudentPortals.Remove(studentPortal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentPortalExists(long id)
        {
          return (_context.StudentPortals?.Any(e => e.StudentPortalId == id)).GetValueOrDefault();
        }
    }
}
