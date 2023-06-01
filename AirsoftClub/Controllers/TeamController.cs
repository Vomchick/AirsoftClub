using AirsoftClub.Domain.Core.Models;
using AirsoftClub.Domain.Core.ResponseModels;
using AirsoftClub.Domain.Core.ValidationModels;
using AirsoftClub.Domain.Interfaces.RepositoryChilds;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;
using static System.Reflection.Metadata.BlobBuilder;

namespace AirsoftClub.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class TeamController : ControllerBase
    {
        private readonly ILogger<TeamController> logger;
        private readonly ITeamRepository rep;

        private Guid UserId => Guid.Parse(User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value);

        public TeamController(ILogger<TeamController> logger, ITeamRepository rep)
        {
            this.logger = logger;
            this.rep = rep;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetTeam([FromRoute]Guid id)
        {
            try
            {
                var team = await rep.GetAsync(id);
                return Ok(GenerateResponse(team, null));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonalTeam()
        {
            try
            {
                var team = await rep.GetPersonalAsync(UserId);
                if (team != null)
                    return Ok(GenerateResponse(team, null));
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("people/{teamId:guid}")]
        public async Task<IActionResult> GetPepleCount([FromRoute] Guid teamId)
        {
            try
            {
                var count = await rep.GetPeopleCount(teamId);
                return Ok(count);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("Request/get/{teamId:guid}")]
        public async Task<IActionResult> GetAllRequests(Guid teamId)
        {
            try
            {
                var requests = await rep.GetAllRequests(teamId);
                if (requests != null && requests.Count() > 0)
                {
                    var response = new List<TeamRequestResponseModel>();
                    foreach (var request in requests)
                    {
                        response.Add(GenerateRequestResponse(request));
                    }
                    return Ok(response);
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
        [Route("Request/create")]
        public async Task<IActionResult> CreateRequest(CreationTeamRequestModel request)
        {
            try
            {
                await rep.CreateRequest(UserId, request);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("Request/pos")]
        public async Task<IActionResult> PositiveRequest(TeamRequestModel response)
        {
            try
            {
                await rep.PositiveRequest(response);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("Request/neg")]
        public async Task<IActionResult> NegativeRequest(TeamRequestModel response)
        {
            try
            {
                await rep.NegativeRequest(response);
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
        public async Task<IActionResult> GetTeams()
        {
            try
            {
                var teams = await rep.GetAllAsync(UserId);
                if (teams != null && teams.Count() > 0)
                {
                    var response = new List<TeamResponseModel>();
                    foreach (var team in teams)
                    {
                        response.Add(GenerateResponse(team.Item1, team.Item2));
                    }
                    return Ok(response);
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

        [HttpPost]
        public async Task<IActionResult> AddTeam(TeamModel team)
        {
            try
            {
                await rep.PostAsync(UserId, ConvertFromTeamModel(team));
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeam(TeamModel team)
        {
            try
            {
                await rep.PutAsync(UserId, ConvertFromTeamModel(team));
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTeam()
        {
            try
            {
                await rep.DeleteAsync(UserId);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        private TeamResponseModel GenerateResponse(Team team, bool? request)
        {
            return new TeamResponseModel
            {
                Id = team.Id,
                Name = team.Name,
                Description = team.Description,
                haveRequest = request
            };
        }

        private TeamRequestResponseModel GenerateRequestResponse(TeamRequest request)
        {
            return new TeamRequestResponseModel
            {
                UserId = request.Player.UserId,
                Name = request.Player.CallSign,
                TeamId = request.TeamId,
                Description = request.Description,
            };
        }

        private Team ConvertFromTeamModel(TeamModel team)
        {
            return new Team
            {
                Name = team.Name,
                Description = team.Description,
            };
        }
    }
}
