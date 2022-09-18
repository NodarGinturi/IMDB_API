using Application.Features.Movie.Commands;
using Application.Features.Movie.Queries.GetMovieByName;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WatchList, AddMovieToWatchListCommand>().ReverseMap();
            CreateMap<WatchList, UpdateMovieWatchedListComand>().ReverseMap();
            CreateMap<MovieVM, GetMovieByName>().ReverseMap();
        }
    }
}
