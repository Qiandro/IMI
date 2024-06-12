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
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventrepo;
        
        public EventService(IEventRepository eventRepo)
        {
            _eventrepo = eventRepo;
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _eventrepo.GetAllEvents();
        }

        public virtual async Task<Event> GetEvent(Guid id)
        {
            return await _eventrepo.GetEvent(id);
        }

        public virtual async Task<IEnumerable<Event>> GetAllEventsFromGroup(Guid Id)
        {
            var events = await _eventrepo.GetAllEventsFromGroup(Id);
            return events;
        }

        public async Task<IEnumerable<Event>> GetAllEventsFromUserInGroup(Guid GroupId, Guid CreatorId)
        {
            return await _eventrepo.GetAllEventsFromUserInGroup(GroupId, CreatorId);
        }

        public async Task<Event> AddEvent(Event evnt)
        {
            return await _eventrepo.AddEvent(evnt);
        }

        public async Task<Event> DeleteEvent(Event evnt)
        {
            return await _eventrepo.DeleteEvent(evnt);
        }

        public async Task<Event> UpdateEvent(Event evnt)
        {
            return await _eventrepo.UpdateEvent(evnt);
        }

        public async Task<Event> SoftDeleteEvent(Event evnt)
        {
            return await _eventrepo.SoftDeleteEvent(evnt);
        }

    }
}
