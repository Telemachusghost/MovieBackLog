using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieBackLogFramework.Models
{
    public class BackLog
    {
        public virtual int Id { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}