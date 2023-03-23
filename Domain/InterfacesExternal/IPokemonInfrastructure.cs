using Domain.Utils.InterfaceGenerics;
using Entities.EntitiesExternal;

namespace Domain.InterfacesExternal
{
    public interface IPokemonInfrastructure : IGeneric<Pokemon>
    {
        List<Pokemon> List10PokemonRandom();

        Pokemon GetPokemonById(int idPokemon);

        Pokemon GetPokemonByName(string namePokemon);
    }
}