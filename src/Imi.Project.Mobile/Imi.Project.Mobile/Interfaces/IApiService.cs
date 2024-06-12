using Imi.Project.Mobile.Dto_s;
using Imi.Project.Mobile.Dto_s.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Interfaces
{
    public interface IApiService
    {
        Task<bool> Login(string email, string password);
        Task CreateEvent(CreateEventDto dto);
        Task<IEnumerable<EventDto>> GetEvents(string GroupId);
        Task UpdateEvent(UpdateEventDto dto);
        Task<IEnumerable<GroupDto>> GetGroups();
        Task Logout();
        Task DeleteEvent(string EventId);
    }
}
