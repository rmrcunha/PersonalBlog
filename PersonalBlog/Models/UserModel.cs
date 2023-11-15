using PersonalBlog.Enums;

namespace PersonalBlog.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public UserStatus Status { get; set; }
    }
}
