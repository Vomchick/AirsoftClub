using AirsoftClub.Domain.Core.Models;
using AirsoftClub.Domain.Core.ResponseModels;
using AirsoftClub.Domain.Core.ValidationModels;
using AirsoftClub.Domain.Interfaces.RepositoryChilds;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AirsoftClub.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ClubController : ControllerBase
    {
        private readonly ILogger<ClubController> logger;
        private readonly IClubRepository rep;

        private Guid UserId => Guid.Parse(User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value);

        public ClubController(ILogger<ClubController> logger, IClubRepository rep)
        {
            this.logger = logger;
            this.rep = rep;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetClub([FromRoute] Guid id)
        {
            try
            {
                var club = await rep.GetAsync(id, UserId);
                if (club.Item1 != null)
                    return Ok(GenerateResponse(club.Item1, club.Item2));
                else
                    return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonalClub()
        {
            try
            {
                var club = await rep.GetPersonalAsync(UserId);
                if (club != null)
                    return Ok(club);
                else
                    return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("rights/{id:guid}")]
        public async Task<IActionResult> GetRightsClub([FromRoute] Guid id)
        {
            try
            {
                var rights = await rep.GetRightsAsync(UserId, id);
                return Ok(rights);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("allMine")]
        public async Task<IActionResult> GetMyClubs()
        {
            try
            {
                var club = await rep.GetAllMyAsync(UserId);
                if (club.Count() > 0)
                {
                    return Ok(club);
                }
                else
                    return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetClubs()
        {
            try
            {
                var clubs = await rep.GetAllAsync(UserId);
                if (clubs.Count() > 0)
                {
                    var response = new List<ClubResponseModel>();
                    foreach (var club in clubs)
                    {
                        response.Add(GenerateResponse(club.Item1, club.Item2));
                    }
                    return Ok(response);
                }
                else
                    return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddClub(ClubModel club)
        {
            try
            {
                await rep.PostAsync(UserId, ConvertFromClubModel(club));
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("{clubId:guid}")]
        public async Task<IActionResult> UpdateClub([FromRoute] Guid clubId, Club club)
        {
            try
            {
                await rep.PutAsync(UserId, clubId, club);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("{clubId:guid}")]
        public async Task<IActionResult> DeleteClub([FromRoute]Guid clubId)
        {
            try
            {
                await rep.DeleteAsync(UserId, clubId);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("join/{clubId:guid}")]
        public async Task<IActionResult> JoinClub([FromRoute]Guid clubId)
        {
            try
            {
                await rep.JoinClub(UserId, clubId);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("leave/{clubId:guid}")]
        public async Task<IActionResult> LeaveClub([FromRoute]Guid clubId)
        {
            try
            {
                await rep.LeaveClub(UserId, clubId);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        private ClubResponseModel GenerateResponse (Club club, bool joined)
        {
            return new ClubResponseModel
            {
                Id = club.Id,
                Name = club.Name,
                Description = club.Description,
                IsJoined = joined
            };
        }

        private Club ConvertFromClubModel(ClubModel club)
        {
            return new Club
            {
                Name = club.Name,
                Description = club.Description,
            };
        }
    }
}
