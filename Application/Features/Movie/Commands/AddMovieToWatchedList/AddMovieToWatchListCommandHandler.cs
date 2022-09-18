using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Movie.Commands
{
    public class AddMovieToWatchListCommandHandler : IRequestHandler<AddMovieToWatchListCommand>
    {
        private readonly IUnitOfWork _unitOfWorkRepository;
        private readonly IMapper _mapper;

        public AddMovieToWatchListCommandHandler(IUnitOfWork unitOfWorkRepository, IMapper mapper)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(AddMovieToWatchListCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddMovieToWatchListCommandValidator(_unitOfWorkRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            //todo Check if movie already exist

            var watchlist = _mapper.Map<WatchList>(request);
            await _unitOfWorkRepository.WatchListRepository.AddAsync(watchlist);

            return Unit.Value;
        }
    }
}
