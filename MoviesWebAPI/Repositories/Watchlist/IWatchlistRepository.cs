using MoviesWebAPI.Data.Models.DTOs;

namespace MoviesWebAPI.Repositories.Watchlist
{
    public interface IWatchlistRepository
    {
        public Task<IEnumerable<WatchlistDTO>> GetAllUsersWatchlist();

        public Task<WatchlistDTO> GetUserWatchlistByID(int? id);

        public Task<WatchlistDTO> GetUserWatchlistByUsername(string? userName);

        public Task<WatchlistDTO> AddNewMovieToWatchlist(Data.Models.Watchlist watchlist);

        public Task<WatchlistDTO> DeleteMovieFromWatchlist(Data.Models.Watchlist watchlist);
    }
}
