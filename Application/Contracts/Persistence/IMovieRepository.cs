using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IMovieRepository : IAsyncRepository<Movie>
    {
        Task<Movie> MovieByNameAsync(string Name);
        Task<Movie> GetMovieByIdAsync(string movieId);
        Task<List<User>> GetAllUsersAsync();
    }
}
