using AirsoftClub.Domain.Core.Models;
using AirsoftClub.Domain.Interfaces.RepositoryChilds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Infrastructure.Data.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly AirsoftClubDbContext context;
        public PlayerRepository(AirsoftClubDbContext context)
        {
            this.context = context;
        }

        public async Task DeleteAsync(Guid id)
        {
            var found = await context.Players.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            if (found != null)
            {
                context.Players.Remove(found);
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            var all = await context.Players.ToListAsync().ConfigureAwait(false);
            return all;
        }

        public async Task<Player> GetAsync(Guid id)
        {
            var found = await context.Players.Include(x => x.Team).FirstOrDefaultAsync(x => x.UserId == id).ConfigureAwait(false);
            if (found != null && found.Photo != null)
                found.Photo = GetImage(Convert.ToBase64String(found.Photo));
            return found;
        }

        public async Task<Player> GetByUsername(string username)
        {
            var found = await context.Users.Include(x => x.Player).FirstOrDefaultAsync(x => x.Name == username).ConfigureAwait(false);
            return found.Player;
        }

        public async Task PostAsync(Player entity, Guid id)
        {
            entity.UserId = id;
            await context.Players.AddAsync(entity).ConfigureAwait(false);
            await context.SaveChangesAsync().ConfigureAwait(false);  
        }

        public async Task PutAsync(Guid id, Player entity)
        {
            var found = await context.Players.FirstOrDefaultAsync(x => x.UserId == id).ConfigureAwait(false);
            if (found != null)
            {
                found.CallSign = entity.CallSign;
                found.Description = entity.Description;
                found.Team = entity.Team;
                found.GameRole = entity.GameRole;
                found.TeamRole = entity.TeamRole;
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task SafeFile(Guid id, byte[] bytes)
        {
            var found = await context.Players.FirstOrDefaultAsync(x => x.UserId == id).ConfigureAwait(false);
            if (found != null)
            {
                found.Photo = bytes;
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        private byte[] GetImage(string sBase64String)
        {
            byte[] bytes = null;
            if (!string.IsNullOrEmpty(sBase64String))
            {
                bytes = Convert.FromBase64String(sBase64String);
            }
            return bytes;
        }
    }
}
