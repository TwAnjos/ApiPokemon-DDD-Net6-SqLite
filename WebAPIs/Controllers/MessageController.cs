using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

namespace WebAPIs.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IServiceMessage _IServiceMessage;

        public MessageController(IMapper iMapper, IServiceMessage iServiceMessage)
        {
            _IMapper = iMapper;
            _IServiceMessage = iServiceMessage;
        }

        private async Task<string> RetornaIdUsuarioLogado()
        {
            try
            {
                if (User != null)
                {
                    var idUsuario = User.FindFirst("idUsuario");
                    return idUsuario.Value;
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Authorize, Produces("application/json"), HttpPost("/api/Add/")]
        public async Task<List<Notifies>> Add( [FromBody] MessageViewModel message)
        {
            try
            {
                message.UserId = await RetornaIdUsuarioLogado();
                var messageMap = _IMapper.Map<Message>(message);
                await _IServiceMessage.Adicionar(messageMap);
                return messageMap.ListNotifies;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [Authorize, Produces("application/json"), HttpPost("/api/Update/{message}")]
        public async Task<List<Notifies>> Update([FromBody] MessageViewModel message)
        {
            try
            {
                var messageMap = _IMapper.Map<Message>(message);
                await _IServiceMessage.Atualizar(messageMap);
                return messageMap.ListNotifies;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Authorize, Produces("application/json"), HttpDelete("/api/Delete/{message}")]
        public async Task<List<Notifies>> Delete([FromBody] MessageViewModel message)
        {
            try
            {
                var messageMap = _IMapper.Map<Message>(message);
                await _IServiceMessage.Delete(messageMap);
                return messageMap.ListNotifies;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Authorize, Produces("application/json"), HttpGet("/api/GetEntityById/{message}")]
        public async Task<MessageViewModel> GetEntityById([FromBody] Message message)
        {
            try
            {
                message = await _IServiceMessage.GetEntityById(message.Id);
                return _IMapper.Map<MessageViewModel>(message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Authorize, Produces("application/json"), HttpGet("/api/GetAll")]
        public async Task<List<MessageViewModel>> GetAll()
        {
            try
            {
                return _IMapper.Map<List<MessageViewModel>>(await _IServiceMessage.GetAll());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Authorize, Produces("application/json"), HttpGet("/api/ListarMensagensAtivas")]
        public async Task<List<MessageViewModel>> ListarMensagensAtivas()
        {
            try
            {
                return _IMapper.Map<List<MessageViewModel>>(await _IServiceMessage.ListarMensagensAtivas());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
