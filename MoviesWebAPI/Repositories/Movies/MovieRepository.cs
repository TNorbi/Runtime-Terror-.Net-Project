using MoviesWebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace MoviesWebAPI.Repositories.Movies
{
    public class MovieRepository : IMovieRepository
    {
        private AppDbContext _context { get;}

        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Data.Models.Movies>> GetAllMovies()
        {
            try
            {
                var result = await _context.Movies.
                    Include(g => g.Genres)
                    .Select(g => new Data.Models.Movies
                    {
                        Mov_Id = g.Mov_Id,
                        Title = g.Title,
                        ReleaseDate = g.ReleaseDate,
                        RunTime = g.RunTime,
                        Rating = g.Rating,
                        NumberOfRatings = g.NumberOfRatings,
                        Description = g.Description,
                        Genres = g.Genres.Select(p => new Data.Models.Genres { Id = p.Id, GenreName = p.GenreName }).ToList()
                    }).ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Data.Models.Movies> GetMovieById(int? id)
        {
            try
            {
                var result = await _context.Movies
                    .Include(g => g.Genres)
                    .Select(g => new Data.Models.Movies
                    {
                        Mov_Id = g.Mov_Id,
                        Title = g.Title,
                        ReleaseDate = g.ReleaseDate,
                        RunTime = g.RunTime,
                        Rating = g.Rating,
                        NumberOfRatings = g.NumberOfRatings,
                        Description = g.Description,
                        Genres = g.Genres.Select(p => new Data.Models.Genres { Id = p.Id, GenreName = p.GenreName }).ToList()
                    })
                    .Where(g => g.Mov_Id.Equals(id))
                    .FirstOrDefaultAsync();

                return result;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Data.Models.Movies>> GetMoviesByTitle(string? title)
        {
            try
            {
                var result = await _context.Movies
                     .Include(g => g.Genres)
                     .Select(g => new Data.Models.Movies
                     {
                         Mov_Id = g.Mov_Id,
                         Title = g.Title,
                         ReleaseDate = g.ReleaseDate,
                         RunTime = g.RunTime,
                         Rating = g.Rating,
                         NumberOfRatings = g.NumberOfRatings,
                         Description = g.Description,
                         Genres = g.Genres.Select(p => new Data.Models.Genres { Id = p.Id, GenreName = p.GenreName }).ToList()
                     })
                     .Where(g => g.Title.Contains(title))
                     .ToListAsync();

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
