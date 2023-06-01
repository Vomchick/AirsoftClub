using AirsoftClub.Domain.Core.Enums;
using AirsoftClub.Domain.Core.Models;
using AirsoftClub.Domain.Core.ValidationModels;
using AirsoftClub.Domain.Interfaces.RepositoryChilds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

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
            if (found.Team != null && found.TeamRole == TeamRole.Commander)
            {
                _context.Teams.Remove(found.Team);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task<int> GetPeopleCount(Guid teamId)
        {
            var people = await _context.Players.Where(x => x.TeamId == teamId).CountAsync().ConfigureAwait(false);
            return people;
        }

        public async Task<IEnumerable<(Team, bool)>> GetAllAsync(Guid userId)
        {
            var teams = await _context.Teams.ToListAsync().ConfigureAwait(false);
            var requests = await _context.TeamRequests.ToListAsync().ConfigureAwait(false);
            var player = await _context.Players.FirstOrDefaultAsync(x => x.UserId == userId).ConfigureAwait(false);
            var ret = new List<(Team, bool)>();
            foreach (var team in teams)
            {
                if (player != null && requests.Any(x => x.Team == team && x.Player == player))
                {
                    ret.Add((team, true));
                    continue;
                }
                ret.Add((team, false));
            }
            return ret;
        }

        public async Task<Team> GetAsync(Guid id)
        {
            var found = await _context.Teams.Include(x => x.Players).FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            return found;
        }

        public async Task<Team> GetPersonalAsync(Guid userId)
        {
            var found = await _context.Players.Include(x => x.Team).FirstOrDefaultAsync(x => x.UserId == userId).ConfigureAwait(false);
            return found.Team;
        }

        public async Task PostAsync(Guid userId, Team entity)
        {
            var user = await _context.Players.FirstOrDefaultAsync(x => x.UserId == userId).ConfigureAwait(false);
            if (user != null)
            {
                var addedTeam = await _context.Teams.AddAsync(entity).ConfigureAwait(false);
                await _context.SaveChangesAsync().ConfigureAwait(false);

                user.Team = addedTeam.Entity;
                user.TeamRole = TeamRole.Commander;
            }
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task PutAsync(Guid id, Team entity)
        {
            var found = await _context.Players.Include(x => x.Team).FirstOrDefaultAsync(x => x.UserId ==  id).ConfigureAwait(false);
            if (found.Team != null && found.TeamRole != TeamRole.Member)
            {
                found.Team.Name = entity.Name;
                found.Team.Description = entity.Description;
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task<TeamRole?> GetRightsAsync(Guid userId, Guid teamId)
        {
            var found = await _context.Players.FirstOrDefaultAsync(x => x.UserId == userId).ConfigureAwait(false);
            if (found != null && found.TeamId != null && found.TeamId == teamId)
            {
                return (TeamRole)found.TeamRole;
            }
            return null;
        }

        public async Task CreateRequest(Guid userId, CreationTeamRequestModel request)
        {
            var player = await _context.Players.Include(x => x.Team).FirstOrDefaultAsync(x => x.UserId == userId).ConfigureAwait(false);
            if (player != null && player.Team == null)
            {
                await _context.TeamRequests.AddAsync(new TeamRequest { 
                    PlayerId = player.Id, 
                    TeamId = request.TeamId, 
                    Description = request.Description
                }).ConfigureAwait(false);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<TeamRequest>> GetAllRequests(Guid teamId)
        {
            var found = await _context.TeamRequests.Include(x => x.Player).Where(x => x.TeamId == teamId).ToListAsync().ConfigureAwait(false);
            return found;
        }

        public async Task PositiveRequest(TeamRequestModel response)
        {
            var player = await _context.Players.FirstOrDefaultAsync(x => x.UserId == response.UserId).ConfigureAwait(false);
            var teamRequest = await _context.TeamRequests.FirstOrDefaultAsync(x => x.TeamId == response.TeamId && x.PlayerId == player.Id)
                    .ConfigureAwait(false);
            if (player != null && teamRequest != null)
            {
                _context.TeamRequests.Remove(teamRequest);
                player.TeamId = response.TeamId;
                player.TeamRole = response.TeamRole;
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task NegativeRequest(TeamRequestModel response)
        {
            var player = await _context.Players.FirstOrDefaultAsync(x => x.UserId == response.UserId).ConfigureAwait(false);
            var teamRequest = await _context.TeamRequests.FirstOrDefaultAsync(x => x.TeamId == response.TeamId && x.PlayerId == player.Id)
                    .ConfigureAwait(false);
            if (player != null && teamRequest != null)
            {
                _context.TeamRequests.Remove(teamRequest);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
