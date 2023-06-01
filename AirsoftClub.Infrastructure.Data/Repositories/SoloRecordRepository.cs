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
    public class SoloRecordRepository : ISoloRecordRepository
    {
        private readonly AirsoftClubDbContext context;
        public SoloRecordRepository(AirsoftClubDbContext context)
        {
            this.context = context;
        }
        public async Task DeleteAsync(Guid userId, Guid gameId)
        {
            var player = await GetPlayer(userId);
            if (player != null)
            {
                var record = await context.SoloRecords.FirstOrDefaultAsync(x => x.Player == player && x.GameId == gameId).ConfigureAwait(false);
                if (record != null)
                {
                    context.SoloRecords.Remove(record);
                    await context.SaveChangesAsync().ConfigureAwait(false);
                }
            }
        }

        public async Task<SoloRecord> GetAsync(Guid userId, Guid gameId)
        {
            var player = await GetPlayer(userId);
            if (player != null)
            {
                var record = await context.SoloRecords.FirstOrDefaultAsync(x => x.Player == player && x.GameId == gameId).ConfigureAwait(false);
                return record;
            }
            return null;
        }

        public async Task<IEnumerable<SoloRecord>> GetAllAsync(Guid userId)
        {
            var player = await GetPlayer(userId);
            if (player != null)
            {
                var records = await context.SoloRecords.Where(x => x.Player == player).ToListAsync().ConfigureAwait(false);
                return records;
            }
            return null;
        }

        public async Task PostAsync(Guid userId, SoloRecord entity)
        {
            var player = await GetPlayer(userId);
            if (player != null)
            {
                entity.Player = player;
                await context.SoloRecords.AddAsync(entity).ConfigureAwait(false);
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task PutAsync(Guid userId, SoloRecord entity)
        {
            var player = await GetPlayer(userId);
            if (player != null)
            {
                var record = await context.SoloRecords.FirstOrDefaultAsync(x => x.Player == player && x.GameId == entity.GameId).ConfigureAwait(false);
                if (record != null)
                {
                    record.NeedARent = entity.NeedARent;
                    record.PickUp = entity.PickUp;
                    await context.SaveChangesAsync().ConfigureAwait(false);
                }
            }
        }

        private async Task<Player?> GetPlayer(Guid userId) => await context.Players.FirstOrDefaultAsync(x => x.UserId == userId).ConfigureAwait(false);
    }
}
