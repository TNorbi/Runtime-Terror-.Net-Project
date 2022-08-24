using MoviesWebAPI.Data.Requests.Users;

namespace MoviesWebAPI.Repositories.Users
{
    public interface IUserRepository
    {
        public Task<IEnumerable<Data.Models.Users>> GetAllUsers();

        public Task<Data.Models.Users> GetUserByID(int? id);

        public Task<IEnumerable<Data.Models.Users>> GetUserByName(string? userName);

        public Task<Data.Models.Users> AddNewUser(Data.Models.Users User);

        public Task<Data.Models.Users> UpdateUserProfile(int? userID, Data.Models.Users User);

        public Task<Data.Models.Users> UpdateUserPassword(Data.Models.Users User);

        public Task<Data.Models.Users> LoginUser(Data.Models.Users User);
    }
}
