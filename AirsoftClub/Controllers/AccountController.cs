﻿using AirsoftClub.Domain.Core.Enums;
using AirsoftClub.Domain.Core.Models;
using AirsoftClub.Domain.Core.ValidationModels;
using AirsoftClub.Domain.Interfaces;
using AirsoftClub.Domain.Interfaces.RepositoryChilds;
using AirsoftClub.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AirsoftClub.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> logger;
        private readonly IPlayerRepository rep;

        private Guid UserId => Guid.Parse(User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value);

        public AccountController(ILogger<AccountController> logger, IPlayerRepository rep)
        {
            this.logger = logger;
            this.rep = rep;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccount()
        {
            try
            {
                var account = await rep.GetAsync(UserId);
                if (account != null)
                    return Ok(ConvertFromPlayer(account));
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
        public async Task<IActionResult> CreateNewAccount([FromBody] AccountModel value)
        {
            try
            {
                await rep.PostAsync(ConvertFromAccountModel(value), UserId);
                return CreatedAtAction(nameof(GetAccount), value);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        //Update card
        [HttpPut]
        //[Route("{id:guid}")]
        public async Task<IActionResult> UpdateAccount([FromBody] AccountModel value)
        {
            try
            {
                await rep.PutAsync(UserId, ConvertFromAccountModel(value));
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        private Player ConvertFromAccountModel(AccountModel value)
        {
            return new Player
            {
                CallSign = value.CallSign,
                GameRole = (GameRole)Enum.Parse(typeof(GameRole), value.GameRole),
                Description = value.Desc,
                //TeamRole = value.TeamRole != null ? (TeamRole)Enum.Parse(typeof(TeamRole), value.TeamRole) : null,
            };
        }

        private AccountModel ConvertFromPlayer(Player value)
        {
            return new AccountModel
            {
                CallSign = value.CallSign,
                GameRole = value.GameRole.ToString(),
                Desc = value.Description,
                TeamName = value.Team?.Name,
                TeamRole = value.TeamRole.ToString(),
            };
        }
    }
}
