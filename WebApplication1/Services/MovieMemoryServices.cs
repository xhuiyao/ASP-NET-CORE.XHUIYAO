using CoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public class MovieMemoryServices:IMovieServices
    {
        private readonly List<Movie> _movies = new List<Movie>();
        public MovieMemoryServices()
        {
            _movies.Add(new Movie
            {
                CinemaId = 1,
                Id = 1,
                Name = "Superman",
                ReleasDate = new DateTime(2018, 10, 1),
                Starring = "Nick"
            });
            _movies.Add(new Movie
            {
                CinemaId = 1,
                Id = 2,
                Name = "Ghost",
                ReleasDate = new DateTime(1997, 5, 4),
                Starring = "Michael Jackson"
            });
            _movies.Add(new Movie
            {
                CinemaId = 1,
                Id = 3,
                Name = "Ghost",
                ReleasDate = new DateTime(1997, 5, 4),
                Starring = "Michael Jackson"
            });
            _movies.Add(new Movie
            {
                CinemaId = 2,
                Id = 4,
                Name = "Fight",
                ReleasDate = new DateTime(2018, 12, 3),
                Starring = "Tommy"
            });
        }

        public Task AddAsync(Movie model)
        {
            var maxId = _movies.Max(x => x.Id);
            model.Id = maxId + 1;
            _movies.Add(model);
            return Task.CompletedTask;
        }



        public Task<Movie> GetMoviesById(int Id)
        {
            return Task.Run(() => _movies.FirstOrDefault(x => x.Id == Id));
        }

        public Task<IEnumerable<Movie>> GetByCinemaAsync(int cinemaId)
        {
            return Task.Run(() => _movies.Where(x => x.CinemaId == cinemaId));
        }

        public Task EditAsync(Movie model)
        {
            //var models = _movies.Where(x => x.Id == model.Id);
            int indexnum = _movies.FindIndex(x => x.Id == model.Id);
            _movies[indexnum] = model;
            return Task.CompletedTask;
        }
    }
}
