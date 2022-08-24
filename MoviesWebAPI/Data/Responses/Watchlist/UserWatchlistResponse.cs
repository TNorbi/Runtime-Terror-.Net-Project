using MoviesWebAPI.Data.Models.DTOs;

namespace MoviesWebAPI.Data.Responses.Watchlist
{
    public class UserWatchlistResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public WatchlistDTO? Watchlist { get; set; }
    }
}
