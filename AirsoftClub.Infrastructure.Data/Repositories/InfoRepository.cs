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
        public async Task<IEnumerable<InfoPostResponseModel>> GetNewsAsync()
        {
            var playerPosts = await context.PlayerInfoPosts.Include(x => x.Author).ToListAsync().ConfigureAwait(false);
            var teamPosts = await context.TeamInfoPosts.Include(x => x.Author).ToListAsync().ConfigureAwait(false);
            var clubPosts = await context.ClubInfoPosts.Include(x => x.Author).ToListAsync().ConfigureAwait(false);

            var allPosts = new List<InfoPostResponseModel>();
            foreach (var post in playerPosts)
            {
                allPosts.Add(new InfoPostResponseModel
                {
                    Id = post.Id,
                    AuthorId = post.AuthorId,
                    Text = post.Text,
                    CreationDt = post.CreationDt,
                    AuthorName = post.Author.CallSign,
                    AuthorType = AuthorType.Player
                });
            }
            foreach (var post in teamPosts)
            {
                allPosts.Add(new InfoPostResponseModel
                {
                    Id = post.Id,
                    AuthorId = post.AuthorId,
                    Text = post.Text,
                    CreationDt = post.CreationDt,
                    AuthorName = post.Author.Name,
                    AuthorType = AuthorType.Team
                });
            }
            foreach (var post in clubPosts)
            {
                allPosts.Add(new InfoPostResponseModel
                {
                    Id = post.Id,
                    AuthorId = post.AuthorId,
                    Text = post.Text,
                    CreationDt = post.CreationDt,
                    AuthorName = post.Author.Name,
                    AuthorType = AuthorType.Club
                });
            }
            allPosts.Sort((x, y) => DateTime.Compare(y.CreationDt, x.CreationDt));
            return allPosts;
        }

        public async Task<IEnumerable<InfoPostResponseModel>> GetAllAsync(AllInfoPosts info)
        {
            switch (info.AuthorType)
            {
                case AuthorType.Player:
                    {
                        var player = await context.Players.FirstOrDefaultAsync(x => x.UserId == info.AuthorId).ConfigureAwait(false);
                        var posts = await context.PlayerInfoPosts.Where(x => x.AuthorId == player.Id).ToListAsync().ConfigureAwait(false);
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
                                    CreationDt = post.CreationDt,
                                    AuthorName = player.CallSign,
                                    AuthorType = AuthorType.Player
                                });
                            }
                            retPosts.Sort((x, y) => DateTime.Compare(y.CreationDt, x.CreationDt));
                            return retPosts;
                        }
                        return null;
                    }
                case AuthorType.Team:
                    {
                        var posts = await context.TeamInfoPosts.Where(x => x.AuthorId == info.AuthorId).Include(x => x.Author).ToListAsync().ConfigureAwait(false);
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
                                    CreationDt = post.CreationDt,
                                    AuthorName = post.Author.Name,
                                    AuthorType = AuthorType.Team
                                });
                            }
                            retPosts.Sort((x, y) => DateTime.Compare(y.CreationDt, x.CreationDt));
                            return retPosts;
                        }
                        return null;
                    }

                case AuthorType.Club:
                    {
                        var posts = await context.ClubInfoPosts.Where(x => x.AuthorId == info.AuthorId).Include(x => x.Author).ToListAsync().ConfigureAwait(false);
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
                                    CreationDt = post.CreationDt,
                                    AuthorName = post.Author.Name,
                                    AuthorType = AuthorType.Club
                                });
                            }
                            retPosts.Sort((x, y) => DateTime.Compare(y.CreationDt, x.CreationDt));
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
                        var post = new TeamInfoPost { AuthorId = (Guid)infoPost.AuthorId, CreationDt = DateTime.Now, Text = infoPost.Text };
                        await context.TeamInfoPosts.AddAsync(post);
                        await context.SaveChangesAsync().ConfigureAwait(false);
                        break;
                    }

                case AuthorType.Club:
                    {
                        var post = new ClubInfoPost { AuthorId = (Guid)infoPost.AuthorId, CreationDt = DateTime.Now, Text = infoPost.Text };
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
