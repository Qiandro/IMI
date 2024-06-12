using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.IRepositories
{
    public interface IGroupRepository
    {
        Task<Group> GetGroup(Guid Id);
        Task<IEnumerable<Group>> GetAllGroupsFromUser(Guid id);
        Task<IEnumerable<Group>> GetAllGroups();
        Task<Group> AddGroup(Group group);
        Task<Group> DeleteGroup(Group group);
        Task<Group> UpdateGroup(Group group);
        Task<GroupMembers> AddMember(GroupMembers member);
        Task<GroupMembers> DeleteMember(GroupMembers member);
        Task<IEnumerable<ApplicationUser>> GetAllGroupMembersFromGroup(Guid id);
        Task<IEnumerable<Group>> GetAllGroupsWithMembersAndAdmins();
        Task<IEnumerable<ApplicationUser>> GetAllGroupAdmins(Guid id);
        Task<Admin> AddAdmin(Admin admin);
        Task<Admin> DeleteAdmin(Admin admin);
    }
}
