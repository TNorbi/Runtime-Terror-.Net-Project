namespace MoviesWebAPI.Data.Responses.Movies
{
    public class MovieResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public Models.Movies? Movie { get; set; }
    }
}
