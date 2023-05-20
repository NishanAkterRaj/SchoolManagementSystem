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
    public class StudentPromotionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentPromotionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentPromotions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StudentPromotions.Include(s => s.Class).Include(s => s.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudentPromotions/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.StudentPromotions == null)
            {
                return NotFound();
            }

            var studentPromotion = await _context.StudentPromotions
                .Include(s => s.Class)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentPromotionId == id);
            if (studentPromotion == null)
            {
                return NotFound();
            }

            return View(studentPromotion);
        }

        // GET: StudentPromotions/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassId");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            return View();
        }

        // POST: StudentPromotions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentPromotionId,StudentId,ClassId,PromotionDate,PromotionStatus,PromotionReason,PromotionApprover")] StudentPromotion studentPromotion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentPromotion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassId", studentPromotion.ClassId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentPromotion.StudentId);
            return View(studentPromotion);
        }

        // GET: StudentPromotions/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.StudentPromotions == null)
            {
                return NotFound();
            }

            var studentPromotion = await _context.StudentPromotions.FindAsync(id);
            if (studentPromotion == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassId", studentPromotion.ClassId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentPromotion.StudentId);
            return View(studentPromotion);
        }

        // POST: StudentPromotions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("StudentPromotionId,StudentId,ClassId,PromotionDate,PromotionStatus,PromotionReason,PromotionApprover")] StudentPromotion studentPromotion)
        {
            if (id != studentPromotion.StudentPromotionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentPromotion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentPromotionExists(studentPromotion.StudentPromotionId))
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
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassId", studentPromotion.ClassId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentPromotion.StudentId);
            return View(studentPromotion);
        }

        // GET: StudentPromotions/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.StudentPromotions == null)
            {
                return NotFound();
            }

            var studentPromotion = await _context.StudentPromotions
                .Include(s => s.Class)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentPromotionId == id);
            if (studentPromotion == null)
            {
                return NotFound();
            }

            return View(studentPromotion);
        }

        // POST: StudentPromotions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.StudentPromotions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StudentPromotions'  is null.");
            }
            var studentPromotion = await _context.StudentPromotions.FindAsync(id);
            if (studentPromotion != null)
            {
                _context.StudentPromotions.Remove(studentPromotion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentPromotionExists(long id)
        {
          return (_context.StudentPromotions?.Any(e => e.StudentPromotionId == id)).GetValueOrDefault();
        }
    }
}
