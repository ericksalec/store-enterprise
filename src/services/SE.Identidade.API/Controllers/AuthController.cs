using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SE.Identidade.API.Models;
using static SE.Identidade.API.Models.UserViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SE.Identidade.API.Extensions;

namespace SE.Identidade.API.Controllers
{
    [ApiController]
    [Route("api/identidade")]
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> _signManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;  

        public AuthController(SignInManager<IdentityUser> singnManeger, 
                              UserManager<IdentityUser> userManager,
                              IOptions<AppSettings> appSettings)
        {
            _signManager = singnManeger;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        [HttpPost("nova-conta")]
        public async Task<ActionResult> Registrar(UsuarioRegistro usuarioResgistro)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var user = new IdentityUser {
                UserName = usuarioResgistro.Email,
                Email = usuarioResgistro.Email, 
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, usuarioResgistro.Senha);

            if (!result.Succeeded) return BadRequest(result);

            await _signManager.SignInAsync(user, false);
            return Ok(await GerarJwt(usuarioResgistro.Email));
        }

        [HttpPost("autenticar")]
        public async Task<ActionResult> Login(UsuarioLogin usuarioLogin)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _signManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha, false, true);
            if (!result.Succeeded) return BadRequest(result);
            return Ok(await  GerarJwt(usuarioLogin.Email));
        }

        private async Task<UsuarioRespostaLogin> GerarJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await  _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(),
                ClaimValueTypes.Integer64));

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
             
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            var response = new UsuarioRespostaLogin
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                UsuarioToken = new UsuarioToken
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(c => new UsuarioClaim{ Type = c.Type, Value = c.Value})
                }
            };

            return response;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
                .TotalSeconds);

    }
}
