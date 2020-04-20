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
    public class MaterialUnitPricesController : Controller
    {
        private readonly Model _context;
        private readonly List<Material> materials;

        public MaterialUnitPricesController(Model context)
        {
            _context = context;
            materials = _context.material.ToList();
        }

        // GET: MaterialUnitPrices
        public async Task<IActionResult> Index()
        {
            return View(await _context.material_unit_price.ToListAsync());
        }

        // GET: MaterialUnitPrices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialUnitPrice = await _context.material_unit_price
                .FirstOrDefaultAsync(m => m.id == id);
            if (materialUnitPrice == null)
            {
                return NotFound();
            }

            return View(materialUnitPrice);
        }

        // GET: MaterialUnitPrices/Create
        public IActionResult Create()
        {
            ViewBag.Materials = materials;
            return View();
        }

        // POST: MaterialUnitPrices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,price,material")] MaterialUnitPrice materialUnitPrice)
        {
            if (ModelState.IsValid)
            {
                Material material = _context.material.Where(p => p.id == materialUnitPrice.material.id).First();

                materialUnitPrice.material = material;
                materialUnitPrice.create_time = DateTime.Now.ToString();
                _context.Add(materialUnitPrice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materialUnitPrice);
        }

        // GET: MaterialUnitPrices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialUnitPrice = await _context.material_unit_price.FindAsync(id);
            if (materialUnitPrice == null)
            {
                return NotFound();
            }
            ViewBag.Materials = materials;
            return View(materialUnitPrice);
        }

        // POST: MaterialUnitPrices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,price,material")] MaterialUnitPrice materialUnitPrice)
        {
            if (id != materialUnitPrice.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Material material = _context.material.Where(p => p.id == materialUnitPrice.material.id).First();

                    materialUnitPrice.material = material;
                    materialUnitPrice.create_time = DateTime.Now.ToString();
                    _context.Update(materialUnitPrice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialUnitPriceExists(materialUnitPrice.id))
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
            return View(materialUnitPrice);
        }

        // GET: MaterialUnitPrices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialUnitPrice = await _context.material_unit_price
                .FirstOrDefaultAsync(m => m.id == id);
            if (materialUnitPrice == null)
            {
                return NotFound();
            }

            return View(materialUnitPrice);
        }

        // POST: MaterialUnitPrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materialUnitPrice = await _context.material_unit_price.FindAsync(id);
            _context.material_unit_price.Remove(materialUnitPrice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialUnitPriceExists(int id)
        {
            return _context.material_unit_price.Any(e => e.id == id);
        }
    }
}
