using MovieBackLogFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBackLogFramework.Tests
{
    class TestBackLogAppContext : IBackLogContext
    {
        public TestBackLogAppContext() {
            // Add TestDbSets here
            this.BackLogs = new TestBackLogDbSet();
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<BackLog> BackLogs { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }

        public void Dispose(){}

        public void MarkAsModifed(BackLog log){}

        public int SaveChanges()
        {
            return 0;
        }
    }
}
