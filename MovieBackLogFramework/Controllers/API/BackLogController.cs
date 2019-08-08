using AutoMapper;
using MovieBackLogFramework.DTOS;
using MovieBackLogFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieBackLogFramework.Controllers.API
{
    public class BackLogController : ApiController
    {
        private ApplicationDbContext _context;
        private IMapper mapper;

        public BackLogController()
        {
            _context = new ApplicationDbContext();

            // Create instance config for automapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Movie, MovieDto>();
                cfg.CreateMap<MovieDto, Movie>().ForMember(src => src.MovieId, opt => opt.Ignore());
            });
            // Init mapper
            mapper = config.CreateMapper();

        }
        
        // GET /api/backlog/userid
        [Route("api/backlog/{userId}")]
        public IEnumerable<MovieDto> GetMovies(string userId)
        {

            dynamic movies2;
            var movies = _context.Users.Where(u => u.Id == userId)
                                         .Select(u => u.BackLog)
                                         .SingleOrDefault();
            if (movies == null)
            {
                movies2 = new List<MovieDto>();
            }
            else
            {
                movies2 = movies.Movies.Select(movie => mapper.Map<MovieDto>(movie));
            }
            
            return movies2;
        }

        
    }
}
