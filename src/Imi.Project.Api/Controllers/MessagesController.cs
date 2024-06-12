using Imi.Project.Api.Core.Dtos.Events;
using Imi.Project.Api.Core.Dtos.Messages;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.IServices;
using Imi.Project.Api.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Imi.Project.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }


        [HttpGet("{MessageId}")]
        public async Task<IActionResult> GetMessage(Guid MessageId)
        {
            var msg = await _messageService.GetMessage(MessageId);
            var responseDto = new MessageResponseDto
            {
                MessageId = msg.MessageId,
                GroupId = msg.GroupId,
                SenderId = Guid.Parse(msg.SenderId),
                Content = msg.Content,
                SentTime = msg.SentTime
            };

            return Ok(responseDto);
        }
        [HttpGet("/Messages/Group/{GroupId}")]
        public async Task<IActionResult> GetMessagesFromGroup(Guid GroupId)
        {
            var msgs = await _messageService.GetGroupMessages(GroupId);
            var responseDto = msgs.Select(m => new MessageResponseDto
            {
                SentTime = m.SentTime,
                Content = m.Content,
                GroupId = GroupId,
                MessageId = m.MessageId,
                SenderId = Guid.Parse(m.SenderId),
            });

            return Ok(responseDto);
        }

        [HttpDelete("{MessageId}")]
        public async Task<IActionResult> DeleteMessage(Guid MessageId)
        {
            var msg = await _messageService.GetMessage(MessageId);

            if (msg == null)
            {
                return NotFound($"No event with ID {MessageId} found");
            }

            await _messageService.DeleteMessage(msg);


            return Ok(msg);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(MessageRequestDto messageRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            var msg = new Message
            {
                Content = messageRequestDto.Content,
                SenderId = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value,
                GroupId = messageRequestDto.GroupId
            };

            await _messageService.AddMessage(msg);

            return Ok(msg);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMessage(MessageUpdateRequestDto messageUpdateRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            var msg = await _messageService.GetMessage(messageUpdateRequestDto.MessageId);

            if (msg == null)
            {
                return NotFound($"No event with ID {messageUpdateRequestDto.MessageId} found");
            }

            msg.Content = messageUpdateRequestDto.Content;
            
            await _messageService.UpdateMessage(msg);

            return Ok(msg);
        }

    }
}
