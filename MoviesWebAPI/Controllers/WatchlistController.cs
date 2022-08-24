using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWebAPI.Data.Requests.Watchlist;
using MoviesWebAPI.Data.Responses.Watchlist;
using MoviesWebAPI.Services.Watchlist;
using MoviesWebAPI.Utils;

namespace MoviesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchlistController : ControllerBase
    {
        public IWatchlistService _service { get; set; }

        public WatchlistController(IWatchlistService service)
        {
            _service = service;
        }

        /// <summary>
        /// This gets all user's watchlist from database as a list
        /// </summary>
        /// <response code="200">All user's watchlist were successfuly found and send from database</response>
        /// <response code="300">All user's watchlist from database couldn't be send</response>
        /// <response code="400">Some error happened at backend level and returned an exception</response>
        /// <returns></returns>
        [HttpGet,Route("get-all-users-watchlist")]
        public async Task<IActionResult> GetAllUsersWatchlist()
        {
            try
            {
                AllUsersWatchlistResponse response = await _service.GetAllUsersWatchlist();

                return Ok(response);
            }
            catch (Exception ex)
            {
                AllUsersWatchlistResponse error = new AllUsersWatchlistResponse
                {
                    Code = 400,
                    Message = APIErrorCodes.GET_ALL_USERS_WATCHLIST_EXCEPTION_MESSAGE + ex.Message
                };

                return BadRequest(error);
            }
        }

        /// <summary>
        /// This gets user's watchlist by its UserID
        /// </summary>
        /// <response code="200">User's watchlist with given UserID were successfully found and send from database</response>
        /// <response code="300">User's ID is missing from header</response>
        /// <response code="301">User with given ID doesn't exist in database</response>
        /// <response code="302">Get user's watchlist with given userID was unsuccessfull</response>
        /// <response code="400">Some error happened at backend level and returned an exception</response>
        /// <param name="userID"></param>
        /// <returns></returns>
        [HttpGet,Route("get-user-watchlist-by-id")]
        public async Task<IActionResult> GetUserWatchlistByID([FromHeader] int? userID)
        {
            if(userID == null)
            {
                UserWatchlistResponse nullError = new UserWatchlistResponse
                {
                    Code = 300,
                    Message = APIErrorCodes.HEADER_MISSING_MESSAGE + "userID"
                };

                return BadRequest(nullError);
            }

            try
            {
                UserWatchlistResponse response = await _service.GetUserWatchlistByID(userID);

                return Ok(response);
            }
            catch (Exception ex)
            {
                UserWatchlistResponse Error = new UserWatchlistResponse
                {
                    Code = 400,
                    Message = APIErrorCodes.GET_USER_WATCHLIST_BY_USERID_EXCEPTION_MESSAGE + ex.Message
                };

                return BadRequest(Error);
            }
        }

        /// <summary>
        /// This gets user's watchlist by its Username
        /// </summary>
        /// <response code="200">User's watchlist with given username was successfully found and send from database</response>
        /// <response code="300">User's username is missing from header</response>
        /// <response code="301">User with given name doesn't exist in database</response>
        /// <response code="302">Get user's watchlist with given username was unsuccessfull</response>
        /// <response code="400">Some error happened at backend level and returned an exception</response>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet,Route("get-user-watchlist-by-username")]
        public async Task<IActionResult> GetUserWatchlistByUsername([FromHeader] string? userName)
        {
            if (String.IsNullOrEmpty(userName))
            {
                UserWatchlistResponse nullError = new UserWatchlistResponse
                {
                    Code = 300,
                    Message = APIErrorCodes.HEADER_MISSING_MESSAGE + "username"
                };

                return BadRequest(nullError);
            }

            try
            {
                UserWatchlistResponse response = await _service.GetUserWatchlistByUsername(userName);

                return Ok(response);
            }
            catch (Exception ex)
            {
                UserWatchlistResponse Error = new UserWatchlistResponse
                {
                    Code = 400,
                    Message = APIErrorCodes.GET_USER_WATCHLIST_BY_USERNAME_EXCEPTION_MESSAGE + ex.Message
                };

                return BadRequest(Error);
            }
        }

        /// <summary>
        /// This adds the given movie to the given user's watchlist by their IDs
        /// </summary>
        /// <response code="200">Given movie was successfully added to given user's watchlist</response>
        /// <response code="300">User's ID is missing from body</response>
        /// <response code="301">Movie's ID is missing from body</response>
        /// <response code="302">User with given ID doesn't exist in database</response>
        /// <response code="303">Movie with given ID doesn't exist in database</response>
        /// <response code="304">Couldn't add movie to user's watchlist</response>
        /// <response code="400">Some error happened at backend level and returned an exception</response>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost,Route("add-movie-to-watchlist")]
        public async Task<IActionResult> AddMovieToWatchlist([FromBody] WatchlistRequest request)
        {
            if(request.UserID == null)
            {
                UserWatchlistResponse nullError = new UserWatchlistResponse
                {
                    Code = 300,
                    Message = APIErrorCodes.BODY_MISSING_MESSAGE + "userID"
                };

                return BadRequest(nullError);
            }

            if(request.MovieID == null)
            {
                UserWatchlistResponse nullError = new UserWatchlistResponse
                {
                    Code = 301,
                    Message = APIErrorCodes.BODY_MISSING_MESSAGE + "movieID"
                };

                return BadRequest(nullError);
            }

            try
            {
                UserWatchlistResponse response = await _service.AddNewMovieToWatchlist(request);

                return Ok(response);
            }
            catch(Exception ex)
            {
                UserWatchlistResponse Error = new UserWatchlistResponse
                {
                    Code = 400,
                    Message = APIErrorCodes.ADD_MOVIE_TO_WATCHLIST_EXCEPTION_MESSAGE + ex.Message
                };

                return BadRequest(Error);
            }
        }

        /// <summary>
        /// This deletes given movie from given user's watchlist by their IDs
        /// </summary>
        /// <response code="200">Given movie was successfully deleted from given user's watchlist</response>
        /// <response code="300">User's ID is missing from body</response>
        /// <response code="301">Movie's ID is missing from body</response>
        /// <response code="302">User with given ID doesn't exist in database</response>
        /// <response code="303">Movie with given ID doesn't exist in database</response>
        /// <response code="304">Couldn't delete movie from user's watchlist</response>
        /// <response code="400">Some error happened at backend level and returned an exception</response>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete,Route("delete-movie-from-watchlist")]
        public async Task<IActionResult> DeleteMovieFromWatchlist([FromBody] WatchlistRequest request)
        {
            if (request.UserID == null)
            {
                UserWatchlistResponse nullError = new UserWatchlistResponse
                {
                    Code = 300,
                    Message = APIErrorCodes.BODY_MISSING_MESSAGE + "userID"
                };

                return BadRequest(nullError);
            }

            if (request.MovieID == null)
            {
                UserWatchlistResponse nullError = new UserWatchlistResponse
                {
                    Code = 301,
                    Message = APIErrorCodes.BODY_MISSING_MESSAGE + "movieID"
                };

                return BadRequest(nullError);
            }

            try
            {
                UserWatchlistResponse response = await _service.DeleteMovieFromWatchlist(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                UserWatchlistResponse Error = new UserWatchlistResponse
                {
                    Code = 400,
                    Message = APIErrorCodes.DELETE_MOVIE_FROM_WATCHLIST_EXCEPTION_MESSAGE + ex.Message
                };

                return BadRequest(Error);
            }
        }
    }
}
