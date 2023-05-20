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
    public class TeacherDesignationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherDesignationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TeacherDesignations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TeacherDesignations.Include(t => t.Designation).Include(t => t.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TeacherDesignations/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.TeacherDesignations == null)
            {
                return NotFound();
            }

            var teacherDesignation = await _context.TeacherDesignations
                .Include(t => t.Designation)
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.TeacherDesignationId == id);
            if (teacherDesignation == null)
            {
                return NotFound();
            }

            return View(teacherDesignation);
        }

        // GET: TeacherDesignations/Create
        public IActionResult Create()
        {
            ViewData["DesignationId"] = new SelectList(_context.Designations, "DesignationId", "DesignationId");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId");
            return View();
        }

        // POST: TeacherDesignations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherDesignationId,DesignationId,TeacherId")] TeacherDesignation teacherDesignation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacherDesignation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DesignationId"] = new SelectList(_context.Designations, "DesignationId", "DesignationId", teacherDesignation.DesignationId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", teacherDesignation.TeacherId);
            return View(teacherDesignation);
        }

        // GET: TeacherDesignations/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.TeacherDesignations == null)
            {
                return NotFound();
            }

            var teacherDesignation = await _context.TeacherDesignations.FindAsync(id);
            if (teacherDesignation == null)
            {
                return NotFound();
            }
            ViewData["DesignationId"] = new SelectList(_context.Designations, "DesignationId", "DesignationId", teacherDesignation.DesignationId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", teacherDesignation.TeacherId);
            return View(teacherDesignation);
        }

        // POST: TeacherDesignations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("TeacherDesignationId,DesignationId,TeacherId")] TeacherDesignation teacherDesignation)
        {
            if (id != teacherDesignation.TeacherDesignationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherDesignation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherDesignationExists(teacherDesignation.TeacherDesignationId))
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
            ViewData["DesignationId"] = new SelectList(_context.Designations, "DesignationId", "DesignationId", teacherDesignation.DesignationId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", teacherDesignation.TeacherId);
            return View(teacherDesignation);
        }

        // GET: TeacherDesignations/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.TeacherDesignations == null)
            {
                return NotFound();
            }

            var teacherDesignation = await _context.TeacherDesignations
                .Include(t => t.Designation)
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.TeacherDesignationId == id);
            if (teacherDesignation == null)
            {
                return NotFound();
            }

            return View(teacherDesignation);
        }

        // POST: TeacherDesignations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.TeacherDesignations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TeacherDesignations'  is null.");
            }
            var teacherDesignation = await _context.TeacherDesignations.FindAsync(id);
            if (teacherDesignation != null)
            {
                _context.TeacherDesignations.Remove(teacherDesignation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherDesignationExists(long id)
        {
          return (_context.TeacherDesignations?.Any(e => e.TeacherDesignationId == id)).GetValueOrDefault();
        }
    }
}
