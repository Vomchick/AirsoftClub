using AirsoftClub.Domain.Core.Enums;
using AirsoftClub.Domain.Core.Models;
using AirsoftClub.Domain.Core.Models.InfoPost;
using AirsoftClub.Domain.Core.ResponseModels;
using AirsoftClub.Domain.Core.ValidationModels;
using AirsoftClub.Domain.Interfaces.RepositoryChilds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AirsoftClub.Infrastructure.Data.Repositories
{
    public class InfoRepository: IInfoRepository
    {
        private readonly AirsoftClubDbContext context;
        public InfoRepository(AirsoftClubDbContext context)
        {
            this.context = context;
        }
        
        public async Task DeleteAsync(InfoPostModel infoPost, Guid postId)
        {
            switch (infoPost.AuthorType)
            {
                case AuthorType.Player:
                    {
                        var player = await context.Players.FirstOrDefaultAsync(x => x.UserId == infoPost.AuthorId).ConfigureAwait(false);
                        var post = await context.PlayerInfoPosts.FirstOrDefaultAsync(x => x.AuthorId == player.Id && x.Id == postId)
                            .ConfigureAwait(false);
                        if(post != null)
                        {
                            context.PlayerInfoPosts.Remove(post);
                            await context.SaveChangesAsync().ConfigureAwait(false);
                        }
                        break;
                    }
                case AuthorType.Team:
                    {
                        var post = await context.TeamInfoPosts.FirstOrDefaultAsync(x => x.AuthorId == infoPost.AuthorId && x.Id == postId)
                            .ConfigureAwait(false);
                        if (post != null)
                        {
                            context.TeamInfoPosts.Remove(post);
                            await context.SaveChangesAsync().ConfigureAwait(false);
                        }
                        break;
                    }
                    
                case AuthorType.Club:
                    {
                        var post = await context.ClubInfoPosts.FirstOrDefaultAsync(x => x.AuthorId == infoPost.AuthorId && x.Id == postId)
                            .ConfigureAwait(false);
                        if (post != null)
                        {
                            context.ClubInfoPosts.Remove(post);
                            await context.SaveChangesAsync().ConfigureAwait(false);
                        }
                        break;
                    }
            }
        }

        public async Task<IEnumerable<InfoPostResponseModel>> GetAllAsync(AllInfoPosts info)
        {
            switch (info.AuthorType)
            {
                case AuthorType.Player:
                    {
                        var posts = await context.PlayerInfoPosts.Where(x => x.AuthorId == info.AuthorId).ToListAsync().ConfigureAwait(false);
                        if (posts != null)
                        {
                            var retPosts = new List<InfoPostResponseModel>();
                            foreach (var post in posts)
                            {
                                retPosts.Add(new InfoPostResponseModel
                                {
                                    Id = post.Id,
                                    AuthorId = post.AuthorId,
                                    Text = post.Text,
                                });
                            }
                            return retPosts;
                        }
                        return null;
                    }
                case AuthorType.Team:
                    {
                        var posts = await context.TeamInfoPosts.Where(x => x.AuthorId == info.AuthorId).ToListAsync().ConfigureAwait(false);
                        if (posts != null)
                        {
                            var retPosts = new List<InfoPostResponseModel>();
                            foreach (var post in posts)
                            {
                                retPosts.Add(new InfoPostResponseModel
                                {
                                    Id = post.Id,
                                    AuthorId = post.AuthorId,
                                    Text = post.Text,
                                });
                            }
                            return retPosts;
                        }
                        return null;
                    }

                case AuthorType.Club:
                    {
                        var posts = await context.ClubInfoPosts.Where(x => x.AuthorId == info.AuthorId).ToListAsync().ConfigureAwait(false);
                        if (posts != null)
                        {
                            var retPosts = new List<InfoPostResponseModel>();
                            foreach (var post in posts)
                            {
                                retPosts.Add(new InfoPostResponseModel
                                {
                                    Id = post.Id,
                                    AuthorId = post.AuthorId,
                                    Text = post.Text,
                                });
                            }
                            return retPosts;
                        }
                        return null;
                    }
                default: return null;
            }
        }

        public async Task PostAsync(InfoPostModel infoPost)
        {
            switch (infoPost.AuthorType)
            {
                case AuthorType.Player:
                    {
                        var player = await context.Players.FirstOrDefaultAsync(x => x.UserId == infoPost.AuthorId).ConfigureAwait(false);
                        if (player != null)
                        {
                            var post = new PlayerInfoPost { AuthorId = player.Id, CreationDt = DateTime.Now, Text = infoPost.Text };
                            await context.PlayerInfoPosts.AddAsync(post);
                            await context.SaveChangesAsync().ConfigureAwait(false);
                        }
                        break;
                    }
                case AuthorType.Team:
                    {
                        var post = new TeamInfoPost { AuthorId = infoPost.AuthorId, CreationDt = DateTime.Now, Text = infoPost.Text };
                        await context.TeamInfoPosts.AddAsync(post);
                        await context.SaveChangesAsync().ConfigureAwait(false);
                        break;
                    }

                case AuthorType.Club:
                    {
                        var post = new ClubInfoPost { AuthorId = infoPost.AuthorId, CreationDt = DateTime.Now, Text = infoPost.Text };
                        await context.ClubInfoPosts.AddAsync(post);
                        await context.SaveChangesAsync().ConfigureAwait(false);
                        break;
                    }
            }
        }

        public async Task PutAsync(InfoPostModel infoPost, Guid postId)
        {
            switch (infoPost.AuthorType)
            {
                case AuthorType.Player:
                    {
                        var player = await context.Players.FirstOrDefaultAsync(x => x.UserId == infoPost.AuthorId).ConfigureAwait(false);
                        var post = await context.PlayerInfoPosts.FirstOrDefaultAsync(x => x.AuthorId == player.Id && x.Id == postId)
                            .ConfigureAwait(false);
                        if (post != null)
                        {
                            post.Text = infoPost.Text;
                            await context.SaveChangesAsync().ConfigureAwait(false);
                        }
                        break;
                    }
                case AuthorType.Team:
                    {
                        var post = await context.TeamInfoPosts.FirstOrDefaultAsync(x => x.AuthorId == infoPost.AuthorId && x.Id == postId)
                            .ConfigureAwait(false);
                        if (post != null)
                        {
                            post.Text = infoPost.Text;
                            await context.SaveChangesAsync().ConfigureAwait(false);
                        }
                        break;
                    }

                case AuthorType.Club:
                    {
                        var post = await context.ClubInfoPosts.FirstOrDefaultAsync(x => x.AuthorId == infoPost.AuthorId && x.Id == postId)
                            .ConfigureAwait(false);
                        if (post != null)
                        {
                            post.Text = infoPost.Text;
                            await context.SaveChangesAsync().ConfigureAwait(false);
                        }
                        break;
                    }
            }
        }
    }
}
