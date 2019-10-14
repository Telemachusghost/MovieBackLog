using Microsoft.AspNet.Identity;
using MovieBackLogFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace MovieBackLogFramework.Controllers
{
    public class MoviesController : Controller
    {

        private IBackLogContext _context = new MovieLogAppContext();
        private IIdentity _userId;

        public MoviesController() { }

        // Constructor for testing
        public MoviesController(IBackLogContext context, IIdentity userId)
        {

            _context = context;
            _userId = userId;

        }
        // GET: Movies
        public ActionResult Index()
        {
            string userId;
            if (_userId == null)
            {
                userId = User.Identity.GetUserId();
            }
            else
            {
                userId = _userId.Name;
            }

            ViewBag.userId = userId;

            return View();
        }
    }
}