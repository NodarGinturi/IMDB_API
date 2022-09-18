using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movie.Queries.GetMovieByName
{
    public class MovieSearchResult
    {
        public string Id { get; set; }
        public string ResultType { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
