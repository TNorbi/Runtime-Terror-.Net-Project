using MoviesWebAPI.Data.Requests.Ratings;
using MoviesWebAPI.Data.Responses.Ratings;
using MoviesWebAPI.Repositories.Ratings;
using MoviesWebAPI.Utils;

namespace MoviesWebAPI.Services.Ratings
{
    public class RatingsService : IRatingsService
    {
        private IRatingsRepository _repository { get; }

        public RatingsService(IRatingsRepository repository)
        {
            _repository = repository;
        }

        public async Task<AllRatingsResponse> GetAllRatings()
        {
            AllRatingsResponse response = new AllRatingsResponse();

            try
            {
                response.Ratings = await _repository.GetAllRating();

                if(response.Ratings != null)
                {
                    response.Code = 200;
                    response.Message = APISuccessCodes.GET_ALL_RATINGS_SUCCESS_MESSAGE;
                }
                else
                {
                    response.Code = 300;
                    response.Message = APIErrorCodes.GET_ALL_RATINGS_NULL_MESSAGE;
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RatingResponse> AddNewRating(RatingRequest request)
        {
            RatingResponse response = new RatingResponse();

            try
            {
                Data.Models.Ratings NewRating = new Data.Models.Ratings
                {
                    UserId = (int)request.UserId,
                    Mov_Id = (int)request.MovieId,
                    Rating = (int)request.Rating
                };

                response.Rating = await _repository.AddNewRating(NewRating);

                if (response.Rating != null)
                {
                    if (response.Rating.UserId == -1)
                    {
                        response.Code = 304;
                        response.Message = APIErrorCodes.GET_USER_BY_ID_NOT_FOUND_MESSAGE;
                    }
                    else if (response.Rating.Mov_Id == -1)
                    {
                        response.Code = 305;
                        response.Message = APIErrorCodes.GET_MOVIE_BY_ID_NULL_MESSAGE;
                    }
                    else
                    {
                        response.Code = 200;
                        response.Message = APISuccessCodes.ADD_NEW_RATING_SUCCESS_MESSAGE;
                    }
                }
                else
                {
                    response.Code = 306;
                    response.Message = APIErrorCodes.ADD_NEW_RATING_NULL_MESSAGE;
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AllRatingsResponse> GetRatingByID(int? userId)
        {
            AllRatingsResponse response = new AllRatingsResponse();

            try
            {
                response.Ratings = await _repository.GetRatingByUserID(userId);

                if(response.Ratings != null)
                {
                    response.Code = 200;
                    response.Message = APISuccessCodes.GET_RATINGS_BY_USERID_SUCCESS_MESSAGE;
                }
                else
                {
                    response.Code = 301;
                    response.Message = APIErrorCodes.GET_USER_BY_ID_NOT_FOUND_MESSAGE;
                }

                return response;

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AllRatingsResponse> GetRatingByMovieId(int? movieID)
        {
            AllRatingsResponse response = new AllRatingsResponse();

            try
            {
                response.Ratings = await _repository.GetRatingByMovieId(movieID);

                if(response.Ratings != null)
                {
                    response.Code = 200;
                    response.Message = APISuccessCodes.GET_RATINGS_BY_MOVIEID_SUCCESS_MESSAGE;
                }
                else
                {
                    response.Code = 301;
                    response.Message = APIErrorCodes.GET_MOVIE_BY_ID_NULL_MESSAGE;
                }

                return response;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RatingResponse> UpdateRating(RatingRequest request)
        {
            Data.Models.Ratings rating = new Data.Models.Ratings
            {
                UserId = (int)request.UserId,
                Mov_Id = (int)request.MovieId,
                Rating = (int)request.Rating
            };

            RatingResponse response = new RatingResponse();

            try
            {
                response.Rating = await _repository.UpdateRating(rating);

                if(response.Rating != null)
                {
                    if(response.Rating.UserId == -1)
                    {
                        response.Code = 304;
                        response.Message = APIErrorCodes.GET_USER_BY_ID_NOT_FOUND_MESSAGE;
                    }
                    else if(response.Rating.Mov_Id == -1)
                    {
                        response.Code = 305;
                        response.Message = APIErrorCodes.GET_MOVIE_BY_ID_NULL_MESSAGE;
                    }
                    else if(response.Rating.Rating == -1)
                    {
                        response.Code = 306;
                        response.Message = APIErrorCodes.GET_RATING_BY_MOVIEID_AND_USERID_NOT_FOUND_MESSAGE;
                    }
                    else
                    {
                        response.Code = 200;
                        response.Message = APISuccessCodes.UPDATE_RATING_SUCCESS_MESSAGE;
                    }
                }
                else
                {
                    response.Code = 307;
                    response.Message = APIErrorCodes.UPDATE_RATING_NULL_MESSAGE;
                }

                return response;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RatingResponse> DeleteRating(RatingRequest request)
        {
            RatingResponse response = new RatingResponse();

            Data.Models.Ratings rating = new Data.Models.Ratings
            {
                UserId = (int)request.UserId,
                Mov_Id = (int)request.MovieId
            };

            try
            {
                response.Rating = await _repository.DeleteRating(rating);

                if (response.Rating != null)
                {
                    if (response.Rating.UserId == -1)
                    {
                        response.Code = 302;
                        response.Message = APIErrorCodes.GET_USER_BY_ID_NOT_FOUND_MESSAGE;
                    }
                    else if (response.Rating.Mov_Id == -1)
                    {
                        response.Code = 303;
                        response.Message = APIErrorCodes.GET_MOVIE_BY_ID_NULL_MESSAGE;
                    }
                    else if (response.Rating.Rating == -1)
                    {
                        response.Code = 304;
                        response.Message = APIErrorCodes.GET_RATING_BY_MOVIEID_AND_USERID_NOT_FOUND_MESSAGE;
                    }
                    else
                    {
                        response.Code = 200;
                        response.Message = APISuccessCodes.DELETE_RATING_SUCCESS_MESSAGE;
                    }
                }
                else
                {
                    response.Code = 305;
                    response.Message = APIErrorCodes.DELETE_RATING_NULL_MESSAGE;
                }

                return response;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
