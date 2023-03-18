using Domain.InterfacesExternal;
using Entities.EntitiesExternal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.RepositoryExternal
{
    public class RepositoryPokemon : IPokemon
    {
        //https://pokeapi.co/api/v2/pokemon/1
        private readonly string urlApi = "https://pokeapi.co/api/v2/pokemon/";

        public Pokemon GetPokemonById(int idPokemon)
        {
            throw new NotImplementedException();
        }

        public Pokemon GetPokemonByName(string namePokemon)
        {
            throw new NotImplementedException();
        }

        public List<Pokemon> List10PokemonRandom()
        {
            throw new NotImplementedException();
        }

        //creates...
        //https://youtu.be/wxUk5mVGL7Y?list=PLP8qOphXwRnIOzXzoviI5xwxcc4-dV_pd&t=815
    }
}
