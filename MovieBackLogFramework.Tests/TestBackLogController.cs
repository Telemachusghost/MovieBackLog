using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieBackLogFramework.Models;
using MovieBackLogFramework.Controllers;
using System.Web.Mvc;

namespace MovieBackLogFramework.Tests
{
    /// <summary>
    /// Summary description for TestBackLogController
    /// </summary>
    [TestClass]
    public class TestBackLogController
    {
        private TestBackLogAppContext _context;
        private TestIdentity ident;
        private BackLogController controller;
        public TestBackLogController()
        {
            _context = new TestBackLogAppContext();
            ident = new TestIdentity("derick", "user", "123", true);
            controller = new BackLogController(_context, ident);
        }


        [TestMethod] 
        public void BackLogControllerGivesView()
        {
            System.Web.Mvc.ActionResult result = controller.Index();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BackLogControllerGivesViewUserId()
        {
            ViewResult result = controller.Index() as ViewResult;

            var userId = result.ViewBag.userId;
            Assert.IsNotNull(userId);
            Assert.AreEqual("derick", userId);

        }





    }
}
