using Domain.Utils.InterfaceGenerics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPokemonsCapturadosInfrastructure : IGeneric<PokemonsCapturados>
    {
        PokemonsCapturados GetByName(string pokemonName);
        Task<List<PokemonsCapturados>> ListarPokemonsCapturados(Expression<Func<PokemonsCapturados, bool>> expression);
    }
}
