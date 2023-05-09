using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirsoftClub.Domain.Core.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public Player Player { get; set; }
    }

    internal class UserMap : IEntityTypeConfiguration<User>
    {
        public static UserMap Instance = new();

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Password).IsRequired();

            builder.HasOne(x => x.Player).WithOne(x => x.User).HasForeignKey<Player>(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
