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
    public class SuperAdminsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuperAdminsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuperAdmins
        public async Task<IActionResult> Index()
        {
              return _context.SuperAdmins != null ? 
                          View(await _context.SuperAdmins.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.SuperAdmins'  is null.");
        }

        // GET: SuperAdmins/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.SuperAdmins == null)
            {
                return NotFound();
            }

            var superAdmin = await _context.SuperAdmins
                .FirstOrDefaultAsync(m => m.SuperAdminId == id);
            if (superAdmin == null)
            {
                return NotFound();
            }

            return View(superAdmin);
        }

        // GET: SuperAdmins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SuperAdmins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SuperAdminId,Name,Gender,Photo,Email,Phone")] SuperAdmin superAdmin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(superAdmin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(superAdmin);
        }

        // GET: SuperAdmins/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.SuperAdmins == null)
            {
                return NotFound();
            }

            var superAdmin = await _context.SuperAdmins.FindAsync(id);
            if (superAdmin == null)
            {
                return NotFound();
            }
            return View(superAdmin);
        }

        // POST: SuperAdmins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("SuperAdminId,Name,Gender,Photo,Email,Phone")] SuperAdmin superAdmin)
        {
            if (id != superAdmin.SuperAdminId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(superAdmin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuperAdminExists(superAdmin.SuperAdminId))
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
            return View(superAdmin);
        }

        // GET: SuperAdmins/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.SuperAdmins == null)
            {
                return NotFound();
            }

            var superAdmin = await _context.SuperAdmins
                .FirstOrDefaultAsync(m => m.SuperAdminId == id);
            if (superAdmin == null)
            {
                return NotFound();
            }

            return View(superAdmin);
        }

        // POST: SuperAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.SuperAdmins == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SuperAdmins'  is null.");
            }
            var superAdmin = await _context.SuperAdmins.FindAsync(id);
            if (superAdmin != null)
            {
                _context.SuperAdmins.Remove(superAdmin);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuperAdminExists(long id)
        {
          return (_context.SuperAdmins?.Any(e => e.SuperAdminId == id)).GetValueOrDefault();
        }
    }
}
