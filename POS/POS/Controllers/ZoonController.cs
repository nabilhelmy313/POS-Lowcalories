using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POS.Data;

namespace POS.Controllers
{
    [Authorize]
    public class ZoonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZoonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Zoon
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zoons.ToListAsync());
        }

        // GET: Zoon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zoon = await _context.Zoons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zoon == null)
            {
                return NotFound();
            }

            return View(zoon);
        }

        // GET: Zoon/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zoon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Cost")] Zoon zoon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zoon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zoon);
        }

        // GET: Zoon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zoon = await _context.Zoons.FindAsync(id);
            if (zoon == null)
            {
                return NotFound();
            }
            return View(zoon);
        }

        // POST: Zoon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Cost")] Zoon zoon)
        {
            if (id != zoon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zoon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZoonExists(zoon.Id))
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
            return View(zoon);
        }

        // GET: Zoon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zoon = await _context.Zoons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zoon == null)
            {
                return NotFound();
            }

            return View(zoon);
        }

        // POST: Zoon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zoon = await _context.Zoons.FindAsync(id);
            _context.Zoons.Remove(zoon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZoonExists(int id)
        {
            return _context.Zoons.Any(e => e.Id == id);
        }
    }
}
