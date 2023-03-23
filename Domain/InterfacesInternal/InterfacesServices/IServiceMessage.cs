using Entities.Entities;

namespace Domain.Interfaces.InterfacesServices
{
    public interface IServiceMessage
    {
        Task Adicionar(Message Objeto);

        Task Atualizar(Message Objeto);

        Task<List<Message>> ListarMensagensAtivas();
    }
}