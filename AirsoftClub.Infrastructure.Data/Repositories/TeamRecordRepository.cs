using AirsoftClub.Domain.Core.Enums;
using AirsoftClub.Domain.Core.Models;
using AirsoftClub.Domain.Interfaces.RepositoryChilds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Infrastructure.Data.Repositories
{
    public class TeamRecordRepository : ITeamRecordRepository
    {
        private readonly AirsoftClubDbContext context;
        public TeamRecordRepository(AirsoftClubDbContext context)
        {
            this.context = context;
        }
        public async Task DeleteAsync(Guid userId, Guid gameId)
        {
            var player = await GetPlayer(userId);
            if (player.Team != null && player.TeamRole != TeamRole.Member)
            {
                var record = await context.TeamRecords.FirstOrDefaultAsync(x => x.Team == player.Team && x.GameId == gameId).ConfigureAwait(false);
                if (record != null)
                {
                    context.TeamRecords.Remove(record);
                    await context.SaveChangesAsync().ConfigureAwait(false);
                }
            }
        }

        public async Task<TeamRecord> GetAsync(Guid userId, Guid gameId)
        {
            var player = await GetPlayer(userId);
            if (player.Team != null && player.TeamRole != TeamRole.Member)
            {
                var record = await context.TeamRecords.FirstOrDefaultAsync(x => x.Team == player.Team && x.GameId == gameId).ConfigureAwait(false);
                return record;
            }
            return null;
        }

        public async Task<IEnumerable<TeamRecord>> GetAllAsync(Guid userId)
        {
            var player = await GetPlayer(userId);
            if (player.Team != null && player.TeamRole != TeamRole.Member)
            {
                var records = await context.TeamRecords.Where(x => x.Team == player.Team).ToListAsync().ConfigureAwait(false);
                return records;
            }
            return null;
        }

        public async Task PostAsync(Guid userId, Guid gameId, int peopleCount)
        {
            var player = await GetPlayer(userId);
            if (player.Team != null && player.TeamRole != TeamRole.Member)
            { 
                var entity = new TeamRecord { PeopleCount = peopleCount, Team = player.Team, GameId = gameId };
                await context.TeamRecords.AddAsync(entity).ConfigureAwait(false);
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task PutAsync(Guid userId, Guid gameId, int peopleCount)
        {
            var player = await GetPlayer(userId);
            if (player.Team != null && player.TeamRole != TeamRole.Member)
            {
                var record = await context.TeamRecords.FirstOrDefaultAsync(x => x.Team == player.Team && x.GameId == gameId).ConfigureAwait(false);
                if (record != null)
                {
                    record.PeopleCount = peopleCount;
                    await context.SaveChangesAsync().ConfigureAwait(false);
                }
            }
        }

        private async Task<Player?> GetPlayer(Guid userId) => await context.Players.Include(p => p.Team).FirstOrDefaultAsync(x => x.UserId == userId).ConfigureAwait(false);
    }
}
