﻿using Domain.Interfaces;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryPokemonsCapturados : RepositoryGenerics<PokemonsCapturados>, IPokemonsCapturadosInfrastructure
    {
        private readonly DbContextOptions<ContextBase> _OptionBuilder;
        public RepositoryPokemonsCapturados()
        {
            _OptionBuilder = new DbContextOptions<ContextBase>();
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
