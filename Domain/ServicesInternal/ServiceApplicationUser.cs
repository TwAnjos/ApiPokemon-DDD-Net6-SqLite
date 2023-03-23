using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceApplicationUser : IServiceApplicationUser
    {
        private readonly IApplicationUserInfrastructure _IApplicationUserInfrastructure;

        public ServiceApplicationUser(IApplicationUserInfrastructure iApplicationUserInfrastructure)
        {
            _IApplicationUserInfrastructure = iApplicationUserInfrastructure;
        }

        public async Task<List<ApplicationUser>> ListarApplicationUsers()
        {
            var teste = await _IApplicationUserInfrastructure.ListarApplicationUsers(n => n.EmailConfirmed);
            return teste;
        }



    }
}
