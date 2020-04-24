using CoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public interface ICinemaServices
    {
        Task<IEnumerable<Cinema>> GetllallAsync();
        Task<Cinema> GetByIdAsync(int id);
        Task<Sales> GetSalesAsync();
        Task AddAsync(Cinema model);
        Task EditAsync(Cinema cinema);
    }
}
