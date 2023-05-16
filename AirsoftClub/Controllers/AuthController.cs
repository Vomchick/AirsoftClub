using AirsoftClub.Domain.Core.Models;
using AirsoftClub.Domain.Core.ValidationModels;
using AirsoftClub.Domain.Interfaces.RepositoryChilds;
using AirsoftClub.Infrastructure.Data;
using AirsoftClub.Services;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AirsoftClub.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IOptions<AuthOptions> authOptions;
        private readonly IUserRepository userRepository;
        private readonly ILogger<AuthController> logger;

        public AuthController(IOptions<AuthOptions> authOptions, IUserRepository userRepository, ILogger<AuthController> logger)
        {
            this.authOptions = authOptions;
            this.userRepository = userRepository;
            this.logger = logger;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] AuthModel request)
        {
            try
            {
                var user = await userRepository.Authenticate(request.UserName, request.Password);

                if (user != null)
                {
                    var token = GenerateJWT(user);

                    return Ok(new { access_token = token });
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return Unauthorized();
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] AuthModel value)
        {
            try
            {
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Name = value.UserName,
                    Password = HashPasswordHelper.HashPassword(value.Password)
                };
                var found = await userRepository.UsernameCheck(user.Name);
                if (found != null)
                {
                    return Unauthorized();
                }
                else
                {
                    await userRepository.PostAsync(user);

                    var token = GenerateJWT(user);

                    return Ok(new { access_token = token });
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        private string GenerateJWT(User user)
        {
            var authParams = authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Name, user.Name),
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            };

            var token = new JwtSecurityToken(authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
                signingCredentials: credential);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
