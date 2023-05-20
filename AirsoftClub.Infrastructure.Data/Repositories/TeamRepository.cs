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
    public class TeamRepository : ITeamRepository
    {
        private readonly AirsoftClubDbContext _context;

        public TeamRepository(AirsoftClubDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(Guid id)
        {
            var found = await _context.Players.Include(x => x.Team).FirstOrDefaultAsync(x => x.UserId == id).ConfigureAwait(false);
            if (found.Team != null && found.TeamRole == Domain.Core.Enums.TeamRole.Commander)
            {
                _context.Teams.Remove(found.Team);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            var found = await _context.Teams.ToListAsync().ConfigureAwait(false);
            return found;
        }

        public async Task<Team> GetAsync(Guid id)
        {
            var found = await _context.Players.Include(x => x.Team).FirstOrDefaultAsync(x => x.UserId == id).ConfigureAwait(false);
            return found.Team;
        }

        public async Task PostAsync(Guid userId, Team entity)
        {
            var user = await _context.Players.FirstOrDefaultAsync(x => x.UserId == userId).ConfigureAwait(false);
            if (user != null)
            {
                var addedTeam = await _context.Teams.AddAsync(entity).ConfigureAwait(false);
                user.Team = addedTeam.Entity;
                user.TeamRole = Domain.Core.Enums.TeamRole.Commander;
            }
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task PutAsync(Guid id, Team entity)
        {
            var found = await _context.Players.Include(x => x.Team).FirstOrDefaultAsync(x => x.UserId ==  id).ConfigureAwait(false);
            if (found.Team != null && found.TeamRole == Domain.Core.Enums.TeamRole.Commander)
            {
                found.Team.Name = entity.Name;
                found.Team.Description = entity.Description;
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
