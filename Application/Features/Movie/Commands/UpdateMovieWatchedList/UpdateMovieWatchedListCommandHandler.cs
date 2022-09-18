using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Movie.Commands.UpdateMovieWatchedList
{
    public class UpdateMovieWatchedListCommandHandler : IRequestHandler<UpdateMovieWatchedListComand>
    {

        private readonly IUnitOfWork _unitOfWorkRepository;
        private readonly IMapper _mapper;

        public UpdateMovieWatchedListCommandHandler(IUnitOfWork unitOfWorkRepository, IMapper mapper)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateMovieWatchedListComand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMovieWatchedListComandValidator(_unitOfWorkRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var watchList = await _unitOfWorkRepository.WatchListRepository.WatchedListAsync(request.UserId,request.MovieId);
            watchList.IsWatched = true;
            await _unitOfWorkRepository.WatchListRepository.UpdateAsync(watchList);

            return Unit.Value;
        }
    }
}
