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
    public class StudentPaymentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentPaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentPayments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StudentPayments.Include(s => s.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudentPayments/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.StudentPayments == null)
            {
                return NotFound();
            }

            var studentPayment = await _context.StudentPayments
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentPaymentId == id);
            if (studentPayment == null)
            {
                return NotFound();
            }

            return View(studentPayment);
        }

        // GET: StudentPayments/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            return View();
        }

        // POST: StudentPayments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentPaymentId,StudentId,PaymentDate,PaymentAmmount,PaymentType,PaymentReference,PaymentStatus")] StudentPayment studentPayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentPayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentPayment.StudentId);
            return View(studentPayment);
        }

        // GET: StudentPayments/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.StudentPayments == null)
            {
                return NotFound();
            }

            var studentPayment = await _context.StudentPayments.FindAsync(id);
            if (studentPayment == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentPayment.StudentId);
            return View(studentPayment);
        }

        // POST: StudentPayments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("StudentPaymentId,StudentId,PaymentDate,PaymentAmmount,PaymentType,PaymentReference,PaymentStatus")] StudentPayment studentPayment)
        {
            if (id != studentPayment.StudentPaymentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentPayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentPaymentExists(studentPayment.StudentPaymentId))
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
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentPayment.StudentId);
            return View(studentPayment);
        }

        // GET: StudentPayments/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.StudentPayments == null)
            {
                return NotFound();
            }

            var studentPayment = await _context.StudentPayments
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentPaymentId == id);
            if (studentPayment == null)
            {
                return NotFound();
            }

            return View(studentPayment);
        }

        // POST: StudentPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.StudentPayments == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StudentPayments'  is null.");
            }
            var studentPayment = await _context.StudentPayments.FindAsync(id);
            if (studentPayment != null)
            {
                _context.StudentPayments.Remove(studentPayment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentPaymentExists(long id)
        {
          return (_context.StudentPayments?.Any(e => e.StudentPaymentId == id)).GetValueOrDefault();
        }
    }
}
