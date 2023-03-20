using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Domain.InterfacesExternal;
using Entities.Entities;
using Entities.EntitiesExternal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

namespace WebAPIs.Controllers
{
    [ApiController, Route("api/[controller]"), Produces("application/json")]
    public class PokemonController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IPokemon _IPokemon;
        private readonly IServicePokemonsCapturados _IServicePokemonsCapturados;

        public PokemonController(IMapper iMapper, IPokemon iPokemon, IServicePokemonsCapturados iServicePokemonsCapturados)
        {
            _IMapper = iMapper;
            _IPokemon = iPokemon;
            _IServicePokemonsCapturados = iServicePokemonsCapturados;
        }

        private async Task<string> RetornaIdUsuarioLogado()
        {
            try
            {
                if (User != null)
                {
                    var idUsuario = User.FindFirst("idUsuario");
                    return idUsuario.Value;
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Authorize, Produces("application/json"), HttpGet("/api/List10PokemonRandom")]
        public IActionResult List10PokemonRandom()
        {
            List<Pokemon> pokemon = _IPokemon.List10PokemonRandom();
            return Ok(pokemon);
        }

        [Authorize, Produces("application/json"), HttpGet("/api/GetPokemonById/{idPokemon}")]
        public IActionResult GetPokemonById(int idPokemon)
        {
            Pokemon pokemon = _IPokemon.GetPokemonById(idPokemon);
            if (pokemon == null) { 
                return NotFound("Pokemon não foi encontrado.");
            }
            return Ok(pokemon);
        }

        [Authorize, Produces("application/json"), HttpGet("/api/GetPokemonByName/{GetPokemonByName}")]
        public IActionResult GetPokemonByName(string GetPokemonByName)
        {
            Pokemon pokemon = _IPokemon.GetPokemonByName(GetPokemonByName);
            if (pokemon == null)
            {
                return NotFound("Pokemon não foi encontrado.");
            }
            return Ok(pokemon);
        }

        [Authorize, Produces("application/json"), HttpPost("/api/CapturouPokemonByNameOrId/{pokemonNameOrId}")]
        public async Task<IActionResult> CapturouPokemonByNameOrId(string pokemonNameOrId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(pokemonNameOrId))
                {
                    return BadRequest("pokemonNameOrId não pode ser Null Or White Space");
                }

                Pokemon pokemon = _IPokemon.GetPokemonByName(pokemonNameOrId);
                if (pokemon is null)
                {
                    return NotFound("Pokemon não foi encontrado.");
                }

                //pega o id do pokemon e salva com o id do usuário
                PokemonsCapturados capturado = new PokemonsCapturados();
                capturado.UserId = await RetornaIdUsuarioLogado();
                capturado.PokemonId = pokemon.id;
                capturado.PokemonName = pokemon.name;
                await _IServicePokemonsCapturados.Adicionar(capturado);

                return Ok("Pokemon capturado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao capturar pokemon. ");
            }
        }

        [Authorize, Produces("application/json"), HttpPost("/api/ListarTodosMeusPokemonsCapturados")]
        public async Task<IActionResult> ListarTodosMeusPokemonsCapturados()
        {
            try
            {
                string userId = await RetornaIdUsuarioLogado();
                return Ok(_IServicePokemonsCapturados.ListarPokemonsCapturadosAtivos(userId));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao retornar lista");
            }
        }
    }
}
