using System.Collections.Generic;

namespace Application.Features.Movie.Queries.GetMovieByName
{
    public class MovieVM
    {
        public string SearchType { get; set; }
        public string Expression { get; set; }

        public List<MovieSearchResult> Results { get; set; }

        public string ErrorMessage { get; set; }
    }
}
