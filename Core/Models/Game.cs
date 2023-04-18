using AirsoftClub.Domain.Core.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AirsoftClub.Domain.Core.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string? Photo { get; set; }
        public DateTime CreationDt { get; set; }
        public int RentalPrice { get; set; }
        public int DefaultPrice { get; set; }
        public DateTime StartDt { get; set; }
        public GameType GameType { get; set; }
        public Guid? FiringFieldId { get; set; }
        public Guid ClubId { get; set; }

        public FiringField? FiringField { get; set; }
        public Club Club { get; set; }
        public List<SoloRecord> SoloRecords { get; set; }
        public List<TeamRecord> TeamRecords { get; set; }
    }

    internal class GameMap : IEntityTypeConfiguration<Game>
    {
        public static GameMap Instance = new();

        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.CreationDt).IsRequired();
            builder.Property(x => x.RentalPrice).IsRequired();
            builder.Property(x => x.DefaultPrice).IsRequired();
            builder.Property(x => x.StartDt).IsRequired();
            builder.Property(x => x.GameType).IsRequired();

            builder.HasOne(x => x.FiringField).WithMany(x => x.Games).HasForeignKey(x => x.FiringFieldId).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.SoloRecords).WithOne(x => x.Game).HasForeignKey(x => x.GameId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.TeamRecords).WithOne(x => x.Game).HasForeignKey(x => x.GameId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
