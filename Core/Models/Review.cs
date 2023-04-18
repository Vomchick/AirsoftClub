using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AirsoftClub.Domain.Core.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string? Photo { get; set; }
        public DateTime CreationDt { get; set; }
        public int Rating { get; set; }
        public Guid? PlayerId { get; set; }
        public Guid FiringFieldId { get; set; }

        public Player? Player { get; set; }
        public FiringField FiringField { get; set; }
    }

    internal class ReviewMap : IEntityTypeConfiguration<Review>
    {
        public static ReviewMap Instance = new();

        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.CreationDt).IsRequired();
            builder.Property(x => x.Rating).IsRequired();
        }
    }
}
