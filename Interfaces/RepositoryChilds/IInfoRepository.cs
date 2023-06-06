using AirsoftClub.Domain.Core.Models;
using AirsoftClub.Domain.Core.ResponseModels;
using AirsoftClub.Domain.Core.ValidationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Domain.Interfaces.RepositoryChilds
{
    public interface IInfoRepository
    {
        public Task DeleteAsync(InfoPostModel infoPost, Guid postId);
        public Task PostAsync(InfoPostModel infoPost);
        public Task PutAsync(InfoPostModel infoPost, Guid postId);
        public Task<IEnumerable<InfoPostResponseModel>> GetAllAsync(AllInfoPosts info);
        public Task<IEnumerable<InfoPostResponseModel>> GetNewsAsync();
    }
}
