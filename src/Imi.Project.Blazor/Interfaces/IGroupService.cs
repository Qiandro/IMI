using Imi.Project.Blazor.Entities;

namespace Imi.Project.Blazor.Interfaces
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> GetGroups(string token);
    }
}
