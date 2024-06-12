using Imi.Project.Blazor.Dto_s;
using Imi.Project.Blazor.Entities;

namespace Imi.Project.Blazor.Interfaces
{
    public interface ILogbookManager
    {
        event EventHandler RefreshEvents;
        Task OpenConnection();
        Task<string> Login();
        Task<IEnumerable<Group>> GetGroups();
        Task<IEnumerable<Event>> GetEvents(string id);
        Task<string> CreateEvent(CreateEventDto dto);

    }
}
