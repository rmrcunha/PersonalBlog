using PersonalBlog.Models;

namespace PersonalBlog.Repos.Interfaces
{
    public interface IPostRespository
    {
        Task<List<PostsModel>> GetAllPosts();
        Task<PostsModel> GetPostById(int id);
        Task<PostsModel> AddPost(PostsModel post);
        Task<PostsModel> UpdatePost(PostsModel post, int id);
        Task<bool> DeletePost(int id);
    }
}
