using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.IdentityModel.Tokens;
using MudBlazorCatalogoNaPratica.Shared.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MudBlazorCatalogoNaPratica.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _singInManager;
        private readonly IConfiguration _configuration;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _singInManager = signInManager;
            _configuration = configuration;
        }
        [HttpGet]
        public string Get()
        {
            return $"AccountController :: {DateTime.Now.ToShortDateString()}";
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserToken>> Register([FromBody] UserInfo model)
        {
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded) {
                return GenerateToken(model);
            }
            else
            {
                return BadRequest("Usuário ou senha inválidos");
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserInfo userInfo)
        {
            var result = await _singInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return GenerateToken(userInfo);
            }
            else
            {
                return BadRequest(new { message = "Usuário ou senha inválidos" });
            }
        }
        private UserToken GenerateToken(UserInfo userInfo)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim(ClaimTypes.Name, userInfo.Email),
                new Claim("joao", "joao.teste"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(2);
            var message = "Token JWT criado com sucesso";

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds);
            
            return new UserToken
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
                Message = message
            };
        }
    }
}
