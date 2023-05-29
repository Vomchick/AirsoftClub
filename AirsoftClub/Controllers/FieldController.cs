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
    public class FieldController : ControllerBase
    {
        private readonly ILogger<FieldController> logger;
        private readonly IFieldRepository rep;

        private Guid UserId => Guid.Parse(User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value);

        public FieldController(ILogger<FieldController> logger, IFieldRepository rep)
        {
            this.logger = logger;
            this.rep = rep;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetField([FromRoute] Guid id)
        {
            try
            {
                var field = await rep.GetAsync(id);
                return Ok(GenerateResponse(field));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("all/{clubId:guid}")]
        public async Task<IActionResult> GetFields([FromRoute] Guid clubId)
        {
            try
            {
                var fields = await rep.GetAllAsync(clubId);
                if (fields != null && fields.Count() > 0)
                {
                    var response = new List<FieldResponseModel>();
                    foreach (var field in fields)
                    {
                        response.Add(GenerateResponse(field));
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
        [Route("{clubId:guid}")]
        public async Task<IActionResult> AddField([FromRoute] Guid clubId, FieldModel field)
        {
            try
            {
                await rep.PostAsync(ConvertFromFieldModel(field), clubId, UserId);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("{fieldId:guid}")]
        public async Task<IActionResult> UpdateField([FromRoute] Guid fieldId, FieldModel field)
        {
            try
            {
                await rep.PutAsync(fieldId, ConvertFromFieldModel(field), UserId);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("{fieldId:guid}")]
        public async Task<IActionResult> DeleteField([FromRoute] Guid fieldId)
        {
            try
            {
                await rep.DeleteAsync(fieldId, UserId);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        private FieldResponseModel GenerateResponse(FiringField field)
        {
            return new FieldResponseModel
            {
                Id = field.Id,
                Name = field.Name,
                Text = field.Text,
                CreationDt = field.CreationDt,
                IsCovered = field.IsCovered,
                Address = field.Address,
                GPS = field.GPS,
            };
        }

        private FiringField ConvertFromFieldModel(FieldModel field)
        {
            return new FiringField
            {
                Name = field.Name,
                Text = field.Text,
                IsCovered = field.IsCovered,
                Address = field.Address,
                GPS = field.GPS,
            };
        }
    }
}
