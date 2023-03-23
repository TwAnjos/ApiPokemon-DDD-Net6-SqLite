using Domain.InterfacesExternal;
using Domain.InterfacesExternal.InterfacesServices;
using Entities.EntitiesExternal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ServicesExternal
{
    public class ServicePokemon : IServicePokemon
    {
        private readonly IPokemonInfrastructure _IPokemonInfrastructure;

        public ServicePokemon(IPokemonInfrastructure iPokemonInfrastructure)
        {
            _IPokemonInfrastructure = iPokemonInfrastructure;
        }

        public Pokemon GetPokemonById(int idPokemon)
        {
           return _IPokemonInfrastructure.GetPokemonById(idPokemon);
        }

        public Pokemon GetPokemonByName(string namePokemon)
        {
            return _IPokemonInfrastructure.GetPokemonByName(namePokemon);
        }

        public List<Pokemon> List10PokemonRandom()
        {
            return _IPokemonInfrastructure.List10PokemonRandom();
        }
    }
}
