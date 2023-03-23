using Entities.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IApplicationUserInfrastructure
    {
        Task<List<ApplicationUser>> ListarApplicationUsers(Expression<Func<ApplicationUser, bool>> expression);
    }
}