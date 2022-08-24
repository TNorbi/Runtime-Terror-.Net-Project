using MoviesWebAPI.Repositories.Genres;

namespace MoviesWebAPI.Services.Genres
{
    public class GenreService: IGenreService
    {
        private IGenreRepository _repository { get; }

        public GenreService(IGenreRepository repository)
        {
            _repository = repository;
        }
    }
}
