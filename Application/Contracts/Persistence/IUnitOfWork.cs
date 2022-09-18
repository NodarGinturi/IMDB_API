using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        IMovieRepository MovieRepository { get; }
        IMovieWatchListRepository WatchListRepository { get; }
        ISuggestedMovieRepository SuggestedMovieRepository { get; }
        IEmailService EmailService { get; }
    }
}
