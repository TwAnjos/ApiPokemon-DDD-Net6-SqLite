using Domain.InterfacesInternal;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.RepositoriesInternal
{
    public class RepositoryUserEnderecos : RepositoryGenerics<UserEndereco>, IUserEnderecosInfrastructure
    {
        private readonly DbContextOptions<ContextBase> _OptionBuilder;

        public RepositoryUserEnderecos()
        {
            _OptionBuilder = new DbContextOptions<ContextBase>();
        }

        public UserEndereco? GetEntityByUserId(string id)
        {
            using (var db = new ContextBase(_OptionBuilder))
            {
                return db.UserEndereco.SingleOrDefault(ue => ue.UserId == id);
            }
        }
    }
}