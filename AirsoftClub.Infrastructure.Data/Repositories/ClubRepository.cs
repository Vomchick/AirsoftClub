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
    public class ClubRepository : IClubRepository
    {
        private readonly AirsoftClubDbContext _context;

        public ClubRepository(AirsoftClubDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(Guid userId, Guid clubId)
        {
            var found = await _context.Players.Include(x => x.Clubs).Include(x => x.ClubPlayers).FirstOrDefaultAsync(x => x.UserId == userId).ConfigureAwait(false);
            if (found.ClubPlayers != null && found.ClubPlayers.Any(x => x.ClubId == clubId && x.ClubRole == ClubRole.Admin))
            {
                var adminedClub = found.ClubPlayers.FirstOrDefault(x => x.ClubId == clubId && x.ClubRole == ClubRole.Admin).Club;
                _context.Clubs.Remove(adminedClub);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task<bool> GetRightsAsync(Guid userId, Guid clubId)
        {
            var found = await _context.Players.Include(x => x.Clubs).Include(x => x.ClubPlayers).FirstOrDefaultAsync(x => x.UserId == userId).ConfigureAwait(false);
            if (found.ClubPlayers != null)
            {
                return found.ClubPlayers.Any(x => x.ClubId == clubId && x.ClubRole == ClubRole.Admin);
            }
            return false;
        }

        public async Task<IEnumerable<(Club, bool)>> GetAllAsync(Guid userId)
        {
            var clubs = await _context.Clubs.Include(x => x.Players).ToListAsync().ConfigureAwait(false);
            var player = await _context.Players.FirstOrDefaultAsync(x => x.UserId == userId).ConfigureAwait(false);
            var ret = new List<(Club, bool)>();
            foreach(var club in clubs)
            {
                if(club.Players != null && player != null && club.Players.Contains(player))
                {
                    ret.Add((club, true));
                    continue;
                }
                ret.Add((club, false));
            }
            return ret;
        }

        public async Task<(Club, bool)> GetAsync(Guid clubId, Guid userId)
        {
            var club = await _context.Clubs.Include(x => x.Players).FirstOrDefaultAsync(x => x.Id == clubId).ConfigureAwait(false);
            var player = await _context.Players.FirstOrDefaultAsync(x => x.UserId == userId).ConfigureAwait(false);
            if (club.Players != null && player != null && club.Players.Contains(player))
                return (club, true);
            else
                return (club, false);
        }

        public async Task<Club> GetPersonalAsync(Guid userId)
        {
            var found = await _context.Players.Include(x => x.Clubs).Include(x => x.ClubPlayers).FirstOrDefaultAsync(x => x.UserId == userId).ConfigureAwait(false);
            if (found != null && found.ClubPlayers.Any(x => x.ClubRole == ClubRole.Admin))
            {
                return found.ClubPlayers.FirstOrDefault(x => x.ClubRole == ClubRole.Admin).Club;
            }
            return null;
        }

        public async Task<IEnumerable<Club>> GetAllMyAsync(Guid userId)
        {
            var found = await _context.Players.Include(x => x.Clubs).FirstOrDefaultAsync(x => x.UserId == userId).ConfigureAwait(false);
            return found.Clubs;
        }

        public async Task PostAsync(Guid userId, Club entity)
        {
            var user = await _context.Players.Include(x => x.ClubPlayers).FirstOrDefaultAsync(x => x.UserId == userId).ConfigureAwait(false);
            if (user != null)
            {
                var addedClub = await _context.Clubs.AddAsync(entity).ConfigureAwait(false);
                user.ClubPlayers.Add(new ClubPlayer 
                { 
                    Player = user,
                    Club = addedClub.Entity,
                    ClubRole = ClubRole.Admin
                });
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            
        }

        public async Task PutAsync(Guid userId, Guid clubId, Club entity)
        {
            var found = await _context.Players.Include(x => x.Clubs).Include(x => x.ClubPlayers).FirstOrDefaultAsync(x => x.UserId == userId).ConfigureAwait(false);
            if (found.ClubPlayers != null && found.ClubPlayers.Any(x => x.ClubId == clubId && x.ClubRole == ClubRole.Admin))
            {
                var adminedClub = found.ClubPlayers.FirstOrDefault(x => x.ClubId == clubId && x.ClubRole == ClubRole.Admin).Club;
                adminedClub.Name = entity.Name;
                adminedClub.Description = entity.Description;
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task JoinClub(Guid userId, Guid clubId)
        {
            var foundClub = await _context.Clubs.FirstOrDefaultAsync(x => x.Id == clubId).ConfigureAwait(false);
            var found = await _context.Players.Include(x => x.Clubs).Include(x => x.ClubPlayers).FirstOrDefaultAsync(x => x.UserId == userId).ConfigureAwait(false);
            if (found != null && !found.Clubs.Contains(foundClub))
            {
                found.ClubPlayers.Add(new ClubPlayer
                {
                    Club = foundClub,
                    Player = found,
                    ClubRole = ClubRole.Member
                });
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task LeaveClub(Guid userId, Guid clubId)
        {
            var foundClub = await _context.Clubs.FirstOrDefaultAsync(x => x.Id == clubId).ConfigureAwait(false);
            var found = await _context.Players.Include(x => x.Clubs).Include(x => x.ClubPlayers).FirstOrDefaultAsync(x => x.UserId == userId).ConfigureAwait(false);
            if (found != null && found.Clubs.Contains(foundClub))
            {
                var record = found.ClubPlayers.FirstOrDefault(x => x.Club == foundClub);
                _context.ClubPlayers.Remove(record);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
