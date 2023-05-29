using AirsoftClub.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Core.Configuration
{
    public static class ModelBuilderextensions
    {
        public static ModelBuilder RegisterModelMaps(this ModelBuilder builder)
        {
            builder.ApplyConfiguration(UserMap.Instance);
            builder.ApplyConfiguration(ClubMap.Instance);
            builder.ApplyConfiguration(FiringFieldMap.Instance);
            builder.ApplyConfiguration(GameMap.Instance);
            builder.ApplyConfiguration(PlayerMap.Instance);
            //builder.ApplyConfiguration(ReviewMap.Instance);
            builder.ApplyConfiguration(SoloRecordMap.Instance);
            builder.ApplyConfiguration(TeamMap.Instance);
            builder.ApplyConfiguration(TeamRecordMap.Instance);
            builder.ApplyConfiguration(TeamRequestMap.Instance);
            return builder;
        }
    }
}
