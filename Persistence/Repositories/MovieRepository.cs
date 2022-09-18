using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext applicationDb) : base(applicationDb)
        {

        }

        public async Task<Movie> MovieByNameAsync(string Name)
        {
            return await _dbContext.Movie.Where(x=>x.Title == Name).FirstOrDefaultAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(string movieId)
        {
            return await _dbContext.Movie.Where(x => x.Id == movieId).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _dbContext.User.ToListAsync();
        }
    }
}
