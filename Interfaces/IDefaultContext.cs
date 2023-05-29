using AirsoftClub.Domain.Core.Models;
using AirsoftClub.Domain.Core.Models.InfoPost;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Interfaces
{
    public interface IDefaultContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Club> Clubs { get; set; }
        DbSet<Player> Players { get; set; }
        DbSet<Team> Teams { get; set; }
        DbSet<FiringField> FiringFields { get; set; }
        DbSet<Game> Games { get; set; }
        DbSet<PlayerInfoPost> PlayerInfoPosts { get; set; }
        DbSet<TeamInfoPost> TeamInfoPosts { get; set; }
        DbSet<ClubInfoPost> ClubInfoPosts { get; set; }
        //DbSet<Review> Reviews { get; set; }
        DbSet<SoloRecord> SoloRecords { get; set; }
        DbSet<TeamRecord> TeamRecords { get; set; }
        DbSet<TeamRequest> TeamRequests { get; set; }
    }
}
