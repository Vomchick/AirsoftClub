using AirsoftClub.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Infrastructure.Data
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly IDbContextFactory<AirsoftClubDbContext> dbContextFactory;

        public DbContextFactory(IDbContextFactory<AirsoftClubDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public IDefaultContext GetDefaultContext()
        {
            return dbContextFactory.CreateDbContext();
        }
    }
}
