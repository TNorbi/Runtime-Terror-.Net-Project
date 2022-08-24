using MoviesWebAPI.Data.Requests.Watchlist;
using MoviesWebAPI.Data.Responses.Watchlist;

namespace MoviesWebAPI.Services.Watchlist
{
    public interface IWatchlistService
    {
        public Task<AllUsersWatchlistResponse> GetAllUsersWatchlist();
        public Task<UserWatchlistResponse> GetUserWatchlistByID(int? id);
        public Task<UserWatchlistResponse> GetUserWatchlistByUsername(string? userName);
        public Task<UserWatchlistResponse> AddNewMovieToWatchlist(WatchlistRequest request);
        public Task<UserWatchlistResponse> DeleteMovieFromWatchlist(WatchlistRequest request);
    }
}
