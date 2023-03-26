using Domain.Utils.InterfaceGenerics;
using Entities.Entities;

namespace Domain.InterfacesInternal
{
    public interface IUserEnderecosInfrastructure : IGeneric<UserEndereco>
    {
        UserEndereco GetEntityByUserId(string id);
    }
}