namespace MoviesWebAPI.Repositories.Movies
{
    public interface IMovieRepository
    {
        public Task<IEnumerable<Data.Models.Movies>> GetAllMovies();
        public Task<Data.Models.Movies> GetMovieById(int? id);

        public Task<IEnumerable<Data.Models.Movies>> GetMoviesByTitle(string? title);
    }
}
