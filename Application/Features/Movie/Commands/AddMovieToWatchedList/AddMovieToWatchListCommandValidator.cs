using Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movie.Commands
{
    public class AddMovieToWatchListCommandValidator : AbstractValidator<AddMovieToWatchListCommand>
    {
        private readonly IUnitOfWork _unitOfWorkRepository;

        public AddMovieToWatchListCommandValidator(IUnitOfWork unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;


            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId  is not valid");

            RuleFor(x => x.MovieId)
                .NotEmpty()
                .MinimumLength(1)
                .WithMessage("MovieId  is not valid");
        }
    }
}
