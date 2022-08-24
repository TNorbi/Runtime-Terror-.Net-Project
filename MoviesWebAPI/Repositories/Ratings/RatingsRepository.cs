using MoviesWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MoviesWebAPI.Repositories.Ratings
{
    public class RatingsRepository : IRatingsRepository
    {
        private AppDbContext _context { get; }

        public RatingsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Data.Models.DTOs.RatingsDTO>> GetRatingByMovieId(int? movieID)
        {
            try
            {
                var movie = await _context.Movies.FindAsync(movieID);
                if(movie == null)
                {
                    return null;
                }

                var query = from ratings in _context.Ratings
                            join users in _context.Users on ratings.UserId equals users.Id
                            join movies in _context.Movies on ratings.Mov_Id equals movies.Mov_Id
                            where movies.Mov_Id == movieID
                            select new Data.Models.DTOs.RatingsDTO { UserName = users.UserName, MovieTitle = movies.Title, Rating = ratings.Rating };

                var result = await query.ToListAsync();

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Data.Models.DTOs.RatingsDTO>> GetAllRating()
        {
            try
            {
                var query = from ratings in _context.Ratings
                            join user in _context.Users on ratings.UserId equals user.Id
                            join movie in _context.Movies on ratings.Mov_Id equals movie.Mov_Id
                            select new Data.Models.DTOs.RatingsDTO { UserName = user.UserName, MovieTitle =  movie.Title, Rating =  ratings.Rating };

                var result = await query.ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Data.Models.DTOs.RatingsDTO>> GetRatingByUserID(int? userID)
        {
            try
            {
                //megnezem ha az adott ID-val rendelkezo User letezik vagy sem
                var user = await _context.Users.FindAsync(userID);
                if(user == null)
                {
                    return null;
                }

                var query = from ratings in _context.Ratings
                            join users in _context.Users on ratings.UserId equals users.Id
                            join movie in _context.Movies on ratings.Mov_Id equals movie.Mov_Id
                            where users.Id == userID
                            select new Data.Models.DTOs.RatingsDTO { UserName = users.UserName, MovieTitle = movie.Title, Rating = ratings.Rating };

                var result = await query.ToListAsync();

                return result;

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Data.Models.Ratings> AddNewRating(Data.Models.Ratings rating)
        {
            try
            {
                //ellenorzom, hogy az adott IDval levo user letezik-e az adatbazisban vagy sem
                //ha nem letezik, akkor hibaerteket fogok visszateriteni
                var user = await _context.Users.FindAsync(rating.UserId);
                if (user == null)
                {
                    return new Data.Models.Ratings { UserId = -1 };
                }

                //megnezem, hogy az adott IDval levo film letezik-e az adatbazisban vagy sem
                //ha nem letezik, akkor hibaerteket fogok visszateriteni
                var movie = await _context.Movies.FindAsync(rating.Mov_Id);
                if (movie == null)
                {
                    return new Data.Models.Ratings { Mov_Id = -1 };
                }

                var result = await _context.Ratings.AddAsync(rating);
                await _context.SaveChangesAsync();

                return result.Entity;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Data.Models.Ratings> UpdateRating(Data.Models.Ratings rating)
        {
            try
            {
                
                var user = await _context.Users.FindAsync(rating.UserId);

                //nem letezik ilyen userid a databasben
                if(user == null)
                {
                    return new Data.Models.Ratings { UserId = -1 };
                }

                var movie = await _context.Movies.FindAsync(rating.Mov_Id);

                //nem letezik ilyen movieID a databaseben
                if(movie == null)
                {
                    return new Data.Models.Ratings { Mov_Id= -1 };
                }

                var searchResult = await _context.Ratings.Where(x => x.UserId == rating.UserId && x.Mov_Id == rating.Mov_Id).FirstOrDefaultAsync();

                //nem letezik a Ratingsben olyan adat, ahol az adott user az adott filmnek adott volna ratinget
                if(searchResult == null)
                {
                    return new Data.Models.Ratings { Rating=-1};
                }

                searchResult.Rating = rating.Rating;

                var result = _context.Ratings.Update(searchResult);
                await _context.SaveChangesAsync();

                return result.Entity;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Data.Models.Ratings> DeleteRating(Data.Models.Ratings rating)
        {
            try
            {
                var user = await _context.Users.FindAsync(rating.UserId);
                if(user == null)
                {
                    return new Data.Models.Ratings { UserId= -1 };
                }

                var movie = await _context.Movies.FindAsync(rating.Mov_Id);
                if( movie == null)
                {
                    return new Data.Models.Ratings { Mov_Id=-1 };
                }

                var searchResult = await _context.Ratings.Where(x => x.UserId == rating.UserId && x.Mov_Id == rating.Mov_Id).FirstOrDefaultAsync();

                //nem letezik a Ratingsben olyan adat, ahol az adott user az adott filmnek adott volna ratinget
                if (searchResult == null)
                {
                    return new Data.Models.Ratings { Rating = -1 };
                }

                var result = _context.Ratings.Remove(searchResult);
                await _context.SaveChangesAsync();

                return result.Entity;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
