using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceMessage : IServiceMessage
    {
        private readonly IMessageInfrastructure _IRepositoryMessage;

        public ServiceMessage(IMessageInfrastructure iMessage)
        {
            _IRepositoryMessage = iMessage;
        }

        public async Task Adicionar(Message message)
        {
            bool validaTitulo = message.ValidarPropriedadeString(message.Titulo, "Titulo");
            if (validaTitulo)
            {
                message.DataCadastro = DateTime.Now;
                message.DataAlteracao = DateTime.Now;
                message.Ativo = true;
                await _IRepositoryMessage.Add(message);
            }
        }

        public async Task Atualizar(Message message)
        {
            bool validaTitulo = message.ValidarPropriedadeString(message.Titulo, "Titulo");
            if (validaTitulo)
            {
                message.DataAlteracao = DateTime.Now;
                await _IRepositoryMessage.Update(message);
            }
        }

        public async Task<List<Message>> ListarMensagensAtivas()
        {
            return await _IRepositoryMessage.ListarMessage(n => n.Ativo);
        }
    }
}
