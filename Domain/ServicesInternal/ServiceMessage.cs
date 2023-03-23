using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Entities.Entities;

namespace Domain.Services
{
    public class ServiceMessage : IServiceMessage
    {
        private readonly IMessageInfrastructure _IMessageInfrastructure;

        public ServiceMessage(IMessageInfrastructure iMessageInfrastructure)
        {
            _IMessageInfrastructure = iMessageInfrastructure;
        }

        public async Task Adicionar(Message message)
        {
            bool validaTitulo = message.ValidarPropriedadeString(message.Titulo, "Titulo");
            if (validaTitulo)
            {
                message.DataCadastro = DateTime.Now;
                message.DataAlteracao = DateTime.Now;
                message.Ativo = true;
                await _IMessageInfrastructure.Add(message);
            }
        }

        public async Task Atualizar(Message message)
        {
            bool validaTitulo = message.ValidarPropriedadeString(message.Titulo, "Titulo");
            if (validaTitulo)
            {
                message.DataAlteracao = DateTime.Now;
                await _IMessageInfrastructure.Update(message);
            }
        }

        public Task Delete(Message messageMap)
        {
            return _IMessageInfrastructure.Delete(messageMap);
        }

        public Task<List<Message>> GetAll()
        {
            return _IMessageInfrastructure.GetAll();
        }

        public Task<Message> GetEntityById(int id)
        {
            return _IMessageInfrastructure.GetEntityById(id);
        }

        public async Task<List<Message>> ListarMensagensAtivas()
        {
            return await _IMessageInfrastructure.ListarMessage(n => n.Ativo);
        }
    }
}