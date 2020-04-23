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
    public class ShareholderViewModelsController : Controller
    {
        private readonly Model _context;

        public ShareholderViewModelsController(Model context)
        {
            _context = context;
        }

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

            List<Transportation> transportations = _context.transportation.Where(p => p.pay_time.CompareTo(start) >= 0 && p.pay_time.CompareTo(end) <= 0).ToList();

            List<Shareholder> shareholders = _context.shareholder.ToList();

            List<ShareholderViewModel> viewList = new List<ShareholderViewModel>();

            double allOutCount = transportations.Sum(p => p.carriage_count_price + p.material_count_price);

            foreach (var sh in shareholders)
            {
                ShareholderViewModel view = new ShareholderViewModel();

                view.shareholder_name = sh.name;

                view.out_count_price = transportations.Where(p => p.shareholder.id == sh.id).Sum(p => p.carriage_count_price);

                view.average_count_price = Convert.ToDouble((allOutCount / shareholders.Count).ToString("0.00"));

                view.difference_count_price = view.out_count_price - view.average_count_price;

                viewList.Add(view);
            }

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

            List<Transportation> transportations = _context.transportation.Where(p => p.pay_time.CompareTo(start) >= 0 && p.pay_time.CompareTo(end) <= 0).ToList();

            List<Shareholder> shareholders = _context.shareholder.ToList();

            List<ShareholderViewModel> viewList = new List<ShareholderViewModel>();

            double allOutCount = transportations.Sum(p=> p.carriage_count_price + p.material_count_price);

            foreach (var sh in shareholders)
            {
                ShareholderViewModel view = new ShareholderViewModel();

                view.shareholder_name = sh.name;

                view.out_count_price = transportations.Where(p => p.shareholder.id == sh.id).Sum(p => p.carriage_count_price);

                view.average_count_price = Convert.ToDouble((allOutCount / shareholders.Count).ToString("0.00"));

                view.difference_count_price = view.out_count_price - view.average_count_price;

                viewList.Add(view);
            }

            

            return View(viewList);
        }
    }
}
