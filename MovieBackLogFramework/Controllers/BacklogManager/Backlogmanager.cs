using MovieBackLogFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MovieBackLogFramework.Controllers.BacklogManager
{
    public class BacklogManage
    {
        
        private IBackLogContext _context;

        public BacklogManage(IBackLogContext context)
        {
            _context = context;
        }

        public BackLog CreateBackLog()
        {
            BackLog backlog = new BackLog();
            _context.BackLogs.Add(backlog);
            _context.SaveChanges();
            return backlog;
        }
    }
}