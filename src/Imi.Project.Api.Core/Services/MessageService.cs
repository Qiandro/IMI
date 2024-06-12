using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.IRepositories;
using Imi.Project.Api.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepo;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepo = messageRepository;
        }

        public async Task<Message> AddMessage(Message msg)
        {
            return await _messageRepo.AddMessage(msg);
        }

        public async Task<Message> DeleteMessage(Message msg)
        {
            return await _messageRepo.DeleteMessage(msg);
        }

        public async Task<IEnumerable<Message>> GetGroupMessages(Guid GroupId)
        {
            return await _messageRepo.GetGroupMessages(GroupId);
        }

        public async Task<Message> GetMessage(Guid MessageId)
        {
            return await _messageRepo.GetMessage(MessageId);
        }

        public async Task<Message> UpdateMessage(Message msg)
        {
            return await _messageRepo.UpdateMessage(msg);
        }
    }
}
