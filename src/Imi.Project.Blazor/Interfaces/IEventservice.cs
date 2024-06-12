using Imi.Project.Blazor.Dto_s;
using Imi.Project.Blazor.Entities;

namespace Imi.Project.Blazor.Interfaces
{
    public interface IEventservice
    {
        Task<List<Event>> GetEvents(string id);
        Task<Event> CreateEvent(CreateEventDto dto);
        Task SoftDeleteEvent(Guid id);
        Task<Event> GetEventById(Guid id);
        Task<Event> UpdateEvent(UpdateEventDto dto);
    }
}
