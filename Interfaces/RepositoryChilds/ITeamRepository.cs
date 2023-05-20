using AirsoftClub.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Interfaces.RepositoryChilds
{
    public interface ITeamRepository
    {
        public Task<IEnumerable<Team>> GetAllAsync();
        public Task<Team> GetAsync(Guid id);
        public Task PostAsync(Guid userId, Team entity);
        public Task PutAsync(Guid id, Team entity);
        public Task DeleteAsync(Guid id);
    }
}
