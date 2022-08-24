using MoviesWebAPI.Data.Requests.Users;
using MoviesWebAPI.Data.Responses.Users;


namespace MoviesWebAPI.Services.Users
{
    public interface IUserService
    {
        public Task<AllUsersResponse> GetAllUsers();

        public Task<UserResponse> GetUserByID(int? id);

        public Task<AllUsersResponse> GetUserByName(string? userName);

        public Task<UserResponse> AddNewUser(UserRequest request);

        public Task<UserResponse> UpdateUserProfile(int? userID, UserRequest request);

        public Task<UserResponse> UpdateUserPassword(UserRequest request);

        public Task<UserResponse> LoginUser(UserRequest userRequest);
    }
}
