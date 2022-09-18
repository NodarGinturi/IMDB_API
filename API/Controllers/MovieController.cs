using Application.Features.Movie.Commands;
using Application.Features.Movie.Queries.GetMovieByName;
using Application.Features.Movie.Queries.GetMovieWatchedList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    //[ApiController]
    //[Route("api/")]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Retrieves Films List From IMDB
        /// </summary>
        //[Route("films")]
        [HttpGet("movieByName")]
        public async Task<ActionResult<MovieVM>> movieByName(GetMovieByName movie)
        {
            var dto = await _mediator.Send(movie);
            return Ok(dto);
        }
        /// <summary>
        /// Adds Films To Watchlist
        /// </summary>
        //[Route("watchlist/film/{FilmId}")]
        [HttpPost("addMovieToWatchlist")]
        public async Task<IActionResult> addMovieToWatchlist(AddMovieToWatchListCommand addMovieToWatchListCommand)
        {
            var dto = await _mediator.Send(addMovieToWatchListCommand);
            return Ok(dto);
        }
        /// <summary>
        /// Adds Films To A Users Watchlist
        /// </summary>
        //[Route("watchlist/films/{UserId}")]
        [HttpGet("watchlistFilms")]
        public async Task<ActionResult<IEnumerable<MovieWatchedListVM>>> watchlistFilms(GetWatchListMovie watchListMovie)
        {
            var dto = await _mediator.Send(watchListMovie);
            return Ok(dto);
        }
        /// <summary>
        /// Changes A Film Status From Users Watchlist 
        /// </summary>
        //[Route("watchlist/films/{UserId}/{FilmId}/{IsWatched}")]
        [HttpPost("GetWatchlistFilmListForUser")]
        public async Task<IActionResult> GetWatchlistFilmListForUser(UpdateMovieWatchedListComand updateMovieWatchedList)
        {
            var dto = await _mediator.Send(updateMovieWatchedList);
            return Ok(dto);
        }
    }
}
