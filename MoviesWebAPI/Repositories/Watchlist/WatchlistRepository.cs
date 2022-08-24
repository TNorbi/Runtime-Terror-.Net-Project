using Microsoft.EntityFrameworkCore;
using MoviesWebAPI.Data;
using MoviesWebAPI.Data.Models.DTOs;
using MoviesWebAPI.Data.Models.DTOs.Watchlist;

namespace MoviesWebAPI.Repositories.Watchlist
{
    public class WatchlistRepository: IWatchlistRepository
    {
        private AppDbContext _context { get; }

        public WatchlistRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WatchlistDTO>> GetAllUsersWatchlist()
        {
            try
            {
                var result = await _context.Users
                    .Include(m => m.Movies)
                    .Select(m => new WatchlistDTO
                    {
                        Username = m.UserName,
                        Movies = m.Movies.Select(x => new WatchlistMoviesDTO { ID = x.Mov_Id, Title = x.Title }).ToList()
                    }).ToListAsync();

                return result;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<WatchlistDTO> GetUserWatchlistByID(int? id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if(user == null)
                {
                    return new WatchlistDTO { Username = "" };
                }

                var result = await _context.Users
                    .Include(m => m.Movies)
                    .Where(m => m.Id == user.Id)
                    .Select(m => new WatchlistDTO
                    {
                        Username = m.UserName,
                        Movies = m.Movies.Select(x => new WatchlistMoviesDTO { ID = x.Mov_Id, Title = x.Title }).ToList()
                    }).FirstOrDefaultAsync();

                return result;

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<WatchlistDTO> GetUserWatchlistByUsername(string? userName)
        {
            try
            {
                var user = await _context.Users.Where(x => x.UserName == userName).FirstOrDefaultAsync();
                if (user == null)
                {
                    return new WatchlistDTO { Username = "" };
                }

                var result = await _context.Users
                    .Include(m => m.Movies)
                    .Where(m => m.Id == user.Id)
                    .Select(m => new WatchlistDTO
                    {
                        Username = m.UserName,
                        Movies = m.Movies.Select(x => new WatchlistMoviesDTO { ID = x.Mov_Id, Title = x.Title }).ToList()
                    }).FirstOrDefaultAsync();

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<WatchlistDTO> AddNewMovieToWatchlist(Data.Models.Watchlist watchlist)
        {
            try
            {
                //megnezzuk, hogy az adott ID-val levo User letezik-e az adatbazisban vagy sem
                var user = await _context.Users.FindAsync(watchlist.UserID);
                if(user == null)
                {
                    return new WatchlistDTO { Username = "" };
                }

                //megnezzuk, hogy az adott ID-val levo Movie letezik-e az adatbazisban vagy sem
                var movie = await _context.Movies.FindAsync(watchlist.MovieID);
                if (movie == null)
                {
                    return new WatchlistDTO { Movies = null};
                }

                user.Movies = new List<Data.Models.Movies>();

                user.Movies.Add(movie);

                var resultTest = _context.Update(user);

                await _context.SaveChangesAsync();

                var result = await GetUserWatchlistByID(resultTest.Entity.Id);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<WatchlistDTO> DeleteMovieFromWatchlist(Data.Models.Watchlist watchlist)
        {
            try
            {
                var user = await _context.Users.AsNoTracking().Where(x=> x.Id == watchlist.UserID).FirstOrDefaultAsync();
                
                if(user == null)
                {
                    return new WatchlistDTO { Username = "" };
                }

                var movie = await _context.Movies.AsNoTracking().Where(x=> x.Mov_Id == watchlist.MovieID).FirstOrDefaultAsync();
                
                if(movie == null)
                {
                    return new WatchlistDTO { Movies= null};
                }
                
                var test = await _context.Users
                    .Include(m => m.Movies)
                    .Where(m => m.Id == watchlist.UserID)
                    .Select(m => new Data.Models.Users
                    {
                        Id = m.Id,
                        UserName = m.UserName,
                        Password = m.Password,
                        FirstName = m.FirstName,
                        LastName = m.LastName,
                        Gender = m.Gender,
                        Email = m.Email,
                        Movies = m.Movies.Select(x => new Data.Models.Movies
                        {
                            Mov_Id = x.Mov_Id,
                            Title = x.Title,
                            ReleaseDate = x.ReleaseDate,
                            RunTime = x.RunTime,
                            Rating = x.Rating,
                            NumberOfRatings = x.NumberOfRatings,
                            Description = x.Description
                        }).ToList()

                    }).FirstOrDefaultAsync();

                if(test == null)
                {
                    return null;
                }

                var asd = test.Movies.Where(x => x.Mov_Id != watchlist.MovieID).ToList();
                foreach(var item in asd)
                {
                    test.Movies.Remove(item);
                }

                
                var resultTest = _context.Remove(test);
                var resultTest2 = _context.Update(test);

                await _context.SaveChangesAsync();

                var result = new WatchlistDTO { Username = user.UserName, 
                    Movies = new List<WatchlistMoviesDTO> { new WatchlistMoviesDTO { ID = movie.Mov_Id, Title = movie.Title} }
                };

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
