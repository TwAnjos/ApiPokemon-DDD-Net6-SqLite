using Domain.InterfacesInternal;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.RepositoriesInternal
{
    public class RepositoryTelefone : RepositoryGenerics<Telefone>, ITelefoneInfrasctructure
    {
        private readonly DbContextOptions<ContextBase> _OptionBuilder;

        public RepositoryTelefone()
        {
            _OptionBuilder = new DbContextOptions<ContextBase>();
        }

        public Telefone GetEntityByUserId(string id)
        {
            using (var db = new ContextBase(_OptionBuilder))
            {
                return db.Telefone.SingleOrDefault(x => x.UserId == id);
            }
        }
    }
}