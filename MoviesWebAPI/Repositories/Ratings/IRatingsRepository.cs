namespace MoviesWebAPI.Repositories.Ratings
{
    public interface IRatingsRepository
    {
        public Task<IEnumerable<Data.Models.DTOs.RatingsDTO>> GetRatingByMovieId(int? movieID);
        public Task<IEnumerable<Data.Models.DTOs.RatingsDTO>> GetAllRating();
        public Task<IEnumerable<Data.Models.DTOs.RatingsDTO>> GetRatingByUserID(int? userID);

        public Task<Data.Models.Ratings> AddNewRating(Data.Models.Ratings rating);

        public Task<Data.Models.Ratings> UpdateRating(Data.Models.Ratings rating);

        public Task<Data.Models.Ratings> DeleteRating(Data.Models.Ratings rating);
    }
}
