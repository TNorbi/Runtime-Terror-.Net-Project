using MoviesWebAPI.Data.Requests.Ratings;
using MoviesWebAPI.Data.Responses.Ratings;

namespace MoviesWebAPI.Services.Ratings
{
    public interface IRatingsService
    {
        public Task<AllRatingsResponse> GetAllRatings();
        public Task<RatingResponse> AddNewRating(RatingRequest request);

        public Task<AllRatingsResponse> GetRatingByID(int? userId);

        public Task<AllRatingsResponse> GetRatingByMovieId(int? movieID);

        public Task<RatingResponse> UpdateRating(RatingRequest request);

        public Task<RatingResponse> DeleteRating(RatingRequest request);
    }
}
