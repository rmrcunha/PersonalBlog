using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBlog.Models;

namespace PersonalBlog.Data.Map
{
    public class PostMap : IEntityTypeConfiguration<PostsModel>
    {
        public void Configure(EntityTypeBuilder<PostsModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(250);
            builder.Property(x => x.UserId);
            builder.Property(x => x.UserName);
            builder.Property(x => x.Created);
            builder.Property(x => x.LastUpdated);
            builder.HasOne(x => x.User);

        }
    }
}
