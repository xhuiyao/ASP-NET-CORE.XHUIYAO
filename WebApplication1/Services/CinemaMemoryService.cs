using CoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public class CinemaMemoryService : ICinemaServices
    {
        private readonly List<Cinema> _cinemas = new List<Cinema>();
        public CinemaMemoryService()
        {
            _cinemas.Add(new Cinema
            {
                Id = 1,
                Name = "City Cinema",
                Location = "Road ABC,No.123",
                Capacity = 1000

            }); ;
            _cinemas.Add(new Cinema
            {
                Id = 2,
                Name = "Fly Cinema",
                Location = "Road Hello,No.123",
                Capacity = 500

            });
        }
        public Task<IEnumerable<Cinema>> GetllallAsync()
        {
            return Task.Run(() => _cinemas.AsEnumerable());
        }
        public Task<Cinema> GetByIdAsync(int id)
        {
            return Task.Run(() => _cinemas.FirstOrDefault(x => x.Id == id));
        }

        public Task<Sales> GetSalesAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Cinema model)
        {
            var maxId = _cinemas.Max(x => x.Id);
            model.Id = maxId + 1;
            _cinemas.Add(model);
            return Task.CompletedTask;
        }

        public Task EditAsync(Cinema cinema)
        {
            int indexofn = _cinemas.FindIndex(x => x.Id == cinema.Id);
            _cinemas[indexofn] = cinema;
            return Task.CompletedTask;

        }
    }
}
