using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebApp1.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var welcomeMessage = new StringBuilder("Welcome to Melodify")
            .AppendLine("<br />Hear melodious songs and stay calm!!!");
            ViewBag.Message = welcomeMessage.ToString();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}