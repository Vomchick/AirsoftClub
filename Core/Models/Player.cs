using AirsoftClub.Domain.Core.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AirsoftClub.Domain.Core.Models.InfoPost;

namespace AirsoftClub.Domain.Core.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        public string CallSign { get; set; }
        public GameRole GameRole { get; set; }
        public string? Description { get; set; }
        public TeamRole? TeamRole { get; set; }
        public Guid UserId { get; set; }
        public Guid? TeamId { get; set; }
        public byte[]? Photo { get; set; }

        public User? User { get; set; }
        public Team? Team { get; set; }
        public List<Club>? Clubs { get; set; }
        //public List<Review> Reviews { get; set; }
        public List<SoloRecord>? SoloRecords { get; set; }
        public List<PlayerInfoPost>? PlayerInfoPosts { get; set; }
        public List<ClubPlayer>? ClubPlayers { get; set; }
    }

    internal class PlayerMap : IEntityTypeConfiguration<Player>
    {
        public static PlayerMap Instance = new();

        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CallSign).IsRequired().HasMaxLength(128);
            //builder.Property(x => x.GameRole)
            //    .HasConversion(
            //        x => x.ToString(),
            //        x => (GameRole)Enum.Parse(typeof(GameRole), x));
            //builder.Property(x => x.TeamRole)
            //    .HasConversion(
            //        x => x.ToString(),
            //        x => (TeamRole)Enum.Parse(typeof(TeamRole), x));

            builder.HasOne(x => x.Team).WithMany(x => x.Players).HasForeignKey(x => x.TeamId).OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.Clubs).WithMany(x => x.Players).UsingEntity<ClubPlayer>(
                entity => { 
                    entity.HasOne(x => x.Player).WithMany(x => x.ClubPlayers).HasForeignKey(x => x.PlayerId);
                    entity.HasOne(x => x.Club).WithMany(x => x.ClubPlayers).HasForeignKey(x => x.ClubId);
                    entity.HasKey(t => new { t.PlayerId, t.ClubId });
                });

            //builder.HasMany(x => x.Reviews).WithOne(x => x.Player).HasForeignKey(x => x.PlayerId).OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.SoloRecords).WithOne(x => x.Player).HasForeignKey(x => x.PlayerId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.PlayerInfoPosts).WithOne(x => x.Author).HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
