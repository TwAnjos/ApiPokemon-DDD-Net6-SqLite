using Domain.Interfaces;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryPokemonsCapturados : RepositoryGenerics<PokemonsCapturados>, IPokemonsCapturadosInfrastructure
    {
        private readonly DbContextOptions<ContextBase> _OptionBuilder;

        public RepositoryPokemonsCapturados()
        {
            _OptionBuilder = new DbContextOptions<ContextBase>();
        }

        public PokemonsCapturados GetByName(string pokemonName)
        {
            using (var banco = new ContextBase(_OptionBuilder))
            {
                return banco.PokemonsCapturados.Single(pk => pk.PokemonName == pokemonName);
            }
        }

        public async Task<List<PokemonsCapturados>> ListarPokemonsCapturados(Expression<Func<PokemonsCapturados, bool>> expression)
        {
            using (var banco = new ContextBase(_OptionBuilder))
            {
                return await banco.PokemonsCapturados.Where(expression).AsNoTracking().ToListAsync();
            }
        }
    }
}