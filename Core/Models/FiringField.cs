using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AirsoftClub.Domain.Core.Models
{
    public class FiringField
    {
        public Guid Id { get; set; }
        public string Name { get; set; }    
        public string Text { get; set; }
        public string? Photo { get; set; }
        public DateTime CreationDt { get; set; }
        public bool IsCovered { get; set; }
        public string Address { get; set; }
        public string? GPS { get; set; }
        //public double Rating { get; set; }
        public Guid ClubId { get; set; }

        public Club Club { get; set; }
        public List<Game> Games { get; set; }
        //public List<Review> Reviews { get; set; }
    }

    internal class FiringFieldMap : IEntityTypeConfiguration<FiringField>
    {
        public static FiringFieldMap Instance = new();

        public void Configure(EntityTypeBuilder<FiringField> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.CreationDt).IsRequired();
            builder.Property(x => x.IsCovered).IsRequired();
            builder.Property(x => x.Address).IsRequired();
            //builder.Property(x => x.Rating).IsRequired();

            //builder.HasMany(x => x.Reviews).WithOne(x => x.FiringField).HasForeignKey(x => x.FiringFieldId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
