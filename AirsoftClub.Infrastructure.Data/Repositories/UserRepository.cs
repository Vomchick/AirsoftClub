using AirsoftClub.Domain.Core.Models;
using AirsoftClub.Domain.Interfaces.RepositoryChilds;
using Microsoft.EntityFrameworkCore;

namespace AirsoftClub.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AirsoftClubDbContext context;

        public UserRepository(AirsoftClubDbContext context)
        {
            this.context = context;
        }

        public async Task DeleteAsync(Guid id)
        {
            var found = await context.Users.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            if (found != null)
            {
                context.Users.Remove(found);
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var all = await context.Users.ToListAsync().ConfigureAwait(false);
            return all;
        }

        public async Task<User> GetAsync(Guid id)
        {
            var found = await context.Users.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            return found;
        }

        public async Task PostAsync(User entity)
        {
            await context.Users.AddAsync(entity).ConfigureAwait(false);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task PutAsync(Guid id, User entity)
        {
            var found = await context.Users.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            if (found != null)
            {
                found.Name = entity.Name;
                found.Password = entity.Password;
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
        public async Task<User> Authenticate(string username, string password)
        {
            return await context.Users.SingleOrDefaultAsync(x => x.Name == username && x.Password == password).ConfigureAwait(false);
        }
    }
}
