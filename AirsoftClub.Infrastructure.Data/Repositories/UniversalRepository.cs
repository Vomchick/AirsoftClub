using AirsoftClub.Domain.Core.Models;
using AirsoftClub.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Infrastructure.Data.Repositories
{
    public class UniversalRepository<T>: IBaseRepository<T> where T : class
    {
        protected readonly AirsoftClubDbContext context;

        public UniversalRepository(AirsoftClubDbContext context)
        {
            this.context = context;
        }

        public async Task DeleteAsync(Guid id)
        {
            var found = await context.FindAsync<T>(id).ConfigureAwait(false);
            if (found != null)
            {
                context.Remove<T>(found);
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            switch (typeof(T).Name)
            {
                case "User":
                    return (IEnumerable<T>)await context.Users.ToListAsync().ConfigureAwait(false);
                case "Club":
                    return (IEnumerable<T>)await context.Clubs.ToListAsync().ConfigureAwait(false);
                case "ClubPlayer":
                    return (IEnumerable<T>)await context.ClubPlayers.ToListAsync().ConfigureAwait(false);
                case "FiringField":
                    return (IEnumerable<T>)await context.FiringFields.ToListAsync().ConfigureAwait(false);
                case "Game":
                    return (IEnumerable<T>)await context.Games.ToListAsync().ConfigureAwait(false);
                case "Player":
                    return (IEnumerable<T>)await context.Players.ToListAsync().ConfigureAwait(false);
                case "SoloRecord":
                    return (IEnumerable<T>)await context.SoloRecords.ToListAsync().ConfigureAwait(false);
                case "Team":
                    return (IEnumerable<T>)await context.Teams.ToListAsync().ConfigureAwait(false);
                case "TeamRecord":
                    return (IEnumerable<T>)await context.TeamRecords.ToListAsync().ConfigureAwait(false);
                case "ClubInfoPost":
                    return (IEnumerable<T>)await context.ClubInfoPosts.ToListAsync().ConfigureAwait(false);
                case "PlayerInfoPost":
                    return (IEnumerable<T>)await context.PlayerInfoPosts.ToListAsync().ConfigureAwait(false);
                case "TeamInfoPost":
                    return (IEnumerable<T>)await context.TeamInfoPosts.ToListAsync().ConfigureAwait(false);
                default:
                    throw new Exception($"No such type as {typeof(T)}");
            }
        }

        public async Task<T> GetAsync(Guid id)
        {
            var found = await context.FindAsync<T>(id).ConfigureAwait(false);
            return found;
        }

        public async Task PostAsync(T entity)
        {
            await context.AddAsync<T>(entity).ConfigureAwait(false);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task PutAsync(Guid id, T entity)
        {
            var found = await context.FindAsync<T>(id).ConfigureAwait(false);
            if (found != null)
            {
                foreach (var property in Type.GetType(typeof(T).Name).GetProperties())
                {
                    if (property.Name == "Id")
                        continue;
                    property.SetValue(found, Type.GetType(typeof(T).Name).GetProperty(property.Name).GetValue(entity));
                }
            }
        }
    }
}
