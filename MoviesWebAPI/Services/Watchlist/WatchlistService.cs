using MoviesWebAPI.Data.Requests.Watchlist;
using MoviesWebAPI.Data.Responses.Watchlist;
using MoviesWebAPI.Repositories.Watchlist;
using MoviesWebAPI.Utils;

namespace MoviesWebAPI.Services.Watchlist
{
    public class WatchlistService : IWatchlistService
    {
        private IWatchlistRepository _repository { get; }

        public WatchlistService(IWatchlistRepository repository)
        {
            _repository = repository;
        }

        public async Task<AllUsersWatchlistResponse> GetAllUsersWatchlist()
        {
            try
            {
                AllUsersWatchlistResponse response = new AllUsersWatchlistResponse();

                response.UsersWatchlist = await _repository.GetAllUsersWatchlist();

                if(response.UsersWatchlist != null)
                {
                    response.Code = 200;
                    response.Message = APISuccessCodes.GET_ALL_USERS_WATCHLIST_SUCCESS_MESSAGE;
                }
                else
                {
                    response.Code = 300;
                    response.Message = APIErrorCodes.GET_ALL_USERS_WATCHLIST_NULL_MESSAGE;
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserWatchlistResponse> GetUserWatchlistByID(int? id)
        {
            try
            {
                UserWatchlistResponse response = new UserWatchlistResponse();

                response.Watchlist = await _repository.GetUserWatchlistByID(id);

                if(response.Watchlist != null)
                {
                    if(response.Watchlist.Username == "")
                    {
                        response.Code = 301;
                        response.Message = APIErrorCodes.GET_USER_BY_ID_NOT_FOUND_MESSAGE;
                    }
                    else
                    {
                        response.Code = 200;
                        response.Message = APISuccessCodes.GET_USER_WATCHLIST_BY_USERID_SUCCESS_MESSAGE;
                    }
                }
                else
                {
                    response.Code = 302;
                    response.Message = APIErrorCodes.GET_USER_WATCHLIST_BY_USERID_NULL_MESSAGE;
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserWatchlistResponse> GetUserWatchlistByUsername(string? userName)
        {
            try
            {
                UserWatchlistResponse response = new UserWatchlistResponse();

                response.Watchlist = await _repository.GetUserWatchlistByUsername(userName);

                if (response.Watchlist != null)
                {
                    if (response.Watchlist.Username == "")
                    {
                        response.Code = 301;
                        response.Message = APIErrorCodes.GET_USER_BY_NAME_NOT_FOUND_MESSAGE;
                    }
                    else
                    {
                        response.Code = 200;
                        response.Message = APISuccessCodes.GET_USER_WATCHLIST_BY_USERNAME_SUCCESS_MESSAGE;
                    }
                }
                else
                {
                    response.Code = 302;
                    response.Message = APIErrorCodes.GET_USER_WATCHLIST_BY_USERNAME_NULL_MESSAGE;
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserWatchlistResponse> AddNewMovieToWatchlist(WatchlistRequest request)
        {
            try
            {
                UserWatchlistResponse response = new UserWatchlistResponse();

                Data.Models.Watchlist newWatchlist = new Data.Models.Watchlist
                {
                    UserID = (int)request.UserID,
                    MovieID = (int)request.MovieID
                };

                response.Watchlist = await _repository.AddNewMovieToWatchlist(newWatchlist);

                if(response.Watchlist != null)
                {
                    if(response.Watchlist.Username == "")
                    {
                        response.Code = 302;
                        response.Message = APIErrorCodes.GET_USER_BY_ID_NOT_FOUND_MESSAGE;
                    }
                    else if(response.Watchlist.Movies == null)
                    {
                        response.Code = 303;
                        response.Message = APIErrorCodes.GET_MOVIE_BY_ID_NULL_MESSAGE;
                    }
                    else
                    {
                        response.Code = 200;
                        response.Message = APISuccessCodes.ADD_MOVIE_TO_WATCHLIST_SUCCCESS_MESSAGE;
                    }
                }
                else
                {
                    response.Code = 304;
                    response.Message = APIErrorCodes.ADD_MOVIE_TO_WATCHLIST_NULL_MESSAGE;
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserWatchlistResponse> DeleteMovieFromWatchlist(WatchlistRequest request)
        {
            try
            {
                UserWatchlistResponse response = new UserWatchlistResponse();

                Data.Models.Watchlist watchlist = new Data.Models.Watchlist
                {
                    UserID = (int)request.UserID,
                    MovieID = (int)request.MovieID
                };

                response.Watchlist = await _repository.DeleteMovieFromWatchlist(watchlist);

                if (response.Watchlist != null)
                {
                    if (response.Watchlist.Username == "")
                    {
                        response.Code = 302;
                        response.Message = APIErrorCodes.GET_USER_BY_ID_NOT_FOUND_MESSAGE;
                    }
                    else if (response.Watchlist.Movies == null)
                    {
                        response.Code = 303;
                        response.Message = APIErrorCodes.GET_MOVIE_BY_ID_NULL_MESSAGE;
                    }
                    else
                    {
                        response.Code = 200;
                        response.Message = APISuccessCodes.DELETE_MOVIE_FROM_WATCHLIST_SUCCCESS_MESSAGE;
                    }
                }
                else
                {
                    response.Code = 304;
                    response.Message = APIErrorCodes.DELETE_MOVIE_FROM_WATCHLIST_NULL_MESSAGE;
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
