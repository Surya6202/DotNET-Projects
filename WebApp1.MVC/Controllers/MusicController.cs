using Microsoft.EntityFrameworkCore;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using WebApp1.MVC.DataAccess;
using WebApp1.MVC.Models;

namespace WebApp1.MVC.Controllers
{
    public class MusicController : SecuredController
    {
        private readonly WebAppDbContext _context;
        public MusicController(WebAppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var musicDetails = _context.MusicDetails;
            return View(musicDetails);
        }

        [HttpPost]
        public ActionResult AddMusic(Music music)
        {
            if (music == null)
            {
                throw new ArgumentNullException(nameof(music));
            }
            music.PublishedDate = music.PublishedDate.Date;
            _context.MusicDetails.Add(music);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Addmusic()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var music = _context.MusicDetails.Find(id);
            return View(music);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var music = _context.MusicDetails.Find(id);
            return View(music);
        }

        [HttpPost]
        public ActionResult Edit(Music music)
        {
            if(music == null)
            {
                throw new ArgumentNullException(nameof(music));
            }
            var existingMusic = _context.MusicDetails.Find(music.MusicId);
            if (existingMusic == null)
            {
                throw new ArgumentNullException(nameof(existingMusic));
            }
            existingMusic.MusicName = music.MusicName;
            existingMusic.Author = music.Author;
            existingMusic.PublishedDate = music.PublishedDate;
            existingMusic.IsActive = music.IsActive;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var music = _context.MusicDetails.Find(id);
            return View(music);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteMusic(int id)
        {
            var music = _context.MusicDetails.Find(id);
            _context.Remove(music);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }

    public class SecuredController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["UserName"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                    { "controller", "User" },
                    { "action", "Login" }
                    });
            }

            base.OnActionExecuting(filterContext);
        }
    }

}