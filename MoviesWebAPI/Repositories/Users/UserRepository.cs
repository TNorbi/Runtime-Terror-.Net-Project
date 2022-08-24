using Microsoft.EntityFrameworkCore;
using MoviesWebAPI.Data;
using MoviesWebAPI.Data.Requests.Users;

namespace MoviesWebAPI.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _context { get; }

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Data.Models.Users>> GetAllUsers()
        {
            try
            {
                var getUsersResponse = await _context.Users.ToListAsync();

                return getUsersResponse;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Data.Models.Users> GetUserByID(int? id)
        {
            try
            {
                var getUserResponse = await _context.Users.FindAsync(id);

                return getUserResponse;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Data.Models.Users>> GetUserByName(string? userName)
        {
            try
            {
                var getUserResponse = _context.Users.Where(x => x.UserName.Equals(userName));

                return await getUserResponse.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Data.Models.Users> AddNewUser(Data.Models.Users User)
        {
            var searchPass = _context.Users.Where(x => x.Password.Equals(User.Password));

            var searchEmail = _context.Users.Where(x => x.Email.Equals(User.Email));

            //ha letezik mar ilyen password vagy email => nem teszuk fel az adatbazisba!
            if (searchPass.Count() > 0)
            {
                return new Data.Models.Users { Password = User.Password };
            }

            if (searchEmail.Count() > 0)
            {
                return new Data.Models.Users { Email = User.Email };
            }


            try
            {
                var response = await _context.Users.AddAsync(User);

                await _context.SaveChangesAsync();

                return response.Entity;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Data.Models.Users> UpdateUserProfile(int? userID, Data.Models.Users User)
        {
            try
            {
                var user = await _context.Users.FindAsync(userID);

                if (user == null)
                {
                    return null;
                }

                user.UserName = User.UserName;
                user.FirstName = User.FirstName;
                user.LastName = User.LastName;
                user.Email = User.Email;
                user.Gender = User.Gender;

                _context.Users.Update(user);

                await _context.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Data.Models.Users> UpdateUserPassword(Data.Models.Users User)
        {
            try
            {
                var user = await _context.Users.Where(x => x.UserName.Equals(User.UserName) && x.Email.Equals(User.Email)).FirstOrDefaultAsync();

                //nem letezik ilyen user a tablaban
                if(user == null)
                {
                    return null;
                }

                //frissitem az adott user jelszavat
                user.Password = User.Password;
                var result = _context.Users.Update(user);

                await _context.SaveChangesAsync();

                return result.Entity;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Data.Models.Users> LoginUser(Data.Models.Users User)
        {
            try
            {
                var user = await _context.Users.Where(x=> x.UserName.Equals(User.UserName) && x.Password.Equals(User.Password)).FirstOrDefaultAsync();

                return user;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
