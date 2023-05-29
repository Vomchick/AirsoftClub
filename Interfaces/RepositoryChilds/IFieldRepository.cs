using AirsoftClub.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Interfaces.RepositoryChilds
{
    public interface IFieldRepository
    {
        public Task DeleteAsync(Guid id, Guid userId);
        public Task<IEnumerable<FiringField>> GetAllAsync(Guid clubId);
        public Task<FiringField> GetAsync(Guid id);
        public Task PostAsync(FiringField entity, Guid clubId, Guid userId);
        public Task PutAsync(Guid fieldId, FiringField entity, Guid userId);
    }
}
