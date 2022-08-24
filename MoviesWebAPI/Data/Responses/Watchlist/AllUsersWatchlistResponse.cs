using MoviesWebAPI.Data.Models.DTOs;

namespace MoviesWebAPI.Data.Responses.Watchlist
{
    public class AllUsersWatchlistResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public IEnumerable<WatchlistDTO>? UsersWatchlist { get; set; }
    }
}
