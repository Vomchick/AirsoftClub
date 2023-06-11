using AirsoftClub.Domain.Core.Models;
using AirsoftClub.Domain.Core.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Interfaces.RepositoryChilds
{
    public interface IGameRepository
    {
        public Task DeleteAsync(Guid id, Guid userId);
        public Task<IEnumerable<Game>> GetAllAsync(Guid clubId);
        public Task<Game> GetAsync(Guid id);
        public Task PostAsync(Game entity, Guid clubId, Guid userId);
        public Task PutAsync(Guid gameId, Game entity, Guid userId);
        public Task<StatisticResponseModel> GetStatistic(Guid gameId);
    }
}
