using Entities.Entities;

namespace Domain.Interfaces.InterfacesServices
{
    public interface IServiceMessage
    {
        Task Adicionar(Message message);
        Task Atualizar(Message message);
        Task Delete(Message messageMap);
        Task<List<Message>> GetAll();
        Task<Message> GetEntityById(int id);
        Task<List<Message>> ListarMensagensAtivas();
    }
}