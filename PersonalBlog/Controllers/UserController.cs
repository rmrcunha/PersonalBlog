using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Models;
using PersonalBlog.Repos.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace PersonalBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository) => _userRepository = userRepository;

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUserById(int id)
        {
            UserModel user = await _userRepository.GetUserById(id);
            return Ok(user);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<UserModel>> GetUserByName(string name)
        {
            UserModel user = await _userRepository.GetUserByName(name);
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            List<UserModel> users = await _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> AddUser([FromBody]UserModel newUser)
        {
            UserModel user = await _userRepository.AddUser(newUser);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser(UserModel userModel, int id)
        {
            userModel.Id = id;
            UserModel user = await _userRepository.UpdateUser(userModel, id);
            return Ok(user);
        }

        [HttpDelete("^{id}")]
        public async Task<ActionResult<UserModel>> DeleteUser(int id)
        {
            bool deleted = await _userRepository.DeleteUser(id);
            return Ok(deleted);
        }
    }
}
