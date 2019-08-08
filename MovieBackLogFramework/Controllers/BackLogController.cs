using Microsoft.AspNet.Identity;
using MovieBackLogFramework.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MovieBackLogFramework.Controllers
{
    public class BackLogController : Controller
    {
        private IBackLogContext _context = new MovieLogAppContext();

        public BackLogController() { }

        public BackLogController(IBackLogContext context)
        {
            _context = context;
        }

        // GET: BackLog
        public ActionResult Index()
        {   
            // TODO: Decouple this for testing
            var userId = User.Identity.GetUserId();

            // TODO: Viewmodel
            ViewBag.userId = userId;
            
            return View();
        }
    }
}