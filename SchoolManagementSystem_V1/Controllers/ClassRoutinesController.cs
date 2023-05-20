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
    public class ClassRoutinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassRoutinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClassRoutines
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ClassRoutines.Include(c => c.Class).Include(c => c.Room).Include(c => c.Section).Include(c => c.Shift).Include(c => c.Subject);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ClassRoutines/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.ClassRoutines == null)
            {
                return NotFound();
            }

            var classRoutine = await _context.ClassRoutines
                .Include(c => c.Class)
                .Include(c => c.Room)
                .Include(c => c.Section)
                .Include(c => c.Shift)
                .Include(c => c.Subject)
                .FirstOrDefaultAsync(m => m.ClassRoutineId == id);
            if (classRoutine == null)
            {
                return NotFound();
            }

            return View(classRoutine);
        }

        // GET: ClassRoutines/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassId");
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId");
            ViewData["SectionId"] = new SelectList(_context.Sections, "SectionId", "SectionId");
            ViewData["Shiftid"] = new SelectList(_context.Shifts, "ShiftId", "ShiftId");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId");
            return View();
        }

        // POST: ClassRoutines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassRoutineId,ClassId,SubjectId,RoomId,Shiftid,SectionId,WeekDay,StartTime,EndTime,Duration")] ClassRoutine classRoutine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classRoutine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassId", classRoutine.ClassId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId", classRoutine.RoomId);
            ViewData["SectionId"] = new SelectList(_context.Sections, "SectionId", "SectionId", classRoutine.SectionId);
            ViewData["Shiftid"] = new SelectList(_context.Shifts, "ShiftId", "ShiftId", classRoutine.Shiftid);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", classRoutine.SubjectId);
            return View(classRoutine);
        }

        // GET: ClassRoutines/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.ClassRoutines == null)
            {
                return NotFound();
            }

            var classRoutine = await _context.ClassRoutines.FindAsync(id);
            if (classRoutine == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassId", classRoutine.ClassId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId", classRoutine.RoomId);
            ViewData["SectionId"] = new SelectList(_context.Sections, "SectionId", "SectionId", classRoutine.SectionId);
            ViewData["Shiftid"] = new SelectList(_context.Shifts, "ShiftId", "ShiftId", classRoutine.Shiftid);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", classRoutine.SubjectId);
            return View(classRoutine);
        }

        // POST: ClassRoutines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ClassRoutineId,ClassId,SubjectId,RoomId,Shiftid,SectionId,WeekDay,StartTime,EndTime,Duration")] ClassRoutine classRoutine)
        {
            if (id != classRoutine.ClassRoutineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classRoutine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassRoutineExists(classRoutine.ClassRoutineId))
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
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassId", classRoutine.ClassId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId", classRoutine.RoomId);
            ViewData["SectionId"] = new SelectList(_context.Sections, "SectionId", "SectionId", classRoutine.SectionId);
            ViewData["Shiftid"] = new SelectList(_context.Shifts, "ShiftId", "ShiftId", classRoutine.Shiftid);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", classRoutine.SubjectId);
            return View(classRoutine);
        }

        // GET: ClassRoutines/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.ClassRoutines == null)
            {
                return NotFound();
            }

            var classRoutine = await _context.ClassRoutines
                .Include(c => c.Class)
                .Include(c => c.Room)
                .Include(c => c.Section)
                .Include(c => c.Shift)
                .Include(c => c.Subject)
                .FirstOrDefaultAsync(m => m.ClassRoutineId == id);
            if (classRoutine == null)
            {
                return NotFound();
            }

            return View(classRoutine);
        }

        // POST: ClassRoutines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.ClassRoutines == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ClassRoutines'  is null.");
            }
            var classRoutine = await _context.ClassRoutines.FindAsync(id);
            if (classRoutine != null)
            {
                _context.ClassRoutines.Remove(classRoutine);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassRoutineExists(long id)
        {
          return (_context.ClassRoutines?.Any(e => e.ClassRoutineId == id)).GetValueOrDefault();
        }
    }
}
