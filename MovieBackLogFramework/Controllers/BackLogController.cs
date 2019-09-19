using Microsoft.AspNet.Identity;
using MovieBackLogFramework.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MovieBackLogFramework.Controllers
{
    public class BackLogController : Controller
    {
        private IBackLogContext _context = new MovieLogAppContext();
        private IIdentity _userId;

        public BackLogController() {}

        // Constructor for testing
        public BackLogController(IBackLogContext context,IIdentity userId)
        {
            
            _context = context;
            _userId = userId;
            
        }

        // GET: BackLog
        public ActionResult Index()
        {
            // This is hacky because I dont know how to mock GetUserId since its an extension method
            string userId;
            if (_userId == null)
            {
                userId = User.Identity.GetUserId();
            } else
            {
                userId = _userId.Name;
            }
                
            // TODO: Viewmodel
            ViewBag.userId = userId;
            
            return View();
        }
    }
}