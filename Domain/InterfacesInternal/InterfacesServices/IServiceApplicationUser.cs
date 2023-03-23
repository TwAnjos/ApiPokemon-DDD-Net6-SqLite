using Entities.Entities;

namespace Domain.Interfaces.InterfacesServices
{
    public interface IServiceApplicationUser
    {
        Task<List<ApplicationUser>> ListarApplicationUsers();
    }
}