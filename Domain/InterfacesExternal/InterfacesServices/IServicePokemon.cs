using Entities.EntitiesExternal;

namespace Domain.InterfacesExternal.InterfacesServices
{
    public interface IServicePokemon
    {
        List<Pokemon> List10PokemonRandom();

        Pokemon GetPokemonById(int idPokemon);

        Pokemon GetPokemonByName(string namePokemon);
    }
}