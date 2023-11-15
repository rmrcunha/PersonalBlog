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
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PostsModel>> GetAllPosts() => await _dbcontext.Posts.Include(x => x.User).ToListAsync();
        public async Task<PostsModel> AddPost(PostsModel post)
        {
            await _dbcontext.Posts.AddAsync(post);
            await _dbcontext.SaveChangesAsync();

            return post;
        }

        public async Task<bool> DeletePost(int id)
        {
            PostsModel postById = await GetPostById(id);

            if(postById == null)
            {
                throw new Exception("Não existe post para este ID");

            }

            _dbcontext.Posts.Remove(postById);
            await _dbcontext.SaveChangesAsync();

            return true;
        }




        public Task<PostsModel> UpdatePost(PostsModel post, int id)
        {
            throw new NotImplementedException();
        }
    }
}
