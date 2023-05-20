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
    public class StuffsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StuffsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Stuffs
        public async Task<IActionResult> Index()
        {
              return _context.Stuffs != null ? 
                          View(await _context.Stuffs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Stuffs'  is null.");
        }

        // GET: Stuffs/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Stuffs == null)
            {
                return NotFound();
            }

            var stuff = await _context.Stuffs
                .FirstOrDefaultAsync(m => m.StuffId == id);
            if (stuff == null)
            {
                return NotFound();
            }

            return View(stuff);
        }

        // GET: Stuffs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stuffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StuffId,Name,Email,Phone,Address,Gender,DateOfBirth,Qualification,Religion,AssignedTo")] Stuff stuff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stuff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stuff);
        }

        // GET: Stuffs/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Stuffs == null)
            {
                return NotFound();
            }

            var stuff = await _context.Stuffs.FindAsync(id);
            if (stuff == null)
            {
                return NotFound();
            }
            return View(stuff);
        }

        // POST: Stuffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("StuffId,Name,Email,Phone,Address,Gender,DateOfBirth,Qualification,Religion,AssignedTo")] Stuff stuff)
        {
            if (id != stuff.StuffId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stuff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StuffExists(stuff.StuffId))
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
            return View(stuff);
        }

        // GET: Stuffs/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Stuffs == null)
            {
                return NotFound();
            }

            var stuff = await _context.Stuffs
                .FirstOrDefaultAsync(m => m.StuffId == id);
            if (stuff == null)
            {
                return NotFound();
            }

            return View(stuff);
        }

        // POST: Stuffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Stuffs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Stuffs'  is null.");
            }
            var stuff = await _context.Stuffs.FindAsync(id);
            if (stuff != null)
            {
                _context.Stuffs.Remove(stuff);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StuffExists(long id)
        {
          return (_context.Stuffs?.Any(e => e.StuffId == id)).GetValueOrDefault();
        }
    }
}
