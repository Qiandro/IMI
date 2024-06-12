using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.IRepositories
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetGroupMessages(Guid GroupId);
        Task<Message> GetMessage(Guid MessageId);
        Task<Message> AddMessage(Message msg);
        Task<Message> DeleteMessage(Message msg);
        Task<Message> UpdateMessage(Message msg);
    }
}
