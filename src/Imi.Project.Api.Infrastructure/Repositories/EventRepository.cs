using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.IRepositories;
using Imi.Project.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly IMIDbContext _DBcontext;

        public EventRepository(IMIDbContext context)
        {
            _DBcontext = context;
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _DBcontext.events.ToListAsync();
        }

        public async Task<Event> GetEvent(Guid Id)
        {
            return await _DBcontext.events.Where(e => e.EventId == Id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Event>> GetAllEventsFromGroup(Guid Id)
        {
            return await _DBcontext.events.Where(e => e.GroupId == Id).OrderByDescending(e => e.CreationDate).ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetAllEventsFromUserInGroup(Guid GroupId, Guid CreatorId)
        {
            return await _DBcontext.events.Where(e => e.GroupId == GroupId && e.CreatorId == CreatorId.ToString()).ToListAsync();
        }

        public async Task<Event> AddEvent(Event evnt)
        {
            evnt.LastEditedOn = null;
            evnt.CreationDate = DateTime.Now;
            evnt.EventId = Guid.NewGuid();

            _DBcontext.events.Add(evnt);
            await _DBcontext.SaveChangesAsync();
            return evnt;
        }

        public async Task<Event> DeleteEvent(Event evnt)
        {
            _DBcontext.events.Remove(evnt);
            await _DBcontext.SaveChangesAsync();
            return evnt;
        }

        public async Task<Event> UpdateEvent(Event evnt)
        {
            evnt.LastEditedOn = DateTime.Now;

            _DBcontext.events.Update(evnt);
            await _DBcontext.SaveChangesAsync();
            return evnt;
        }

        public async Task<Event> SoftDeleteEvent(Event evnt)
        {
            evnt.DeletedOn = DateTime.Now;

            _DBcontext.events.Update(evnt);
            await _DBcontext.SaveChangesAsync();
            return evnt;
        }

    }
}
