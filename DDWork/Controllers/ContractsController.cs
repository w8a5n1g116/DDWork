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
    public class ContractsController : Controller
    {
        private readonly Model _context;

        private readonly List<Customer> customers;
        private readonly List<Material> materials;

        public ContractsController(Model context)
        {
            _context = context;
            customers = _context.customer.ToList();
            materials = _context.material.ToList();
        }

        // GET: Contracts
        public async Task<IActionResult> Index()
        {
            return View(await _context.contract.ToListAsync());
        }

        // GET: Contracts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.contract
                .FirstOrDefaultAsync(m => m.id == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // GET: Contracts/Create
        public IActionResult Create()
        {
            ViewBag.Customers = customers;
            ViewBag.Materials = materials;
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,weight,print_weight,print_price,fine,contract_price,delivery_date,customer,material")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                Customer customer = _context.customer.Where(p => p.id == contract.customer.id).First();

                contract.customer = customer;

                Material material = _context.material.Where(p => p.id == contract.material.id).First();

                contract.material = material;

                contract.create_time = DateTime.Now.ToString();
                _context.Add(contract);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contract);
        }

        // GET: Contracts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.contract.FindAsync(id);
            if (contract == null)
            {
                return NotFound();
            }

            ViewBag.Customers = customers;
            ViewBag.Materials = materials;

            return View(contract);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,weight,print_weight,print_price,fine,contract_price,delivery_date,customer,material")] Contract contract)
        {
            if (id != contract.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Customer customer = _context.customer.Where(p => p.id == contract.customer.id).First();

                    contract.customer = customer;

                    Material material = _context.material.Where(p => p.id == contract.material.id).First();

                    contract.material = material;

                    contract.create_time = DateTime.Now.ToString();
                    _context.Update(contract);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractExists(contract.id))
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
            return View(contract);
        }

        // GET: Contracts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.contract
                .FirstOrDefaultAsync(m => m.id == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contract = await _context.contract.FindAsync(id);
            _context.contract.Remove(contract);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractExists(int id)
        {
            return _context.contract.Any(e => e.id == id);
        }
    }
}
