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
        List<PokemonDetails> List10PokemonRandom();
        PokemonDetails GetPokemonById(int idPokemon);
        PokemonDetails GetPokemonByName(string namePokemon);
    }
}
