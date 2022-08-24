namespace MoviesWebAPI.Data.Responses.Users
{
    public class AllUsersResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public IEnumerable<Models.Users>? UserList { get; set; }

    }
}
