using System;
using System.Web.Mvc;
using System.Text;

namespace WebApp1.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var welcomeMessage = $"Welcome to Melodify<br />Hear melodious songs and stay calm!!!";
            ViewBag.Message = welcomeMessage;
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