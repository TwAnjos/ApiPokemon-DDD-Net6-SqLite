using Entities.Entities;

namespace Domain.InterfacesInternal.InterfacesServices
{
    public interface IServiceUserEnderecos
    {
        Task Adicionar(UserEndereco endereco);

        UserEndereco GetByUserId(string id);
    }
}