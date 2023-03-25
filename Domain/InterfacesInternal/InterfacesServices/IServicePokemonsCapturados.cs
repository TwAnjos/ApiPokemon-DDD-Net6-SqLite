using Entities.Entities;

namespace Domain.Interfaces.InterfacesServices
{
    public interface IServicePokemonsCapturados
    {
        Task Adicionar(PokemonsCapturados pokemonsCapturados);

        Task Atualizar(PokemonsCapturados pokemonsCapturados);

        PokemonsCapturados GetPokemonByName(string pokemonName);

        Task<List<PokemonsCapturados>> ListarPokemonsCapturadosAtivos(string userId);

        void RemoveById(PokemonsCapturados pk);
    }
}