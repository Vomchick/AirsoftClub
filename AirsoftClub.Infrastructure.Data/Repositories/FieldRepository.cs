using AirsoftClub.Domain.Core.Enums;
using AirsoftClub.Domain.Core.Models;
using AirsoftClub.Domain.Interfaces;
using AirsoftClub.Domain.Interfaces.RepositoryChilds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Infrastructure.Data.Repositories
{
    public class FieldRepository : IFieldRepository
    {
        private readonly AirsoftClubDbContext context;
        public FieldRepository(AirsoftClubDbContext context)
        {
            this.context = context;
        }

        public async Task DeleteAsync(Guid id, Guid userId)
        {
            var found = await context.FiringFields.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            var player = await context.Players.Include(x => x.ClubPlayers).FirstOrDefaultAsync(x => x.UserId == userId).ConfigureAwait(false);
            if (found != null && player.ClubPlayers.Any(x => x.ClubId == found.ClubId && x.ClubRole == ClubRole.Admin))
            {
                context.FiringFields.Remove(found);
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<FiringField>> GetAllAsync(Guid clubId)
        {
            var found = await context.FiringFields.Where(x => x.ClubId == clubId).ToListAsync().ConfigureAwait(false);
            return found;
        }

        public async Task<FiringField> GetAsync(Guid id)
        {
            var found = await context.FiringFields.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            return found;
        }

        public async Task PostAsync(FiringField entity, Guid clubId, Guid userId)
        {
            var player = await context.Players.Include(x => x.ClubPlayers).FirstOrDefaultAsync(x => x.UserId == userId).ConfigureAwait(false);
            if (player.ClubPlayers.Any(x => x.ClubId == clubId && x.ClubRole == ClubRole.Admin))
            {
                entity.ClubId = clubId;
                entity.CreationDt = DateTime.Now;
                await context.FiringFields.AddAsync(entity).ConfigureAwait(false);
                await context.SaveChangesAsync().ConfigureAwait(false);
            }  
        }

        public async Task PutAsync(Guid fieldId, FiringField entity, Guid userId)
        {
            var found = await context.FiringFields.FirstOrDefaultAsync(x => x.Id == fieldId).ConfigureAwait(false);
            var player = await context.Players.Include(x => x.ClubPlayers).FirstOrDefaultAsync(x => x.UserId == userId).ConfigureAwait(false);
            if (found != null && player.ClubPlayers.Any(x => x.ClubId == found.ClubId && x.ClubRole == ClubRole.Admin))
            {
                found.GPS = entity.GPS;
                found.Text = entity.Text;
                found.Address = entity.Address;
                found.IsCovered = entity.IsCovered;
                found.Name = entity.Name;
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
