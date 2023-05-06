using AirsoftClub.Domain.Core.Models;

namespace AirsoftClub.Domain.Interfaces.RepositoryChilds
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public Task<User> Authenticate(string username, string password);
    }
}
