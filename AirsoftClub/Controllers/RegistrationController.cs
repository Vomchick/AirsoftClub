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
    public class RegistrationController : ControllerBase
    {
        private readonly ILogger<RegistrationController> logger;
        private readonly ITeamRecordRepository teamRecordRep;
        private readonly ISoloRecordRepository soloRecordRep;

        private Guid UserId => Guid.Parse(User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value);

        public RegistrationController(ILogger<RegistrationController> logger, ITeamRecordRepository rep, ISoloRecordRepository soloRecordRep)
        {
            this.logger = logger;
            this.teamRecordRep = rep;
            this.soloRecordRep = soloRecordRep;
        }

        [HttpGet]
        [Route("team/{gameId:guid}")]
        public async Task<IActionResult> GetTeamRecord([FromRoute] Guid gameId)
        {
            try
            {
                var record = await teamRecordRep.GetAsync(UserId, gameId);
                return Ok(GenerateTeamResponse(record));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("team")]
        public async Task<IActionResult> GetAllTeamRecords()
        {
            try
            {
                var records = await teamRecordRep.GetAllAsync(UserId);
                if (records != null && records.Count() > 0)
                {
                    var response = new List<TeamRecordModel>();
                    foreach (var record in records)
                    {
                        response.Add(new TeamRecordModel { PeopleCount = record.PeopleCount, GameId = record.GameId});
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
        [Route("team")]
        public async Task<IActionResult> AddTeamRecord(TeamRecordModel record)
        {
            try
            {
                await teamRecordRep.PostAsync(UserId, record.GameId, record.PeopleCount);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("team")]
        public async Task<IActionResult> UpdateTeamRecord(TeamRecordModel record)
        {
            try
            {
                await teamRecordRep.PutAsync(UserId, record.GameId, record.PeopleCount);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("team/{gameId:guid}")]
        public async Task<IActionResult> DeleteTeamRecord([FromRoute] Guid gameId)
        {
            try
            {
                await teamRecordRep.DeleteAsync(UserId, gameId);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("solo/{gameId:guid}")]
        public async Task<IActionResult> GetSoloRecord([FromRoute] Guid gameId)
        {
            try
            {
                var record = await soloRecordRep.GetAsync(UserId, gameId);
                return Ok(GenerateSoloResponse(record));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("solo")]
        public async Task<IActionResult> GetAllSoloRecords()
        {
            try
            {
                var records = await soloRecordRep.GetAllAsync(UserId);
                if (records != null && records.Count() > 0)
                {
                    var response = new List<SoloRecordModel>();
                    foreach (var record in records)
                    {
                        response.Add(new SoloRecordModel { PickUp = record.PickUp, NeedARent = record.NeedARent, GameId = record.GameId});
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
        [Route("solo")]
        public async Task<IActionResult> AddSoloRecord(SoloRecordModel record)
        {
            try
            {
                await soloRecordRep.PostAsync(UserId, ConvertToSoloRecord(record));
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("solo")]
        public async Task<IActionResult> UpdateSoloRecord(SoloRecordModel record)
        {
            try
            {
                await soloRecordRep.PutAsync(UserId, ConvertToSoloRecord(record));
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("solo/{gameId:guid}")]
        public async Task<IActionResult> DeleteSoloRecord([FromRoute] Guid gameId)
        {
            try
            {
                await soloRecordRep.DeleteAsync(UserId, gameId);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        private TeamRecordResponseModel GenerateTeamResponse(TeamRecord record)
        {
            return new TeamRecordResponseModel
            {
                PeopleCount = record.PeopleCount,
            };
        }

        private SoloRecordResponseModel GenerateSoloResponse(SoloRecord record) => new SoloRecordResponseModel
        {
            NeedARent = record.NeedARent,
            PickUp = record.PickUp
        };
 

        private SoloRecord ConvertToSoloRecord(SoloRecordModel record) => new SoloRecord
        {
            PickUp = record.PickUp,
            NeedARent = record.NeedARent,
            GameId = record.GameId,
        };
    }
}
