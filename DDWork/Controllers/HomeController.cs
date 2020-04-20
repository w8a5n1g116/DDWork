using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DDWork.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace DDWork.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Model _model;

        public HomeController(ILogger<HomeController> logger,Model model)
        {
            _logger = logger;
            _model = model;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var route = filterContext.RouteData.Values;

            var controllerName = route["controller"].ToString();
            var actionName = route["action"].ToString();

            //User user = _model.user.Where(p => p.name == "王俊杰").First();
            //HttpContext.Session.SetString("User",JsonSerializer.Serialize(user));

            var userJsonString = HttpContext.Session.GetString("User");

            //User userObject = JsonSerializer.Deserialize<User>(userJsonString);

            if (controllerName != "Home" && actionName != "Index" && string.IsNullOrEmpty(userJsonString))
            {
                //重定向至登录页面
                filterContext.Result = RedirectToAction("Index");
                return;
            }

        }

        public string GetUserInfo(string code)
        {
            HttpClient _httpClient = new HttpClient();

            HttpResponseMessage ret = _httpClient.GetAsync("https://oapi.dingtalk.com/gettoken?appkey=dingbf00i6u9uslk4vso&appsecret=FMYLKxLu17x1qJVFD15oPKK_aSk0E6WG7SGnFKGZn1_-qaW94yeAasG-ntagK1vO").Result;

            string retstring = ret.Content.ReadAsStringAsync().Result;
            JObject o = JObject.Parse(retstring);

            _httpClient = new HttpClient();

            ret = _httpClient.GetAsync("https://oapi.dingtalk.com/user/getuserinfo?access_token=" + o["access_token"] + "&code=" + code).Result;

            retstring = ret.Content.ReadAsStringAsync().Result;

            JObject o2 = JObject.Parse(retstring);

            string userId = o2["userid"].ToString();
            string userName = o2["name"].ToString();

            User user = _model.user.Where(p => p.ding_id == userId).FirstOrDefault();

            if (user == null)
            {
                user = new User();
                user.name = userName;
                user.ding_id = userId;
                user.create_time = DateTime.Now.ToString() ;

                _model.user.Add(user);
                _model.SaveChanges();
            }

            HttpContext.Session.SetString("User", JsonSerializer.Serialize(user));

            return user.name;

        }

        public IActionResult Index()
        {

            var userJsonString = HttpContext.Session.GetString("User");

            if (!string.IsNullOrEmpty(userJsonString))
            {
                User user = JsonSerializer.Deserialize<User>(userJsonString);
                ViewBag.user = user;
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
