namespace PersonalBlog.Models
{
    public class PostsModel
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastUpdated { get; set; }
        public UserModel? User { get; set;}
    }
}
