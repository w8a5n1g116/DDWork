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
    public class GainLossViewModelsController : Controller
    {
        private readonly Model _context;

        public GainLossViewModelsController(Model context)
        {
            _context = context;
        }

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

            List<Transportation> transportations = _context.transportation.Where(p => p.end_date.CompareTo(startString) >= 0 && p.end_date.CompareTo(endString) <= 0).ToList();

            List<Income> incomes = _context.income.Where(p => p.create_time.CompareTo(startString) >= 0 && p.create_time.CompareTo(endString) <= 0).ToList();

            List<GainLossViewModel> viewList = new List<GainLossViewModel>();

            foreach(var t in transportations)
            {
                GainLossViewModel view = new GainLossViewModel();

                view.gain_or_loss = "支出";
                view.item = "原料费用";
                view.price = t.material_count_price;
                view.date = t.end_date;

                GainLossViewModel view2 = new GainLossViewModel();

                view2.gain_or_loss = "支出";
                view2.item = "运输费用";
                view2.price = t.carriage_count_price;
                view2.date = t.end_date;

                viewList.Add(view);
                viewList.Add(view2);
            }

            foreach(var i in incomes)
            {
                GainLossViewModel view = new GainLossViewModel();

                view.gain_or_loss = "收入";
                view.item = "回款";
                view.price = i.count_price;
                view.date = i.create_time;
            }

            viewList = viewList.OrderBy(p => p.date).ToList();

            double outCount = viewList.Where(p => p.gain_or_loss == "支出").Sum(p => p.price);
            double inCount = viewList.Where(p => p.gain_or_loss == "收入").Sum(p => p.price);

            GainLossViewModel view3 = new GainLossViewModel();

            view3.gain_or_loss = "合计";
            view3.item = "";
            view3.price = inCount - outCount;
            view3.date = "";

            viewList.Add(view3);

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

            List<Transportation> transportations = _context.transportation.Where(p => p.end_date.CompareTo(startString) >= 0 && p.end_date.CompareTo(endString) <= 0).ToList();

            List<Income> incomes = _context.income.Where(p => p.create_time.CompareTo(startString) >= 0 && p.create_time.CompareTo(endString) <= 0).ToList();

            List<GainLossViewModel> viewList = new List<GainLossViewModel>();

            foreach (var t in transportations)
            {
                GainLossViewModel view = new GainLossViewModel();

                view.gain_or_loss = "支出";
                view.item = "原料费用";
                view.price = t.material_count_price;
                view.date = t.end_date;

                GainLossViewModel view2 = new GainLossViewModel();

                view2.gain_or_loss = "支出";
                view2.item = "运输费用";
                view2.price = t.carriage_count_price;
                view2.date = t.end_date;

                viewList.Add(view);
                viewList.Add(view2);
            }

            foreach (var i in incomes)
            {
                GainLossViewModel view = new GainLossViewModel();

                view.gain_or_loss = "收入";
                view.item = "回款";
                view.price = i.count_price;
                view.date = i.create_time;
            }

            viewList = viewList.OrderBy(p => p.date).ToList();

            double outCount = viewList.Where(p => p.gain_or_loss == "支出").Sum(p => p.price);
            double inCount = viewList.Where(p => p.gain_or_loss == "收入").Sum(p => p.price);

            GainLossViewModel view3 = new GainLossViewModel();

            view3.gain_or_loss = "合计";
            view3.item = "";
            view3.price = inCount - outCount;
            view3.date = "";

            viewList.Add(view3);

            return View(viewList);
        }


    }
}
