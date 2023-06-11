using AirsoftClub.Domain.Core.Enums;
using AirsoftClub.Domain.Core.ValidationModels;
using AirsoftClub.Domain.Interfaces.RepositoryChilds;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AirsoftClub.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class InfoController : ControllerBase
    {
        private readonly ILogger<RegistrationController> logger;
        private readonly IInfoRepository rep;

        private Guid UserId => Guid.Parse(User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value);

        public InfoController(ILogger<RegistrationController> logger, IInfoRepository rep)
        {
            this.logger = logger;
            this.rep = rep;
        }

        [HttpGet]
        [Route("news")]
        public async Task<IActionResult> GetNews()
        {
            try
            {
                var posts = await rep.GetNewsAsync();
                if (posts != null && posts.Count() > 0)
                    return Ok(posts);
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("all")]
        public async Task<IActionResult> GetAllInfoPosts(AllInfoPosts info)
        {
            try
            {
                if (info.AuthorType == AuthorType.Player) info.AuthorId = UserId;
                var posts = await rep.GetAllAsync(info);
                if (posts != null && posts.Count() > 0)
                {
                    
                    return Ok(posts);
                }
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddInfoPosts(InfoPostModel infoPost)
        {
            try
            {
                if (infoPost.AuthorType == AuthorType.Player) infoPost.AuthorId = UserId;
                await rep.PostAsync(infoPost);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("{postId:guid}")]
        public async Task<IActionResult> UpdateTeamRecord([FromBody] InfoPostModel infoPost, [FromRoute] Guid postId)
        {
            try
            {
                if (infoPost.AuthorType == AuthorType.Player) infoPost.AuthorId = UserId;
                await rep.PutAsync(infoPost, postId);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("delete/{postId:guid}")]
        public async Task<IActionResult> DeleteTeamRecord([FromBody] InfoPostModel infoPost, [FromRoute] Guid postId)
        {
            try
            {
                if (infoPost.AuthorType == AuthorType.Player) infoPost.AuthorId = UserId;
                await rep.DeleteAsync(infoPost, postId);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
