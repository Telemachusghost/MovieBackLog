using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieBackLogFramework.Models
{
    public class MovieLogAppContext : DbContext, IBackLogContext
    {
        public MovieLogAppContext() : base("DefaultConnection")
        {
        }



        public virtual DbSet<Movie> Movies { get; set; }
        //public DbSet<ApplicationUser> Users {get; set;}
        public virtual DbSet<BackLog> BackLogs { get; set; }

        // For put function
        public void MarkAsModifed(BackLog log)
        {
            Entry(log).State = EntityState.Modified;
        }
    }

}