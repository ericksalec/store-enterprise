using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SE.Identidade.API.Models;
using static SE.Identidade.API.Models.UserViewModels;
using Microsoft.AspNetCore.Identity;

namespace SE.Identidade.API.Controllers
{
    [Route("api/identidade")]
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> _signManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(SignInManager<IdentityUser> singnManeger, UserManager<IdentityUser> userManager)
        {
            _signManager = singnManeger;
            _userManager = userManager;
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
            return Ok();
        }

        [HttpPost("autenticar")]
        public async Task<ActionResult> Login(UsuarioLogin usuarioLogin)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _signManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha, false, true);
            if (!result.Succeeded) return BadRequest(result);
            return Ok();

        }
    }
}
