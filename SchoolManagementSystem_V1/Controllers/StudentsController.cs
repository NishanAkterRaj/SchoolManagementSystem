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
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Students.Include(s => s.Campus).Include(s => s.Class).Include(s => s.Group).Include(s => s.Section).Include(s => s.Session).Include(s => s.Shift);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Campus)
                .Include(s => s.Class)
                .Include(s => s.Group)
                .Include(s => s.Section)
                .Include(s => s.Session)
                .Include(s => s.Shift)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["CampusId"] = new SelectList(_context.Campuses, "CampusId", "CampusId");
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassId");
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId");
            ViewData["SectionId"] = new SelectList(_context.Sections, "SectionId", "SectionId");
            ViewData["SessionId"] = new SelectList(_context.Sessions, "SessionId", "SessionId");
            ViewData["ShiftId"] = new SelectList(_context.Shifts, "ShiftId", "ShiftId");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,CampusId,SectionId,GroupId,SessionId,ShiftId,ClassId,FirstName,LastName,Photo,Gender,RollNumber,DateOfBirth,BirthCertificate,AdmissionDate,Religion,Nationality,PreviousSchool,Gpa,FatherName,MotherName,FatherNid,MotherNid,FatherOccupation,FatherPhoneNumber,FatherEmail,MotherOccupation,MotherPhoneNumber,MotherEmail,PresentAddress,PermanentAddress")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CampusId"] = new SelectList(_context.Campuses, "CampusId", "CampusId", student.CampusId);
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassId", student.ClassId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", student.GroupId);
            ViewData["SectionId"] = new SelectList(_context.Sections, "SectionId", "SectionId", student.SectionId);
            ViewData["SessionId"] = new SelectList(_context.Sessions, "SessionId", "SessionId", student.SessionId);
            ViewData["ShiftId"] = new SelectList(_context.Shifts, "ShiftId", "ShiftId", student.ShiftId);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["CampusId"] = new SelectList(_context.Campuses, "CampusId", "CampusId", student.CampusId);
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassId", student.ClassId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", student.GroupId);
            ViewData["SectionId"] = new SelectList(_context.Sections, "SectionId", "SectionId", student.SectionId);
            ViewData["SessionId"] = new SelectList(_context.Sessions, "SessionId", "SessionId", student.SessionId);
            ViewData["ShiftId"] = new SelectList(_context.Shifts, "ShiftId", "ShiftId", student.ShiftId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("StudentId,CampusId,SectionId,GroupId,SessionId,ShiftId,ClassId,FirstName,LastName,Photo,Gender,RollNumber,DateOfBirth,BirthCertificate,AdmissionDate,Religion,Nationality,PreviousSchool,Gpa,FatherName,MotherName,FatherNid,MotherNid,FatherOccupation,FatherPhoneNumber,FatherEmail,MotherOccupation,MotherPhoneNumber,MotherEmail,PresentAddress,PermanentAddress")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
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
            ViewData["CampusId"] = new SelectList(_context.Campuses, "CampusId", "CampusId", student.CampusId);
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassId", student.ClassId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", student.GroupId);
            ViewData["SectionId"] = new SelectList(_context.Sections, "SectionId", "SectionId", student.SectionId);
            ViewData["SessionId"] = new SelectList(_context.Sessions, "SessionId", "SessionId", student.SessionId);
            ViewData["ShiftId"] = new SelectList(_context.Shifts, "ShiftId", "ShiftId", student.ShiftId);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Campus)
                .Include(s => s.Class)
                .Include(s => s.Group)
                .Include(s => s.Section)
                .Include(s => s.Session)
                .Include(s => s.Shift)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Students == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Students'  is null.");
            }
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(long id)
        {
          return (_context.Students?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
