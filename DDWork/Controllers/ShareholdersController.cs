using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DDWork.Models;

namespace DDWork.Controllers
{
    public class ShareholdersController : Controller
    {
        private readonly Model _context;

        public ShareholdersController(Model context)
        {
            _context = context;
        }

        // GET: Shareholders
        public async Task<IActionResult> Index()
        {
            return View(await _context.shareholder.ToListAsync());
        }

        // GET: Shareholders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shareholder = await _context.shareholder
                .FirstOrDefaultAsync(m => m.id == id);
            if (shareholder == null)
            {
                return NotFound();
            }

            return View(shareholder);
        }

        // GET: Shareholders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shareholders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,phone")] Shareholder shareholder)
        {
            if (ModelState.IsValid)
            {
                shareholder.create_time = DateTime.Now.ToString();
                _context.Add(shareholder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shareholder);
        }

        // GET: Shareholders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shareholder = await _context.shareholder.FindAsync(id);
            if (shareholder == null)
            {
                return NotFound();
            }
            return View(shareholder);
        }

        // POST: Shareholders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,phone")] Shareholder shareholder)
        {
            if (id != shareholder.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    shareholder.create_time = DateTime.Now.ToString();
                    _context.Update(shareholder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShareholderExists(shareholder.id))
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
            return View(shareholder);
        }

        // GET: Shareholders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shareholder = await _context.shareholder
                .FirstOrDefaultAsync(m => m.id == id);
            if (shareholder == null)
            {
                return NotFound();
            }

            return View(shareholder);
        }

        // POST: Shareholders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shareholder = await _context.shareholder.FindAsync(id);
            _context.shareholder.Remove(shareholder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShareholderExists(int id)
        {
            return _context.shareholder.Any(e => e.id == id);
        }
    }
}
