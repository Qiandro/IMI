using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.IRepositories;
using Imi.Project.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IMIDbContext _dbContext;

        public MessageRepository(IMIDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Message> GetMessage(Guid MessageId)
        {
            return await _dbContext.messages.Where(m => m.MessageId == MessageId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Message>> GetGroupMessages(Guid GroupId)
        {
            return await _dbContext.messages.Where(m => m.GroupId == GroupId).ToListAsync();
        }

        public async Task<Message> AddMessage(Message msg)
        {
            msg.LastEditedOn = null;
            msg.SentTime = DateTime.Now;
            msg.MessageId = Guid.NewGuid();

            _dbContext.messages.Add(msg);
            await _dbContext.SaveChangesAsync();
            return msg;
        }

        public async Task<Message> DeleteMessage(Message msg)
        {
            _dbContext.messages.Remove(msg);
            await _dbContext.SaveChangesAsync();
            return msg;
        }

        public async Task<Message> UpdateMessage(Message msg)
        {
            msg.LastEditedOn = DateTime.Now;

            _dbContext.messages.Update(msg);
            await _dbContext.SaveChangesAsync();
            return msg;
        }
    }
}
