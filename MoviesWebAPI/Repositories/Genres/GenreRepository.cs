using MoviesWebAPI.Data;

namespace MoviesWebAPI.Repositories.Genres
{
    public class GenreRepository : IGenreRepository
    {
        private AppDbContext _context { get; }

        public GenreRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
