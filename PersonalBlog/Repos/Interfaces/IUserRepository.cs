using PersonalBlog.Models;

namespace PersonalBlog.Repos.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUserById(int id);
        Task<UserModel> GetUserByName(string name);
        Task<UserModel> AddUser(UserModel user);
        Task<UserModel> UpdateUser(UserModel user, int id);
        Task<bool> DeleteUser(int id);
    }
}
