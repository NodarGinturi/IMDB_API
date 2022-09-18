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
    public class MovieWatchListRepository : BaseRepository<WatchList>, IMovieWatchListRepository
    {
        public MovieWatchListRepository(ApplicationDbContext applicationDb) : base(applicationDb)
        {

        }

        public async Task<WatchList> WatchedListAsync(int UserId, string movieId)
        {
            return await _dbContext.WatchList.Where(x => x.UserId == UserId && x.MovieId == movieId).FirstOrDefaultAsync();
        }

        public async Task<List<WatchList>> WatchedListAsync(int UserId)
        {
            return await _dbContext.WatchList.Where(x => x.UserId == UserId).ToListAsync();
        }

    }
}
