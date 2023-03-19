using Domain.InterfacesExternal;
using Entities.EntitiesExternal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIs.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemon _IPokemon;

        public PokemonController(IPokemon iPokemon)
        {
            _IPokemon = iPokemon;
        }

        [Produces("application/json"), HttpGet("/api/List10PokemonRandom")]
        public List<PokemonDetails> List10PokemonRandom()
        {
            return _IPokemon.List10PokemonRandom();
        }

        [Produces("application/json"), HttpGet("/api/GetPokemonById/{idPokemon}")]
        public PokemonDetails GetPokemonById(int idPokemon)
        {
            return _IPokemon.GetPokemonById(idPokemon);
        }

        [Produces("application/json"), HttpGet("/api/GetPokemonByName/{GetPokemonByName}")]
        public PokemonDetails GetPokemonByName(string GetPokemonByName)
        {
            return _IPokemon.GetPokemonByName(GetPokemonByName);
        }

    }
}
