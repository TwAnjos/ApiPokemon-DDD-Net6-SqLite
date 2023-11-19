using Domain.Utils.InterfaceGenerics;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.InterfacesInternal
{
    public interface IFileInfrastructure : IGeneric<UserShawandpartners>
    {
        Task<List<UserShawandpartners>> FindUserByColumnName(Expression<Func<UserShawandpartners, bool>> expression);
    }
}
