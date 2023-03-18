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
        private readonly IMessage _IMessage;

        public ServiceMessage(IMessage iMessage)
        {
            _IMessage = iMessage;
        }

        public async Task Adicionar(Message message)
        {
            bool validaTitulo = message.ValidarPropriedadeString(message.Titulo, "Titulo");
            if (validaTitulo)
            {
                message.DataCadastro = DateTime.Now;
                message.DataAlteracao = DateTime.Now;
                message.Ativo = true;
                await _IMessage.Add(message);
            }
        }

        public async Task Atualizar(Message message)
        {
            bool validaTitulo = message.ValidarPropriedadeString(message.Titulo, "Titulo");
            if (validaTitulo)
            {
                message.DataAlteracao = DateTime.Now;
                await _IMessage.Update(message);
            }
        }

        public async Task<List<Message>> ListarMensagensAtivas()
        {
            return await _IMessage.ListarMessage(n => n.Ativo);
        }
    }
}
