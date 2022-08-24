using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWebAPI.Data.Responses.Movies;
using MoviesWebAPI.Services.Movies;
using MoviesWebAPI.Utils;

namespace MoviesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public IMovieService _service { get; set; }

        public MoviesController(IMovieService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves all mvoies and their datas from database
        /// </summary>
        /// <response code="200">All movies were successfully send</response>
        /// <response code="300">Movies list couldn't be send</response>
        /// <response code="400">Some error happened at backend level and returned an exception</response>
        /// <returns></returns>
        [HttpGet,Route("get-all-movies")]
        public async Task<IActionResult> GetAllMovies()
        {
            try
            {
                AllMoviesResponse response = await _service.GetAllMovies();

                return Ok(response);

            }catch (Exception ex)
            {
                AllMoviesResponse error = new AllMoviesResponse
                {
                    Code = 400,
                    Message = APIErrorCodes.GET_ALL_MOVIES_EXCEPTION_MESSAGE + ex.Message
                };

                return BadRequest(error);
            }
        }

        /// <summary>
        /// This gets movie's data by its ID
        /// </summary>
        /// <response code="200">Movie with given ID was successfully found.It retreives its data</response>
        /// <response code="300">Movie's ID is missing from header</response>
        /// <response code="301">Movie with given ID doesn't exist in database</response>
        /// <response code="400">Some error happened at backend level and returned an exception</response>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet,Route("get-movie-by-id")]
        public async Task<IActionResult> GetMovieById([FromHeader] int? id)
        {
            if(id == null)
            {
                MovieResponse nullHeader = new MovieResponse
                {
                    Code = 300,
                    Message = APIErrorCodes.HEADER_MISSING_MESSAGE + "id"
                };
                return BadRequest(nullHeader);
            }

            try
            {
                MovieResponse movieResponse = await _service.GetMovieById(id);

                return Ok(movieResponse);
            }catch(Exception ex)
            {
                MovieResponse error = new MovieResponse
                {
                    Code = 400,
                    Message = APIErrorCodes.GET_MOVIE_BY_ID_EXCEPTION_MESSAGE + ex.Message
                };

                return BadRequest(error);
            }
        }

        /// <summary>
        /// This is the search feature of the web
        /// </summary>
        /// <response code="200">Movie(s) that contains the given title in their title were successfully found and retreived as a list</response>
        /// <response code="300">Movie's title is missing from header</response>
        /// <response code="301">Movie with given title doesn't exist in database</response>
        /// <response code="400">Some error happened at backend level and returned an exception</response>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpGet,Route("get-movies-by-title")]
        public async Task<IActionResult> GetMoviesByTitle([FromHeader] string? title)
        {
            if(title == null)
            {
                AllMoviesResponse nullHeader = new AllMoviesResponse
                {
                    Code = 300,
                    Message = APIErrorCodes.HEADER_MISSING_MESSAGE + "title"
                };

                return BadRequest(nullHeader);
            }

            try
            {
                AllMoviesResponse response = await _service.GetMoviesByTitle(title);

                return Ok(response);

            }catch(Exception ex)
            {
                AllMoviesResponse error = new AllMoviesResponse
                {
                    Code = 400,
                    Message = APIErrorCodes.GET_MOVIES_BY_TITLE_EXCEPTION_MESSAGE + ex.Message
                };

                return BadRequest(error);
            }
        }
    }
}
