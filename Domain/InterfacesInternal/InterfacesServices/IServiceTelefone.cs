using Entities.Entities;

namespace Domain.InterfacesInternal.InterfacesServices
{
    public interface IServiceTelefone
    {
        Task Adicionar(Telefone tel);

        Telefone GetByUserId(string id);
    }
}