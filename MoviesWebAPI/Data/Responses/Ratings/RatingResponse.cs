namespace MoviesWebAPI.Data.Responses.Ratings
{
    public class RatingResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public Data.Models.Ratings? Rating { get; set; }
    }
}
