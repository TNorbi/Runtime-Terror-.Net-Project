namespace MoviesWebAPI.Data.Requests.Users
{
    public class UserRequest
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Gender { get; set; }
        public string? Email { get; set; }

    }
}
