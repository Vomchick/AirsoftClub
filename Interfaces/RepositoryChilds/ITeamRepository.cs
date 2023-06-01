using AirsoftClub.Domain.Core.Enums;
using AirsoftClub.Domain.Core.Models;
using AirsoftClub.Domain.Core.ValidationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Interfaces.RepositoryChilds
{
    public interface ITeamRepository
    {
        public Task<IEnumerable<(Team, bool)>> GetAllAsync(Guid userId);
        public Task<Team> GetAsync(Guid id);
        public Task PostAsync(Guid userId, Team entity);
        public Task PutAsync(Guid id, Team entity);
        public Task DeleteAsync(Guid userId);
        public Task<Team> GetPersonalAsync(Guid userId);
        public Task<TeamRole?> GetRightsAsync(Guid userId, Guid teamId);
        public Task CreateRequest(Guid userId, CreationTeamRequestModel request);
        public Task PositiveRequest(TeamRequestModel response);
        public Task NegativeRequest(TeamRequestModel response);
        public Task<IEnumerable<TeamRequest>> GetAllRequests(Guid teamId);
        public Task<int> GetPeopleCount(Guid teamId);
    }
}
