using AirsoftClub.Domain.Core.Models;
using AirsoftClub.Domain.Core.ValidationModels;
using AirsoftClub.Domain.Interfaces.RepositoryChilds;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;

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
        public async Task<IActionResult> GetTeam()
        {
            try
            {
                var team = await rep.GetAsync(UserId);
                if (team != null)
                    return Ok(ConvertFromTeam(team));
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
        public async Task<IActionResult> GetTeams()
        {
            try
            {
                var team = await rep.GetAllAsync();
                if (team != null)
                {
                    var teamModels = new List<TeamModel>();
                    foreach (var item in team)
                        teamModels.Add(ConvertFromTeam(item));
                    return Ok(teamModels);
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
        public async Task<IActionResult> AddTeam(TeamModel team)
        {
            try
            {
                await rep.PostAsync(UserId, ConvertFromTeamModel(team));
                return CreatedAtAction(nameof(GetTeam), team);
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
                return CreatedAtAction(nameof(GetTeam), team);
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

        private TeamModel ConvertFromTeam(Team team)
        {
            return new TeamModel
            {
                Name = team.Name,
                Description = team.Description,
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
