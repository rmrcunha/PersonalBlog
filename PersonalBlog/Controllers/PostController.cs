using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Models;
using PersonalBlog.Repos.Interfaces;

namespace PersonalBlog.Controllers
{
    [Route("/api[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRespository _postRepository;
        public PostController(IPostRespository postRepository)
        {
            _postRepository = postRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<PostsModel>>> GetAllPosts()
        {
            List<PostsModel> posts = await _postRepository.GetAllPosts();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostController>> GetPostById(int id)
        {
            PostsModel post = await _postRepository.GetPostById(id);
            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult<PostsModel>> AddPost(PostsModel post)
        {
            await _postRepository.AddPost(post);
            return Ok(post);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PostsModel>> DeletePost(int id)
        {
            bool deleted =await _postRepository.DeletePost(id);
            return Ok(deleted);
        }

    }
}
