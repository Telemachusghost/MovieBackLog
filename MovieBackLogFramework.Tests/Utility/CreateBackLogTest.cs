using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieBackLogFramework.Controllers.BacklogManager;
using MovieBackLogFramework.Models;

namespace MovieBackLogFramework.Tests.Utility
{
    [TestClass]
    public class CreateBackLogTest
    {
        [TestMethod]
        public void CreateBackLogReturnsBackLog()
        {

            BacklogManage backLogManager = new BacklogManage(new TestBackLogAppContext());
            BackLog backlog = backLogManager.CreateBackLog();
            Assert.IsNotNull(backlog);
        }

        [TestMethod]
        public void CreateBackLogAddsBackLog()
        {
            var backlogs = new TestBackLogAppContext();
            BacklogManage backLogManager = new BacklogManage(backlogs);
            BackLog backlog = backLogManager.CreateBackLog();

            Assert.AreEqual(backlogs.BackLogs.Local.Count,1);
        }
    }
}
