using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IMovieWatchListRepository : IAsyncRepository<WatchList>
    {
        Task<WatchList> WatchedListAsync(int UserId, string movieId);
        Task<List<WatchList>> WatchedListAsync(int UserId);
    }
}
