using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DDWork.Models;
using OfficeOpenXml;

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

            //DateTime startDate = DateTime.Parse(start);
            //DateTime endDate = DateTime.Parse(end);

            //string startString = startDate.ToString();

            //string endString = endDate.ToString();

            List<Transportation> transportations = _context.transportation.Where(p => p.pay_time.CompareTo(start) >=0 && p.pay_time.CompareTo(end) <= 0 && p.carriage_count_price != 0)
                .Include(p => p.shareholder)
                .Include(p => p.car)
                .Include(p => p.material)
                .Include(p => p.customer)
                .Include(p => p.supply)
                .ToList();

            List<TransportationViewModel> viewList = new List<TransportationViewModel>();

            double carriage_count_price = 0;
            double carriage_should_count_price = 0;
            double service_charge = 0;
            double carriage_weight = 0;
            double material_weight = 0;

            foreach (var t in transportations)
            {
                TransportationViewModel view = new TransportationViewModel();

                view.carriage_count_price = t.carriage_count_price;
                view.carriage_unit_price = t.carriage_unit_price;
                view.carriage_should_count_price = t.carriage_should_count_price;
                view.service_charge = t.service_charge;
                view.carriage_weight = t.carriage_weight;
                view.car_no = t.car.car_no;
                view.car_name = t.car.name;
                view.car_phone = t.car.phone;
                view.customer_name = t.customer.name;
                view.end_date = t.end_date;
                view.material_count_price = t.material_count_price;
                view.material_name = t.material.name;
                view.material_unit_price = t.material_unit_price;
                view.material_weight = t.material_weight;
                view.shareholder_name = t.shareholder.name;
                view.start_date = t.start_date;
                view.supply_name = t.supply.name;
                view.pay_time = t.pay_time;

                

                viewList.Add(view);

                carriage_count_price += view.carriage_count_price;
                carriage_should_count_price += view.carriage_should_count_price;
                service_charge += view.service_charge;
                carriage_weight += view.carriage_weight;
                material_weight += view.material_weight;
            }

            TransportationViewModel viewCount = new TransportationViewModel();

            viewCount.supply_name = "合计 ==>";
            viewCount.carriage_count_price = carriage_count_price;
            viewCount.carriage_should_count_price = carriage_should_count_price;
            viewCount.service_charge = service_charge;
            viewCount.carriage_weight = carriage_weight;
            viewCount.material_weight = material_weight;

            viewList.Add(viewCount);

            return View(viewList);
        }

        [HttpPost]
        public IActionResult Index(string start, string end)
        {
            ViewBag.Start = start;
            ViewBag.End = end;

            //DateTime startDate = DateTime.Parse(start);
            //DateTime endDate = DateTime.Parse(end);

            //string startString = startDate.ToString();

            //string endString = endDate.ToString();

            List<Transportation> transportations = _context.transportation.Where(p => p.pay_time.CompareTo(start) >= 0 && p.pay_time.CompareTo(end) <= 0 && p.carriage_count_price != 0)
                .Include(p => p.shareholder)
                .Include(p => p.car)
                .Include(p => p.material)
                .Include(p => p.customer)
                .Include(p => p.supply)
                .ToList();

            List<TransportationViewModel> viewList = new List<TransportationViewModel>();

            double carriage_count_price = 0;
            double carriage_should_count_price = 0;
            double service_charge = 0;
            double carriage_weight = 0;
            double material_weight = 0;

            foreach (var t in transportations)
            {
                TransportationViewModel view = new TransportationViewModel();

                view.carriage_count_price = t.carriage_count_price;
                view.carriage_unit_price = t.carriage_unit_price;
                view.carriage_should_count_price = t.carriage_should_count_price;
                view.service_charge = t.service_charge;
                view.carriage_weight = t.carriage_weight;
                view.car_no = t.car.car_no;
                view.car_name = t.car.name;
                view.car_phone = t.car.phone;
                view.customer_name = t.customer.name;
                view.end_date = t.end_date;
                view.material_count_price = t.material_count_price;
                view.material_name = t.material.name;
                view.material_unit_price = t.material_unit_price;
                view.material_weight = t.material_weight;
                view.shareholder_name = t.shareholder.name;
                view.start_date = t.start_date;
                view.supply_name = t.supply.name;
                view.pay_time = t.pay_time;

                viewList.Add(view);

                carriage_count_price += view.carriage_count_price;
                carriage_should_count_price += view.carriage_should_count_price;
                service_charge += view.service_charge;
                carriage_weight += view.carriage_weight;
                material_weight += view.material_weight;

            }

            TransportationViewModel viewCount = new TransportationViewModel();

            viewCount.supply_name = "合计 ==>";
            viewCount.carriage_count_price = carriage_count_price;
            viewCount.carriage_should_count_price = carriage_should_count_price;
            viewCount.service_charge = service_charge;
            viewCount.carriage_weight = carriage_weight;
            viewCount.material_weight = material_weight;

            viewList.Add(viewCount);

            return View(viewList);
        }

        public string CreateAndGetExcelFilePath()
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                //Add the headers
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Product";
                worksheet.Cells[1, 3].Value = "Quantity";
                worksheet.Cells[1, 4].Value = "Price";
                worksheet.Cells[1, 5].Value = "Value";
            }
            return "";
        }
    }
}
