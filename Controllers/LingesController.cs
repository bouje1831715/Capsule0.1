using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcLinge.Data;
using MvcLinge.Models;

namespace MvcLinge.Controllers
{
    public class LingesController : Controller
    {
        private readonly MvcLingeContext _context;

        public LingesController(MvcLingeContext context)
        {
            _context = context;
        }

        // GET: Linges
        public async Task<IActionResult> Index()
        {
            return View(await _context.Linge.ToListAsync());
        }

        // GET: Linges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linge = await _context.Linge
                .FirstOrDefaultAsync(m => m.Id == id);
            if (linge == null)
            {
                return NotFound();
            }

            return View(linge);
        }

        // GET: Linges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Linges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Linge linge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(linge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(linge);
        }

        // GET: Linges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linge = await _context.Linge.FindAsync(id);
            if (linge == null)
            {
                return NotFound();
            }
            return View(linge);
        }

        // POST: Linges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Linge linge)
        {
            if (id != linge.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(linge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LingeExists(linge.Id))
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
            return View(linge);
        }

        // GET: Linges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linge = await _context.Linge
                .FirstOrDefaultAsync(m => m.Id == id);
            if (linge == null)
            {
                return NotFound();
            }

            return View(linge);
        }

        // POST: Linges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var linge = await _context.Linge.FindAsync(id);
            _context.Linge.Remove(linge);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LingeExists(int id)
        {
            return _context.Linge.Any(e => e.Id == id);
        }
    }
}
