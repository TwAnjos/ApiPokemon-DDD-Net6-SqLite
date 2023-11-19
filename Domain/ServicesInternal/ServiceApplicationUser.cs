using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Entities.Entities;

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
            return await _IApplicationUserInfrastructure.ListarApplicationUsers(n => n.EmailConfirmed); ;
        }
    }
}