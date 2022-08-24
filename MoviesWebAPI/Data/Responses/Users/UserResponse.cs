namespace MoviesWebAPI.Data.Responses.Users
{
    public class UserResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public Models.Users? User { get; set; }
    }
}
