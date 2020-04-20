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
    public class TransportationViewModelsController : Controller
    {
        private readonly Model _context;

        public TransportationViewModelsController(Model context)
        {
            _context = context;
        }

        // GET: TransportationViewModels
        public IActionResult Index()
        {
            string start = DateTime.Now.AddMonths(-1).ToString("yyyy.MM.dd");
            string end = DateTime.Now.ToString("yyyy.MM.dd");
            ViewBag.Start = start;
            ViewBag.End = end;

            DateTime startDate = DateTime.Parse(start);
            DateTime endDate = DateTime.Parse(end);

            string startString = startDate.ToString();

            string endString = endDate.ToString();

            List<Transportation> transportations = _context.transportation.Where(p => p.end_date.CompareTo(startString) >=0 && p.end_date.CompareTo(endString) <= 0)
                .Include(p => p.shareholder)
                .Include(p => p.car)
                .Include(p => p.material)
                .Include(p => p.customer)
                .Include(p => p.supply)
                .ToList();

            List<TransportationViewModel> viewList = new List<TransportationViewModel>();

            foreach(var t in transportations)
            {
                TransportationViewModel view = new TransportationViewModel();

                view.carriage_count_price = t.carriage_count_price;
                view.carriage_unit_price = t.carriage_unit_price;
                view.carriage_weight = t.carriage_weight;
                view.car_no = t.car.car_no;
                view.customer_name = t.customer.name;
                view.end_date = t.end_date;
                view.material_count_price = t.material_count_price;
                view.material_name = t.material.name;
                view.material_unit_price = t.material_unit_price;
                view.material_weight = t.material_weight;
                view.shareholder_name = t.shareholder.name;
                view.start_date = t.start_date;
                view.supply_name = t.supply.name;

                viewList.Add(view);
            }

            return View(viewList);
        }

        [HttpPost]
        public IActionResult Index(string start, string end)
        {
            ViewBag.Start = start;
            ViewBag.End = end;

            DateTime startDate = DateTime.Parse(start);
            DateTime endDate = DateTime.Parse(end);

            string startString = startDate.ToString();

            string endString = endDate.ToString();

            List<Transportation> transportations = _context.transportation.Where(p => p.end_date.CompareTo(startString) >= 0 && p.end_date.CompareTo(endString) <= 0)
                .Include(p => p.shareholder)
                .Include(p => p.car)
                .Include(p => p.material)
                .Include(p => p.customer)
                .Include(p => p.supply)
                .ToList();

            List<TransportationViewModel> viewList = new List<TransportationViewModel>();

            foreach (var t in transportations)
            {
                TransportationViewModel view = new TransportationViewModel();

                view.carriage_count_price = t.carriage_count_price;
                view.carriage_unit_price = t.carriage_unit_price;
                view.carriage_weight = t.carriage_weight;
                view.car_no = t.car.car_no;
                view.customer_name = t.customer.name;
                view.end_date = t.end_date;
                view.material_count_price = t.material_count_price;
                view.material_name = t.material.name;
                view.material_unit_price = t.material_unit_price;
                view.material_weight = t.material_weight;
                view.shareholder_name = t.shareholder.name;
                view.start_date = t.start_date;
                view.supply_name = t.supply.name;

                viewList.Add(view);
            }

            return View(viewList);
        }


    }
}
