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
    public class GameRepository : IGameRepository
    {
        private readonly AirsoftClubDbContext context;
        public GameRepository(AirsoftClubDbContext context)
        {
            this.context = context;
        }

        public async Task DeleteAsync(Guid id, Guid userId)
        {
            var found = await context.Games.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            var player = await context.Players.Include(x => x.ClubPlayers).FirstOrDefaultAsync(x => x.UserId == userId).ConfigureAwait(false);
            if (found != null && player.ClubPlayers.Any(x => x.ClubId == found.ClubId && x.ClubRole == ClubRole.Admin))
            {
                context.Games.Remove(found);
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<Game>> GetAllAsync(Guid clubId)
        {
            var found = await context.Games.Where(x => x.ClubId == clubId).ToListAsync().ConfigureAwait(false);
            return found;
        }

        public async Task<Game> GetAsync(Guid id)
        {
            var found = await context.Games.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            return found;
        }

        public async Task PostAsync(Game entity, Guid clubId, Guid userId)
        {
            var player = await context.Players.Include(x => x.ClubPlayers).FirstOrDefaultAsync(x => x.UserId == userId).ConfigureAwait(false);
            if (player.ClubPlayers.Any(x => x.ClubId == clubId && x.ClubRole == ClubRole.Admin))
            {
                entity.ClubId = clubId;
                entity.CreationDt = DateTime.Now;
                await context.Games.AddAsync(entity).ConfigureAwait(false);
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task PutAsync(Guid gameId, Game entity, Guid userId)
        {
            var found = await context.Games.FirstOrDefaultAsync(x => x.Id == gameId).ConfigureAwait(false);
            var player = await context.Players.Include(x => x.ClubPlayers).FirstOrDefaultAsync(x => x.UserId == userId).ConfigureAwait(false);
            if (found != null && player.ClubPlayers.Any(x => x.ClubId == found.ClubId && x.ClubRole == ClubRole.Admin))
            {
                found.Name = entity.Name;
                found.Text = entity.Text;
                found.RentalPrice = entity.RentalPrice;
                found.DefaultPrice = entity.DefaultPrice;
                found.StartDt = entity.StartDt;
                found.GameType = entity.GameType;
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
