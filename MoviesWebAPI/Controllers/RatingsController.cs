using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWebAPI.Data;
using MoviesWebAPI.Data.Requests.Ratings;
using MoviesWebAPI.Data.Responses.Ratings;
using MoviesWebAPI.Repositories.Users;
using MoviesWebAPI.Services.Ratings;
using MoviesWebAPI.Services.Users;
using MoviesWebAPI.Utils;

namespace MoviesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        public IRatingsService _service { get; set; }
        public RatingsController(IRatingsService service)
        {
            _service = service;
        }

        /// <summary>
        ///  This gets all ratings from database
        /// </summary>
        /// <response code="200">Ratings were successfully send</response>
        /// <response code="300">Get all ratings was unsuccessfull</response>
        /// <response code="400">Some error happened at backend level and returned an exception</response>
        /// <returns></returns>
        [HttpGet, Route("get-all-ratings")]
        public async Task<IActionResult> GetAllRatings()
        {
            try
            {
                AllRatingsResponse response = await _service.GetAllRatings();
                return Ok(response);
            }
            catch (Exception ex)
            {
                AllRatingsResponse error = new AllRatingsResponse
                {
                    Code = 400,
                    Message = APIErrorCodes.GET_ALL_RATINGS_EXCEPTION_MESSAGE + ex.Message
                };
                return BadRequest(error);
            }
        }

        /// <summary>
        /// This adds a new rating to given movie by given user by their IDs
        /// </summary>
        /// <response code= "200">Rating was successfully added</response>
        /// <response code="300">User's ID is missing from body</response>
        /// <response code="301">Movie's ID is missing from body</response>
        /// <response code="302">Rating is missing from body</response>
        /// <response code="303">Given rating value is not in [1,10] range</response>
        /// <response code="304">User with given ID doesn't exist in database</response>
        /// <response code="305">Movie with given ID doesn't exist in database</response>
        /// <response code="306">Add new rating was unsuccessfull</response>
        /// <response code="400">Some error happened at backend level and returned an exception</response>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost, Route("add-new-rating")]
        public async Task<IActionResult> AddNewRating([FromBody] RatingRequest request)
        {
            if (request.UserId == null)
            {
                RatingResponse nullError = new RatingResponse
                {
                    Code = 300,
                    Message = APIErrorCodes.BODY_MISSING_MESSAGE + "userID"
                };

                return BadRequest(nullError);
            }

            if (request.MovieId == null)
            {
                RatingResponse nullError = new RatingResponse
                {
                    Code = 301,
                    Message = APIErrorCodes.BODY_MISSING_MESSAGE + "movieID"
                };

                return BadRequest(nullError);
            }

            if (request.Rating == null)
            {
                RatingResponse nullError = new RatingResponse
                {
                    Code = 302,
                    Message = APIErrorCodes.BODY_MISSING_MESSAGE + "rating"
                };

                return BadRequest(nullError);
            }

            if (!(request.Rating >= 1 && request.Rating <= 10))
            {
                RatingResponse ratingError = new RatingResponse
                {
                    Code = 303,
                    Message = APIErrorCodes.INVALID_RATING_VALUE_RANGE_MESSAGE
                };

                return BadRequest(ratingError);
            }

            try
            {
                RatingResponse response = await _service.AddNewRating(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                RatingResponse error = new RatingResponse
                {
                    Code = 400,
                    Message = APIErrorCodes.ADD_NEW_RATING_EXCEPTION_MESSAGE + ex.Message
                };

                return BadRequest(error);
            }
        }

        /// <summary>
        /// This gets given user's ratings by its UserID
        /// </summary>
        /// <response code="200">User's ratings was successfully send</response>
        /// <response code="300">User's ID is missing from body</response>
        /// <response code="301">User with given ID doesn't exist in database</response>
        /// <response code="400">Some error happened at backend level and returned an exception</response>
        /// <param name="userID"></param>
        /// <returns></returns>
        [HttpGet,Route("get-ratings-by-userid")]
        public async Task<IActionResult> GetRatingsByUserID([FromHeader] int? userID)
        {
            if(userID == null)
            {
                AllRatingsResponse nullError = new AllRatingsResponse
                {
                    Code = 300,
                    Message = APIErrorCodes.HEADER_MISSING_MESSAGE + "userID"
                };

                return BadRequest(nullError);
            }

            try
            {

                AllRatingsResponse response = await _service.GetRatingByID(userID);

                return Ok(response);

            }catch (Exception ex)
            {
                AllRatingsResponse error = new AllRatingsResponse
                {
                    Code = 400,
                    Message =APIErrorCodes.GET_RATINGS_BY_USERID_EXCEPTION_MESSAGE + ex.Message
                };

                return BadRequest(error);
            }
        }

        /// <summary>
        /// This gets given movie's ratings by its MovieID
        /// </summary>
        /// <response code="200">Ratings were successfully send</response>
        /// <response code="300">Movie's ID is missing from body</response>
        /// <response code="301">Movie with given ID doesn't exist in database</response>
        /// <response code="400">Some error happened at backend level and returned an exception</response>
        /// <param name="movieID"></param>
        /// <returns></returns>
        [HttpGet,Route("get-ratings-by-movieid")]
        public async Task<IActionResult> GetRatingsByMovieID([FromHeader] int? movieID)
        {
            if (movieID == null)
            {
                AllRatingsResponse nullError = new AllRatingsResponse
                {
                    Code = 300,
                    Message = APIErrorCodes.HEADER_MISSING_MESSAGE + "movieID"
                };

                return BadRequest(nullError);
            }

            try
            {
                AllRatingsResponse response = await _service.GetRatingByMovieId(movieID);

                return Ok(response);

            }catch (Exception e)
            {
                AllRatingsResponse error = new AllRatingsResponse
                {
                    Code = 400,
                    Message = APIErrorCodes.GET_RATINGS_BY_MOVIEID_EXCEPTION_MESSAGE + e.Message
                };

                return BadRequest(error);
            }
        }

        /// <summary>
        /// This updates user's rating to given movie by their IDs
        /// </summary>
        /// <response code="200">Rating was successfully updated</response>
        /// <response code="300">User's ID is missing from body</response>
        /// <response code="301">Movie's ID is missing from body</response>
        /// <response code="302">Rating is missing from body</response>
        /// <response code="303">Given rating value is not in [1,10] range</response>
        /// <response code="304">User with given ID doesn't exist in database</response>
        /// <response code="305">Movie with given ID doesn't exist in database</response>
        /// <response code="306">The given movie wasn't rated by the given user</response>
        /// <response code="307">Update rating was unsuccessfull</response>
        /// <response code="400">Some error happened at backend level and returned an exception</response>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut,Route("update-rating")]
        public async Task<IActionResult> UpdateRating([FromBody] RatingRequest request)
        {
            if(request.UserId == null)
            {
                RatingResponse nullError = new RatingResponse
                {
                    Code = 300,
                    Message = APIErrorCodes.BODY_MISSING_MESSAGE + "userID"
                };

                return BadRequest(nullError);
            }

            if(request.MovieId == null)
            {
                RatingResponse nullError = new RatingResponse
                {
                    Code = 301,
                    Message = APIErrorCodes.BODY_MISSING_MESSAGE + "movieID"
                };

                return BadRequest(nullError);
            }

            if(request.Rating == null)
            {
                RatingResponse nullError = new RatingResponse
                {
                    Code = 302,
                    Message = APIErrorCodes.BODY_MISSING_MESSAGE + "rating"
                };

                return BadRequest(nullError);
            }

            if (!(request.Rating >= 1 && request.Rating <= 10))
            {
                RatingResponse ratingError = new RatingResponse
                {
                    Code = 303,
                    Message = APIErrorCodes.INVALID_RATING_VALUE_RANGE_MESSAGE
                };

                return BadRequest(ratingError);
            }

            try
            {
                RatingResponse response = await _service.UpdateRating(request);

                return Ok(response);

            }catch (Exception ex)
            {
                RatingResponse error = new RatingResponse
                {
                    Code = 400,
                    Message = APIErrorCodes.UPDATE_RATING_EXCEPTION_MESSAGE + ex.Message
                };

                return BadRequest(error);
            }
        }

        /// <summary>
        /// This deletes user's rating to given movie by their IDs
        /// </summary>
        /// <remarks>
        /// Expected Body request:
        ///
        ///     
        ///     {
        ///        "userId": int,
        ///        "movieId": int
        ///     }
        ///     
        /// Ignore the example schema, use the above request for delete ratings
        /// </remarks>
        /// <response code="200">Rating was successfully deleted</response>
        /// <response code="300">User's ID is missing from body</response>
        /// <response code="301">Movie's ID is missing from body</response>
        /// <response code="302">User with given ID doesn't exist in database</response>
        /// <response code="303">Movie with given ID doesn't exist in database</response>
        /// <response code="304">The given movie wasn't rated by the given user</response>
        /// <response code="305">Delete rating was unsuccessfull</response>
        /// <response code="400">Some error happened at backend level and returned an exception</response>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete,Route("delete-rating")]
        public async Task<IActionResult> DeleteRating([FromBody] RatingRequest request)
        {
            if (request.UserId == null)
            {
                RatingResponse nullError = new RatingResponse
                {
                    Code = 300,
                    Message = APIErrorCodes.BODY_MISSING_MESSAGE + "userID"
                };

                return BadRequest(nullError);
            }

            if (request.MovieId == null)
            {
                RatingResponse nullError = new RatingResponse
                {
                    Code = 301,
                    Message = APIErrorCodes.BODY_MISSING_MESSAGE + "movieID"
                };

                return BadRequest(nullError);
            }

            try
            {
                RatingResponse response = await _service.DeleteRating(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                RatingResponse error = new RatingResponse
                {
                    Code = 400,
                    Message = APIErrorCodes.DELETE_RATING_EXCEPTION_MESSAGE + ex.Message
                };

                return BadRequest(error);
            }
        }
    }
}