using AutoMapper;
using MovieBackLogFramework.DTOS;
using MovieBackLogFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace MovieBackLogFramework.Controllers.API
{
    public class BackLogController : ApiController
    {
        private MovieLogAppContext _context;
        private ApplicationDbContext _context2;
        private IMapper mapper;

        public BackLogController()
        {
            _context = new MovieLogAppContext();
            _context2 = new ApplicationDbContext();

            // Create instance config for automapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Movie, MovieDto>();
            });
            // Init mapper
            mapper = config.CreateMapper();

        }

        // GET /api/backlog/userid
        [Route("api/backlog/{userId}")]
        public IEnumerable<MovieDto> GetMovies(string userId)
        {

            dynamic backlog2;
            var backlog = retreiveBacklog(userId);
            if (backlog == null)
            {
                backlog2 = new List<MovieDto>();
            }
            else
            {
                backlog2 = backlog.Movies.Select(movie => mapper.Map<MovieDto>(movie));
            }

            return backlog2;
        }

        // GET /api/backlog/movies
        [Route("api/backlog/movies")]
        public IEnumerable<MovieDto> GetAllMovies()
        {

            var movies = _context.Movies.Include(m => m.Genres).ToList();
            var moviesDto = movies.Select(movie => mapper.Map<MovieDto>(movie));
            return moviesDto;
        }

        [HttpDelete]
        [Route("api/backlog/{id}/{userId}")]
        public IHttpActionResult DeleteMovie(int id, string userId)
        {

            var backlog = retreiveBacklog(userId);
            var movieInDb = backlog.Movies.SingleOrDefault(c => c.MovieId == id);
            
            backlog.Movies.Remove(movieInDb);
            _context2.SaveChanges();

            return Ok();
        }

        // Essentially I add a movie to users backlog by creating a new movie and changing the navigation properties over
        [HttpPost]
        [Route("api/backlog/add/{id}/{userId}")]
        public IHttpActionResult AddMovie(int id, string userId)
        {
            Movie movieInDb = _context.Movies.Include(m => m.Genres).SingleOrDefault(m => m.MovieId == id);
            BackLog backlog = retreiveBacklog(userId);
            List < Genre > genres = new List<Genre>();
            
            if (movieInDb == null)
                return NotFound();

            Movie movie = new Movie();
            movie.ReleaseYear = movieInDb.ReleaseYear;
            movie.Title = movieInDb.Title;
            movie.RunningTime = movieInDb.RunningTime;
            
            backlog.Movies.Add(movie);
            _context2.SaveChanges();
            

            // Add genre(s) to new movie by changing movieId from old movie to new movie
            foreach (var genre in movieInDb.Genres.ToList())
            {
                Genre gen = new Genre() {Name = genre.Name};
                genres.Add(gen);
            }

            movie.Genres = genres;
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            _context2.SaveChanges();
            

            return Ok();

        }

        private BackLog retreiveBacklog(string userId)
        {
            return _context2.Users.Where(u => u.Id == userId)
                                         .Select(u => u.BackLog)
                                         .Include(u => u.Movies.Select(m => m.Genres))
                                         .SingleOrDefault();
        }
    }
} 
