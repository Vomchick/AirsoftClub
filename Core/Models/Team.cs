using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AirsoftClub.Domain.Core.Models.InfoPost;

namespace AirsoftClub.Domain.Core.Models
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public List<Player>? Players { get; set; }
        public List<TeamRecord>? TeamRecords { get; set; }
        public List<TeamInfoPost>? TeamInfoPosts { get; set; }
    }

    internal class TeamMap : IEntityTypeConfiguration<Team>
    {
        public static TeamMap Instance = new();

        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
            
            builder.HasMany(x => x.TeamRecords).WithOne(x => x.Team).HasForeignKey(x => x.TeamId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.TeamInfoPosts).WithOne(x => x.Author).HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
