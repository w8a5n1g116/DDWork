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
    public class TransportationsController : Controller
    {
        private readonly Model _context;
        private readonly List<Customer> customers;
        private readonly List<Material> materials;
        private readonly List<Shareholder> shareholders;
        private readonly List<Car> cars;
        private readonly List<Supply> supplies;
        private readonly List<MaterialUnitPrice> materialUnitPrices;

        public TransportationsController(Model context)
        {
            _context = context;
            customers = _context.customer.ToList();
            materials = _context.material.ToList();
            shareholders = _context.shareholder.ToList();
            cars = _context.car.ToList();
            supplies = _context.supply.ToList();

            materialUnitPrices = new List<MaterialUnitPrice>();

            foreach (var m in materials)
            {
                MaterialUnitPrice mup = _context.material_unit_price.Where(p => p.material.id == m.id).OrderByDescending(p => p.create_time).FirstOrDefault();

                if (mup != null)
                {
                    materialUnitPrices.Add(mup);
                }
            }
        }

        // GET: Transportations
        public async Task<IActionResult> Index()
        {
            return View(await _context.transportation.ToListAsync());
        }

        // GET: Transportations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportation = await _context.transportation
                .FirstOrDefaultAsync(m => m.id == id);
            if (transportation == null)
            {
                return NotFound();
            }

            return View(transportation);
        }

        // GET: Transportations/Create
        public IActionResult Create()
        {

            ViewBag.MaterialUnitPrices = materialUnitPrices;
            ViewBag.Customers = customers;
            ViewBag.Materials = materials;
            ViewBag.Shareholders = shareholders;
            ViewBag.Cars = cars;
            ViewBag.Supplies = supplies;
            return View();
        }

        // POST: Transportations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,material_weight,carriage_weight,material_unit_price,carriage_unit_price,material_count_price,carriage_count_price,start_date,end_date,customer,shareholder,car,supply,material,carriage_should_count_price,service_charge,pay_time")] Transportation transportation)
        {
            if (ModelState.IsValid)
            {
                Customer customer = _context.customer.Where(p => p.id == transportation.customer.id).First();

                transportation.customer = customer;

                Material material = _context.material.Where(p => p.id == transportation.material.id).First();

                transportation.material = material;

                Car car = _context.car.Where(p => p.id == transportation.car.id).First();

                transportation.car = car;

                Supply supply = _context.supply.Where(p => p.id == transportation.supply.id).First();

                transportation.supply = supply;

                transportation.create_time = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                _context.Add(transportation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transportation);
        }

        // GET: Transportations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportation = await _context.transportation.FindAsync(id);
            if (transportation == null)
            {
                return NotFound();
            }
            ViewBag.MaterialUnitPrices = materialUnitPrices;
            ViewBag.Customers = customers;
            ViewBag.Materials = materials;
            ViewBag.Shareholders = shareholders;
            ViewBag.Cars = cars;
            ViewBag.Supplies = supplies;
            return View(transportation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,material_weight,carriage_weight,material_unit_price,carriage_unit_price,material_count_price,carriage_count_price,start_date,end_date,customer,shareholder,car,supply,material,carriage_should_count_price,service_charge,pay_time")] Transportation transportation)
        {
            if (id != transportation.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Customer customer = _context.customer.Where(p => p.id == transportation.customer.id).First();

                    transportation.customer = customer;

                    Material material = _context.material.Where(p => p.id == transportation.material.id).First();

                    transportation.material = material;

                    Shareholder shareholder = _context.shareholder.Where(p => p.id == transportation.shareholder.id).First();

                    transportation.shareholder = shareholder;

                    Car car = _context.car.Where(p => p.id == transportation.car.id).First();

                    transportation.car = car;

                    Supply supply = _context.supply.Where(p => p.id == transportation.supply.id).First();

                    transportation.supply = supply;

                    transportation.create_time = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                    _context.Update(transportation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransportationExists(transportation.id))
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
            return View(transportation);
        }

        public async Task<IActionResult> Edit_Receive(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportation = await _context.transportation.FindAsync(id);
            if (transportation == null)
            {
                return NotFound();
            }
            ViewBag.MaterialUnitPrices = materialUnitPrices;
            ViewBag.Customers = customers;
            ViewBag.Materials = materials;
            ViewBag.Shareholders = shareholders;
            ViewBag.Cars = cars;
            ViewBag.Supplies = supplies;
            return View(transportation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit_Receive(int id, [Bind("id,material_weight,carriage_weight,material_unit_price,carriage_unit_price,material_count_price,carriage_count_price,start_date,end_date,customer,shareholder,car,supply,material,carriage_should_count_price,service_charge,pay_time")] Transportation transportation)
        {
            if (id != transportation.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Transportation _trasportation = _context.transportation.Where(p => p.id == id).First();

                    _trasportation.end_date = transportation.end_date;
                    _trasportation.carriage_weight = transportation.carriage_weight;
                    _trasportation.carriage_should_count_price = transportation.carriage_should_count_price;
                    
                    _context.Update(_trasportation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransportationExists(transportation.id))
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
            return View(transportation);
        }


        public async Task<IActionResult> Edit_Cashier(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportation = await _context.transportation.FindAsync(id);
            if (transportation == null)
            {
                return NotFound();
            }
            ViewBag.MaterialUnitPrices = materialUnitPrices;
            ViewBag.Customers = customers;
            ViewBag.Materials = materials;
            ViewBag.Shareholders = shareholders;
            ViewBag.Cars = cars;
            ViewBag.Supplies = supplies;
            return View(transportation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit_Cashier(int id, [Bind("id,material_weight,carriage_weight,material_unit_price,carriage_unit_price,material_count_price,carriage_count_price,start_date,end_date,customer,shareholder,car,supply,material,carriage_should_count_price,service_charge,pay_time")] Transportation transportation)
        {
            if (id != transportation.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    

                    Transportation _trasportation = _context.transportation.Where(p => p.id == id).First();

                    _trasportation.service_charge = transportation.service_charge;
                    _trasportation.carriage_count_price = transportation.carriage_count_price;
                    _trasportation.pay_time = transportation.pay_time;

                    Shareholder shareholder = _context.shareholder.Where(p => p.id == transportation.shareholder.id).First();

                    _trasportation.shareholder = shareholder;


                    _context.Update(_trasportation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransportationExists(transportation.id))
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
            return View(transportation);
        }

        public async Task<IActionResult> GetOver(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportation = await _context.transportation.FindAsync(id);
            if (transportation == null)
            {
                return NotFound();
            }

            transportation.end_date = DateTime.Now.ToString("yyyy.MM.dd");

            _context.Update(transportation);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: Transportations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportation = await _context.transportation
                .FirstOrDefaultAsync(m => m.id == id);
            if (transportation == null)
            {
                return NotFound();
            }

            return View(transportation);
        }

        // POST: Transportations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transportation = await _context.transportation.FindAsync(id);
            _context.transportation.Remove(transportation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransportationExists(int id)
        {
            return _context.transportation.Any(e => e.id == id);
        }
    }
}
