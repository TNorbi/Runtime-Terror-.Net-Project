namespace MoviesWebAPI.Data.Responses.Ratings
{
    public class AllRatingsResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public IEnumerable<Data.Models.DTOs.RatingsDTO>? Ratings { get; set; }
    }
}
