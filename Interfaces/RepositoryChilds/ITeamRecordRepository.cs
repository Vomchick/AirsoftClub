using AirsoftClub.Domain.Core.Enums;
using AirsoftClub.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Interfaces.RepositoryChilds
{
    public interface ITeamRecordRepository
    {
        public Task DeleteAsync(Guid userId, Guid gameId);
        public Task<TeamRecord> GetAsync(Guid userId, Guid gameId);
        public Task PostAsync(Guid userId, Guid gameId, int peopleCount);
        public Task PutAsync(Guid userId, Guid gameId, int peopleCount);
        public Task<IEnumerable<TeamRecord>> GetAllAsync(Guid userId);
    }
}
