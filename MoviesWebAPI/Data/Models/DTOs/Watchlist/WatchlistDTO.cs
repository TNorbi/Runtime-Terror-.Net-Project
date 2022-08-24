using MoviesWebAPI.Data.Models.DTOs.Watchlist;

namespace MoviesWebAPI.Data.Models.DTOs
{
    public class WatchlistDTO
    {
        public string Username { get; set; }
        public IEnumerable<WatchlistMoviesDTO>? Movies { get; set; }
    }
}
