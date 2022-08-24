namespace MoviesWebAPI.Data.Responses.Movies
{
    public class AllMoviesResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public IEnumerable<Models.Movies>? MovieList { get; set; }
    }
}
