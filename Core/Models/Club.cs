using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AirsoftClub.Domain.Core.Models.InfoPost;

namespace AirsoftClub.Domain.Core.Models
{
    public class Club
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Player> Players { get; set; }
        public List<Game> Games { get; set; }
        public List<FiringField> FiringFields { get; set; }
        public List<ClubInfoPost> ClubInfoPosts { get; set; }
        public List<ClubPlayer> ClubPlayers { get; set; }
    }

    internal class ClubMap : IEntityTypeConfiguration<Club>
    {
        public static ClubMap Instance = new();

        public void Configure(EntityTypeBuilder<Club> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Description).IsRequired();

            builder.HasMany(x => x.Games).WithOne(x => x.Club).HasForeignKey(x => x.ClubId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.FiringFields).WithOne(x => x.Club).HasForeignKey(x => x.ClubId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.ClubInfoPosts).WithOne(x => x.Author).HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
