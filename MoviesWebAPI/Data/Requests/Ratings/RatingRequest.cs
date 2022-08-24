namespace MoviesWebAPI.Data.Requests.Ratings
{
    public class RatingRequest
    {
        public int? UserId { get; set; }
        public int? MovieId { get; set; }
        public int? Rating { get; set; }
    }
}
