using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Movie.Queries.GetMovieWatchedList
{
    public class GetWatchListMovieHandler : IRequestHandler<GetWatchListMovie, List<MovieWatchedListVM>>
    {
        private readonly IUnitOfWork _unitOfWorkRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public GetWatchListMovieHandler(IUnitOfWork unitOfWorkRepository, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<List<MovieWatchedListVM>> Handle(GetWatchListMovie request, CancellationToken cancellationToken)
        {
            var movies = (await _unitOfWorkRepository.WatchListRepository.WatchedListAsync(request.UserId));
            List<MovieWatchedListVM> result = new List<MovieWatchedListVM>();
            
            foreach (var movie in movies)
            {
                result.Add(await GetFilmDetailedInformation(movie.MovieId, movie.UserId));
            }
            return result;
        }

        public async Task<MovieWatchedListVM> GetFilmDetailedInformation(string movieId, int userId)
        {
            var Key = _configuration["IMDBApiKey"];
            var url = $"https://imdb-api.com/API/Title/{Key}/{movieId}/Posters,Ratings,Wikipedia";
            return await RequestHelper.SendHttpWebRequest<MovieWatchedListVM>(url);
        }
    }
}
