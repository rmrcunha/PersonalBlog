using Microsoft.EntityFrameworkCore;
using PersonalBlog.Data;
using PersonalBlog.Models;
using PersonalBlog.Repos.Interfaces;

namespace PersonalBlog.Repos
{
    public class PostsRepository : IPostRespository
    {
        private readonly PostsDbContext _dbcontext;
        public PostsRepository(PostsDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<PostsModel> GetPostById(int id)
        {
            return await _dbcontext.Posts
                .Include(x => x.Users)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PostsModel>> GetAllPosts()
        {
            
        }
        public Task<PostsModel> AddPost(PostsModel post)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePost(int id)
        {
            throw new NotImplementedException();
        }




        public Task<PostsModel> UpdatePost(PostsModel post, int id)
        {
            throw new NotImplementedException();
        }
    }
}
