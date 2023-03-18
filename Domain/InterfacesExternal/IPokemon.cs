using Entities.EntitiesExternal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.InterfacesExternal
{
    public interface IPokemon
    {
        List<Pokemon> List10PokemonRandom();
        Pokemon GetPokemonById(int idPokemon);
        Pokemon GetPokemonByName(string namePokemon);
    }
}
