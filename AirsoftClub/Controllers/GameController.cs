using AirsoftClub.Domain.Core.Models;
using AirsoftClub.Domain.Core.ResponseModels;
using AirsoftClub.Domain.Core.ValidationModels;
using AirsoftClub.Domain.Interfaces.RepositoryChilds;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace AirsoftClub.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> logger;
        private readonly IGameRepository rep;

        private Guid UserId => Guid.Parse(User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value);

        public GameController(ILogger<GameController> logger, IGameRepository rep)
        {
            this.logger = logger;
            this.rep = rep;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetGame([FromRoute] Guid id)
        {
            try
            {
                var game = await rep.GetAsync(id);
                return Ok(GenerateResponse(game));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("all/{clubId:guid}")]
        public async Task<IActionResult> GetGames([FromRoute] Guid clubId)
        {
            try
            {
                var games = await rep.GetAllAsync(clubId);
                if (games != null && games.Count() > 0)
                {
                    var response = new List<GameResponseModel>();
                    foreach (var game in games)
                    {
                        response.Add(GenerateResponse(game));
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
        public async Task<IActionResult> AddGame([FromRoute] Guid clubId, GameModel game)
        {
            try
            {
                await rep.PostAsync(ConvertFromGameModel(game), clubId, UserId);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("{gameId:guid}")]
        public async Task<IActionResult> UpdateGame([FromRoute] Guid gameId, GameModel game)
        {
            try
            {
                await rep.PutAsync(gameId, ConvertFromGameModel(game), UserId);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("{gameId:guid}")]
        public async Task<IActionResult> DeleteGame([FromRoute] Guid gameId)
        {
            try
            {
                await rep.DeleteAsync(gameId, UserId);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        private GameResponseModel GenerateResponse(Game game)
        {
            return new GameResponseModel
            {
                Id = game.Id,
                Name = game.Name,
                Text = game.Text,
                CreationDt = game.CreationDt,
                RentalPrice = game.RentalPrice,
                DefaultPrice = game.DefaultPrice,
                StartDt = game.StartDt,
                GameType = game.GameType,
                FieldId = game.FiringFieldId,
            };
        }

        private Game ConvertFromGameModel(GameModel game)
        {
            return new Game
            {
                Name = game.Name,
                Text = game.Text,
                RentalPrice = game.RentalPrice,
                DefaultPrice = game.DefaultPrice,
                StartDt = game.StartDt.AddHours(3),
                GameType = game.GameType,
            };
        }
    }
}
