using AutoMapper;
using Domain.InterfacesInternal.InterfacesServices;
using Entities.Entities;
using Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Text;
using WebAPIs.Models;
using WebAPIs.Token;
using WebAPIs.Utils;
using WebAPIs.ViewModels;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IServiceTelefone _IServiceTelefone;
        private readonly IServiceUserEnderecos _IServiceUserEnderecos;

        public UsersController(IMapper iMapper, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IServiceTelefone iServiceTelefone, IServiceUserEnderecos iServiceUserEnderecos)
        {
            _IMapper = iMapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _IServiceTelefone = iServiceTelefone;
            _IServiceUserEnderecos = iServiceUserEnderecos;
        }

        [AllowAnonymous, Produces("application/json"), HttpPost("/api/GerarTokenAPI")]
        public async Task<IActionResult> GerarTokenAPI([FromBody] LoginViewModel login)
        {
            var user = _userManager.FindByEmailAsync(login.email).Result;
            var r2 = await _signInManager.PasswordSignInAsync(user, login.senha, false, lockoutOnFailure: false);

            if (r2.Succeeded)
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

        [AllowAnonymous, Produces("application/json"), HttpPost("/api/CadastrarUsuario")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] AddUserViewModel userView)
        {
            try
            {
                var user = new ApplicationUser
                {
                    UserName = userView.UserName,
                    Email = userView.Email,
                    CPF = userView.CPF,
                    Tipo = TipoUsuario.Comum
                };

                var resultado = await _userManager.CreateAsync(user, userView.Senha);

                if (resultado.Errors.Any())
                {
                    return BadRequest(resultado.Errors);
                }

                //Geração de confirmação caso precise
                _ = await _userManager.GetUserIdAsync(user);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                //Retorno email
                code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
                var resultado2 = await _userManager.ConfirmEmailAsync(user, code);

                if (resultado2.Succeeded)
                {
                    return Ok("Usuário adicionado com sucesso");
                }
                else
                {
                    return BadRequest("Erro ao cadastrar usuário");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [Authorize, Produces("application/json" ), HttpPost("/api/AtualizarUsuarioLogado")]
        public async Task<IActionResult> AtualizarUsuarioLogado([FromBody] UserCompleteViewModel userView)
        {
            string userID = UserUtils.RetornaIdUsuarioLogado(User);
            var user = _userManager.FindByIdAsync(userID).Result;

            user.CPF = userView.CPF;
            user.RG = userView.RG;
            user.Idade = userView.Idade;
            user.Genero = userView.Genero;
            user.Tipo = userView.Tipo;
            user.DtNascimento = userView.DtNascimento;

            var telefone = _IMapper.Map<Telefone>(userView.Telefones);
            telefone.UserId = userID;
            _ = _IServiceTelefone.Adicionar(telefone);

            var endereco = _IMapper.Map<UserEndereco>(userView.User_Enderecos);
            endereco.UserId = userID;
            _ = _IServiceUserEnderecos.Adicionar(endereco);

            user.Telefone = telefone;
            user.User_Endereco = endereco;

            var resultado = await _userManager.UpdateAsync(user);

            if (resultado.Errors.Any())
            {
                return BadRequest(resultado.Errors);
            }

            _ = _userManager.SetUserNameAsync(user, userView.UserName);
            _ = _userManager.SetEmailAsync(user, userView.Email);
            _ = _userManager.ChangePasswordAsync(user, user.PasswordHash, userView.Senha);

            return Ok("Usuário autalizado com sucesso" + resultado);
        }

        [AllowAnonymous, Produces("application/json"), HttpDelete("/api/RemoverUsuarioByEmail")]
        public async Task<IActionResult> RemoverUsuarioByEmail([FromBody] LoginViewModel login)
        {
            var user = await _userManager.FindByEmailAsync(login.email);
            var result = await _signInManager.PasswordSignInAsync(user, login.senha, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                _ = await _userManager.DeleteAsync(user);

                return Ok($"O usuário {user.UserName} foi removido.");
            }
            else
            {
                return Unauthorized();
            }
        }

        [AllowAnonymous, Produces("application/json"), HttpGet("/api/ListAllUsers")]
        public IActionResult ListAllUsers()
        {
            return Ok((from u in _userManager.Users
                          .Include(t => t.Telefone)
                          .Include(e => e.User_Endereco)
                       where u.Id.Contains(u.Id)
                       select u).ToList());
        }
    }
}