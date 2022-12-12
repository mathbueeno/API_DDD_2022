using AutoMapper;
using Domain.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIS.Models;

namespace WebAPIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMapper _iMapper;

        private readonly IMessage _iMessage;

        public MessageController(IMapper iMapper, IMessage iMessage)
        {
            _iMapper = iMapper;
            _iMessage = iMessage;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Add")]
        public async Task<List<Notifies>> Add(MessageViewModel message)
        {

            message.UserId = await RetornarUsuarioLogado();
            var messageMap = _iMapper.Map<Message>(message);
            await _iMessage.Add(messageMap);
            return messageMap.Notitycoes;

        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Update")]
        public async Task<List<Notifies>> Update(MessageViewModel message)
        {

            var messageMap = _iMapper.Map<Message>(message);
            await _iMessage.Update(messageMap);
            return messageMap.Notitycoes;

        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Delete")]
        public async Task<List<Notifies>> Delete(MessageViewModel message)
        {

            var messageMap = _iMapper.Map<Message>(message);
            await _iMessage.Delete(messageMap);
            return messageMap.Notitycoes;

        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/GetEntityById")]
        public async Task<MessageViewModel> GetEntityById(Message message)
        {

            message = await _iMessage.GetEntityById(message.Id);
            var messageMap = _iMapper.Map<MessageViewModel>(message);
            return messageMap;

        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/List")]
        public async Task<List<MessageViewModel>> List()
        {
            var mensagens = await _iMessage.List();
            var messageMap = _iMapper.Map<List<MessageViewModel>>(mensagens);
            return messageMap;
        }

        private async Task<string> RetornarUsuarioLogado()
        {
            if (User != null)
            {
                var idUsuario = User.FindFirst("idUsuario");
                return idUsuario.Value;
            }

            return string.Empty;

        }
    }
}
