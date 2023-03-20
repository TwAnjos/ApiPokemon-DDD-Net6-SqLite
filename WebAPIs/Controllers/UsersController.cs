using Entities.Entities;
using Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using WebAPIs.Models;
using WebAPIs.Token;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/GerarTokenAPI")]
        public async Task<IActionResult> GerarTokenAPI([FromBody] LoginViewModel login)
        {
            if(string.IsNullOrWhiteSpace(login.email) || string.IsNullOrWhiteSpace(login.senha)) 
            {
                return Unauthorized();
            }

            var resultado = await _signInManager.PasswordSignInAsync(login.email, login.senha, false, lockoutOnFailure: false);

            if(resultado.Succeeded)
            {
                var userCurrent = await _userManager.FindByEmailAsync(login.email);
                var jk = JwtSecurityKey.Create("Secret_Key-12345678");
                var token = new TokenJWTBuilder()
                    .AddSecurityKey(jk)
                    .AddSubject("NomeEmpresaTeste")
                    .AddIssuer("Teste.Issuer.Bearer")
                    .AddAudience("Teste.Audience.Bearer")
                    .AddClaim("IdUsuario", userCurrent.Id)
                    .AddExpiry(1440)
                    .Builder();

                return Ok(token.value);
            }
            else 
            { 
                return Unauthorized(); 
            }
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CadastrarUsuarioIdentity")]
        public async Task<IActionResult> CadastrarUsuarioIdentity([FromBody] AddUserViewModel login)
        {
            if (string.IsNullOrWhiteSpace(login.email) || string.IsNullOrWhiteSpace(login.senha))
            {
                return NotFound();
            }

            var user = new ApplicationUser
            {
                UserName = login.email,
                Email = login.email,
                CPF = login.cpf,
                Tipo = TipoUsuario.Comum,
                DtNascimento = login.DtNascimento,
                Idade = login.Idade
            };

            var resultado = await _userManager.CreateAsync(user, login.senha);

            if(resultado.Errors.Any())
            {
                return BadRequest(resultado.Errors);
            }

            //Geração de confirmação caso precise
            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            //Retorno email
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var resultado2 = await _userManager.ConfirmEmailAsync(user, code);

            if(resultado2.Succeeded)
            {
                return Ok("Usuário adicionado com sucesso");
            }
            else
            {
                return BadRequest("Erro ao confirmar usuário");
            }
        }
    }
}
