using MovieBackLogFramework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieBackLogFramework.DTOS
{
    public class MovieDto
    {
        
        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1900,3000)]
        public int ReleaseYear { get; set; }

        [Required]
        public int RunningTime { get; set; }

        [Required]
        public ICollection<Genre> Genres { get; set; }

        public int MovieId { get; set; }

        
    }
}