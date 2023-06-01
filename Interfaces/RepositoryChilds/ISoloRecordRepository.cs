using AirsoftClub.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Interfaces.RepositoryChilds
{
    public interface ISoloRecordRepository
    {
        public Task DeleteAsync(Guid userId, Guid gameId);
        public Task<SoloRecord> GetAsync(Guid userId, Guid gameId);
        public Task PostAsync(Guid userId, SoloRecord entity);
        public Task PutAsync(Guid userId, SoloRecord entity);
        public Task<IEnumerable<SoloRecord>> GetAllAsync(Guid userId);
    }
}
