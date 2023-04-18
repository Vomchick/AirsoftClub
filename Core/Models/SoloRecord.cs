using AirsoftClub.Domain.Core.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AirsoftClub.Domain.Core.Models
{
    public class SoloRecord
    {
        public Guid Id { get; set; }
        public bool NeedARent { get; set; }
        public PickUp PickUp { get; set; }
        public Guid GameId { get; set; }
        public Guid PlayerId { get; set; }

        public Game Game { get; set; }
        public Player Player { get; set; }
    }

    internal class SoloRecordMap : IEntityTypeConfiguration<SoloRecord>
    {
        public static SoloRecordMap Instance = new();

        public void Configure(EntityTypeBuilder<SoloRecord> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.NeedARent).IsRequired();
            builder.Property(x => x.PickUp).IsRequired();
        }
    }
}
