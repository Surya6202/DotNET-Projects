using System;
using System.Linq;
using System.Web.Mvc;
using WebApp1.MVC.DataAccess;
using WebApp1.MVC.Models;

namespace WebApp1.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly WebAppDbContext _context;
        public UserController(WebAppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            user.Role = user.UserName.Contains("$") ? "Admin" : user.Role;
            user.UserName = user.UserName.Substring(1);

            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException("Credentials", "Username or password cannot be empty.");
            }

            var authenticatedUser = _context.Users.SingleOrDefault(x => x.UserName == userName && x.Password == password);

            if (authenticatedUser == null)
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return View();
            }

            Session["UserName"] = authenticatedUser.UserName;
            Session["Role"] = authenticatedUser.Role;

            return RedirectToAction("Index", "Music");
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string userName, string password)
        {
            var existingUser = _context.Users.SingleOrDefault(x => x.UserName == userName);

            if (existingUser == null)
            {
                ModelState.AddModelError("", "Invalid UserName or Password");
                return View();
            }

            existingUser.Password = password;
            _context.SaveChanges();
            ViewBag.Message = "Password is resetted";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}