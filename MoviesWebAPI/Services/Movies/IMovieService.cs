using MoviesWebAPI.Data.Responses.Movies;

namespace MoviesWebAPI.Services.Movies
{
    public interface IMovieService
    {
        public Task<AllMoviesResponse> GetAllMovies();
        public Task<MovieResponse> GetMovieById(int? id);

        public Task<AllMoviesResponse> GetMoviesByTitle(string? title);
    }
}
