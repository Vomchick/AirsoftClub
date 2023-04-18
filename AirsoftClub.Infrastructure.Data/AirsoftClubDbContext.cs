using AirsoftClub.Domain.Core.Models.InfoPost;
using AirsoftClub.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirsoftClub.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;
using AirsoftClub.Domain.Core.Configuration;
using AirsoftClub.Infrastructure.Data.InitData;

namespace AirsoftClub.Infrastructure.Data
{
    public class AirsoftClubDbContext : DbContext, IDefaultContext
    {
        public AirsoftClubDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Mapping
            modelBuilder.RegisterModelMaps();

            InitDbData.OnModelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<FiringField> FiringFields { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<PlayerInfoPost> PlayerInfoPosts { get; set; }
        public DbSet<TeamInfoPost> TeamInfoPosts { get; set; }
        public DbSet<ClubInfoPost> ClubInfoPosts { get; set; }
        //public DbSet<Review> Reviews { get; set; }
        public DbSet<SoloRecord> SoloRecords { get; set; }
        public DbSet<TeamRecord> TeamRecords { get; set; }
        public DbSet<ClubPlayer> ClubPlayers { get; set; }
    }
}
