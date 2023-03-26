using Domain.InterfacesInternal;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.RepositoriesInternal
{
    public class RepositoryTelefone : RepositoryGenerics<Telefone>, ITelefoneInfrasctructure
    {
        private readonly DbContextOptions<ContextBase> _OptionBuilder;

        public RepositoryTelefone()
        {
            _OptionBuilder = new DbContextOptions<ContextBase>();
        }
    }
}
