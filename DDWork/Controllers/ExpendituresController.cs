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
    public class ExpendituresController : Controller
    {
        private readonly Model _context;

        public ExpendituresController(Model context)
        {
            _context = context;
        }

        // GET: Expenditures
        public async Task<IActionResult> Index()
        {
            return View(await _context.expenditure.ToListAsync());
        }

        // GET: Expenditures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenditure = await _context.expenditure
                .FirstOrDefaultAsync(m => m.id == id);
            if (expenditure == null)
            {
                return NotFound();
            }

            return View(expenditure);
        }

        // GET: Expenditures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Expenditures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,material_count_price,carriage_count_price")] Expenditure expenditure)
        {
            if (ModelState.IsValid)
            {
                expenditure.create_time = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                _context.Add(expenditure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expenditure);
        }

        // GET: Expenditures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenditure = await _context.expenditure.FindAsync(id);
            if (expenditure == null)
            {
                return NotFound();
            }
            return View(expenditure);
        }

        // POST: Expenditures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,material_count_price,carriage_count_price")] Expenditure expenditure)
        {
            if (id != expenditure.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    expenditure.create_time = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                    _context.Update(expenditure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenditureExists(expenditure.id))
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
            return View(expenditure);
        }

        // GET: Expenditures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenditure = await _context.expenditure
                .FirstOrDefaultAsync(m => m.id == id);
            if (expenditure == null)
            {
                return NotFound();
            }

            return View(expenditure);
        }

        // POST: Expenditures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expenditure = await _context.expenditure.FindAsync(id);
            _context.expenditure.Remove(expenditure);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenditureExists(int id)
        {
            return _context.expenditure.Any(e => e.id == id);
        }
    }
}
