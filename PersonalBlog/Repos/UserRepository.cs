using Microsoft.EntityFrameworkCore;
using PersonalBlog.Data;
using PersonalBlog.Models;
using PersonalBlog.Repos.Interfaces;

namespace PersonalBlog.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly PostsDbContext _postsDbContext;
        public UserRepository(PostsDbContext postsDbContext)
        {
            _postsDbContext = postsDbContext;
        }


        public async Task<UserModel> GetUserById(int id)
        {
            UserModel userById = await _postsDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            return userById;
        }
        public async Task<UserModel> GetUserByName(string name)
        {
            UserModel userByName = await _postsDbContext.Users.FirstOrDefaultAsync(i => i.Name == name);
            return userByName;
        }
        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _postsDbContext.Users.ToListAsync();
        }


        public async Task<UserModel> AddUser(UserModel user)
        {
            await _postsDbContext.AddAsync(user);
            await _postsDbContext.SaveChangesAsync();

            return user;
        }
        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userById = await GetUserById(id);

            if (userById == null)
            {
                throw new Exception("The user doesn't exists");
            }

            userById.Name = user.Name;
            userById.Email = user.Email;

            _postsDbContext.Users.Update(userById);
            await _postsDbContext.SaveChangesAsync();

            return userById;

        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel userById = await GetUserById(id);

            _ = userById == null ?
                throw new Exception("The user doesn't exists")
                    : _postsDbContext.Users.Remove(userById);

            await _postsDbContext.SaveChangesAsync();

            return true;
        }

    }
}
