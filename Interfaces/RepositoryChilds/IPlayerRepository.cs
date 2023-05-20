using AirsoftClub.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Interfaces.RepositoryChilds
{
    public interface IPlayerRepository
    {
        public Task<Player> GetByUsername(string username);
        public Task<IEnumerable<Player>> GetAllAsync();
        public Task<Player> GetAsync(Guid id);
        public Task PostAsync(Player entity, Guid id);
        public Task PutAsync(Guid id, Player entity);
        public Task DeleteAsync(Guid id);
        public Task SafeFile(Guid id, byte[] bytes);
    }
}
