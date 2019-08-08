using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieBackLogFramework.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public int MovieId { get; set; }
        public int ReleaseYear { get; set; }
        public int RunningTime { get; set; }
        public virtual ICollection<BackLog> BackLogs { get; set; }
    }
}