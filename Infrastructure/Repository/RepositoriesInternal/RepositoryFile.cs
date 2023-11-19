using Domain.InterfacesInternal;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository.RepositoriesInternal
{
    public class RepositoryFile : RepositoryGenerics<UserShawandpartners>, IFileInfrastructure
    {
        private readonly DbContextOptions<ContextBase> _OptionBuilder;

        public RepositoryFile()
        {
            _OptionBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<UserShawandpartners>> FindUserByColumnName(Expression<Func<UserShawandpartners, bool>> expression)
        {
            using (var db = new ContextBase(_OptionBuilder))
            {
                return await db.UserShawandpartners.Where(expression).AsNoTracking().ToListAsync();
            }
        }
    }
}