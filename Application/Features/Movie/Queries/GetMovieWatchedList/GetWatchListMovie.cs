using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movie.Queries.GetMovieWatchedList
{
    public class GetWatchListMovie : IRequest<List<MovieWatchedListVM>>
    {
        public int UserId { get; set; }
    }
}
