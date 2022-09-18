using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Movie.Queries.GetMovieByName
{
    public class GetMovieByNameHandler : IRequestHandler<GetMovieByName, MovieVM>
    {
        private readonly IUnitOfWork _unitOfWorkRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public GetMovieByNameHandler(IUnitOfWork unitOfWorkRepository, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
            _configuration = configuration;

        }
        public async Task<MovieVM> Handle(GetMovieByName request, CancellationToken cancellationToken)
        {

            var Key = _configuration["IMDBApiKey"];
            var url = $"https://imdb-api.com/API/Search/{Key}/{request.MovieName}";
            return await RequestHelper.SendHttpWebRequest<MovieVM>(url);
        }
    }
}
