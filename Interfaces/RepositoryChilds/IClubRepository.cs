using AirsoftClub.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Interfaces.RepositoryChilds
{
    public interface IClubRepository
    {
        public Task<IEnumerable<(Club, bool)>> GetAllAsync(Guid userId);
        public Task<(Club, bool)> GetAsync(Guid clubId, Guid userId);
        public Task PostAsync(Guid userId, Club entity);
        public Task PutAsync(Guid userId, Guid clubId, Club entity);
        public Task DeleteAsync(Guid userId, Guid clubId);
        public Task<Club> GetPersonalAsync(Guid userId);
        public Task<IEnumerable<Club>> GetAllMyAsync(Guid id);
        public Task JoinClub(Guid userId, Guid clubId);
        public Task LeaveClub(Guid userId, Guid clubId);
        public Task<bool> GetRightsAsync(Guid userId, Guid clubId);
    }
}
