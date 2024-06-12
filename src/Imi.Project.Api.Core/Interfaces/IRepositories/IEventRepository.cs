using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.IRepositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<Event> GetEvent(Guid Id);
        Task<IEnumerable<Event>> GetAllEventsFromGroup(Guid Id);
        Task<IEnumerable<Event>> GetAllEventsFromUserInGroup(Guid EventId, Guid CreatorId);
        Task<Event> AddEvent(Event evnt);
        Task<Event> DeleteEvent(Event evnt);
        Task<Event> UpdateEvent(Event evnt);
        Task<Event> SoftDeleteEvent(Event evnt);
    }
}
