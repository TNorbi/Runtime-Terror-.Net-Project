using MoviesWebAPI.Data.Responses.Movies;
using MoviesWebAPI.Repositories.Movies;
using MoviesWebAPI.Utils;

namespace MoviesWebAPI.Services.Movies
{
    public class MovieService:IMovieService
    {
        private IMovieRepository _repository { get; }

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<AllMoviesResponse> GetAllMovies()
        {
            AllMoviesResponse response = new AllMoviesResponse();

            try
            {
                response.MovieList = await _repository.GetAllMovies();

                if(response.MovieList != null)
                {
                    response.Code = 200;
                    response.Message = APISuccessCodes.GET_ALL_MOVIES_SUCCESS_MESSAGE;
                }
                else 
                {
                    response.Code = 300;
                    response.Message = APIErrorCodes.GET_ALL_MOVIES_NULL_MESSAGE;
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MovieResponse> GetMovieById(int? id)
        {
             MovieResponse response = new MovieResponse();

            try
            {
                response.Movie = await _repository.GetMovieById(id);

                if(response.Movie != null)
                {
                    response.Code = 200;
                    response.Message = APISuccessCodes.GET_MOVIE_BY_ID_SUCCES_MESSAGE;
                }
                else
                {
                    response.Code = 301;
                    response.Message = APIErrorCodes.GET_MOVIE_BY_ID_NULL_MESSAGE;
                }

                return response;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AllMoviesResponse> GetMoviesByTitle(string? title)
        {
            AllMoviesResponse response = new AllMoviesResponse();

            try
            {
                response.MovieList = await _repository.GetMoviesByTitle(title);

                if (response.MovieList != null)
                {
                    response.Code = 200;
                    response.Message = APISuccessCodes.GET_MOVIES_BY_TITLE_SUCCES_MESSAGE;
                }
                else
                {
                    response.Code = 301;
                    response.Message = APIErrorCodes.GET_MOVIES_BY_TITLE_NULL_MESSAGE;
                }

                return response;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
