using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movie.Queries.GetMovieWatchedList
{
    public class MovieWatchedListVM
    {
        public string Id { get; set; }
        public string Title { set; get; }
        public bool IsWatched { set; get; }
    }
}
