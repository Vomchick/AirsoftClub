﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AirsoftClub.Domain.Core.Models
{
    public class TeamRecord
    {
        public Guid Id { get; set; }
        public int PeopleCount { get; set; }
        public Guid TeamId { get; set; }
        public Guid GameId { get; set; }

        public Game Game { get; set; }
        public Team Team { get; set; }
    }

    internal class TeamRecordMap : IEntityTypeConfiguration<TeamRecord>
    {
        public static TeamRecordMap Instance = new();

        public void Configure(EntityTypeBuilder<TeamRecord> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.PeopleCount).IsRequired();
        }
    }
}
