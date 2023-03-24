using Domain.InterfacesInternal;
using Domain.InterfacesInternal.InterfacesServices;
using Entities.Entities;

namespace Domain.ServicesInternal
{
    public class ServiceUserEnderecos : IServiceUserEnderecos
    {
        private readonly IUserEnderecosInfrastructure _IUserEnderecosInfrastructure;

        public ServiceUserEnderecos(IUserEnderecosInfrastructure iUserEnderecosInfrastructure)
        {
            _IUserEnderecosInfrastructure = iUserEnderecosInfrastructure;
        }

        public async Task Adicionar(UserEndereco endereco)
        {
            await _IUserEnderecosInfrastructure.Add(endereco);
        }
    }
}