using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieBackLogFramework.Models
{
    public interface IBackLogContext : IDisposable
    {
        DbSet<Movie> Movies { get; }
        DbSet<BackLog> BackLogs { get; }
        DbSet<ApplicationUser> Users { get; }
        int SaveChanges();
        void MarkAsModifed(BackLog log);
    }
}