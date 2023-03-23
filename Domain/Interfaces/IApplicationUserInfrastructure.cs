using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Domain.Interfaces.Generics;

namespace Domain.Interfaces
{
    public interface IApplicationUserInfrastructure
    {
        Task<List<ApplicationUser>> ListarApplicationUsers(Expression<Func<ApplicationUser, bool>> expression);
    }
}
