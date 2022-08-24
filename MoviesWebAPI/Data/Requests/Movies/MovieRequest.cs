namespace MoviesWebAPI.Data.Requests.Movies
{
    public class MovieRequest
    {
        public string? Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        public double? Rating { get; set; }
        public int? NumberOfRatings { get; set; }
        public string? Description { get; set; }
    }
}
