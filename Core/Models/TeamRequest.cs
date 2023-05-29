using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Core.Models
{
    public class TeamRequest
    {
        public Guid TeamId { get; set; }
        public Guid PlayerId { get; set; }
        public string? Description { get; set; }
        //public bool Decision { get; set; }
        //public bool Actual { get; set; }
        public Team Team { get; set; }
        public Player Player { get; set; }
    }

    internal class TeamRequestMap : IEntityTypeConfiguration<TeamRequest>
    {
        public static TeamRequestMap Instance = new();

        public void Configure(EntityTypeBuilder<TeamRequest> builder)
        {
            builder.HasKey(t => new { t.TeamId, t.PlayerId });

            builder.HasOne(x => x.Player).WithMany(x => x.TeamRequests).HasForeignKey(x => x.PlayerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Team).WithMany(x => x.TeamRequests).HasForeignKey(x => x.TeamId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
