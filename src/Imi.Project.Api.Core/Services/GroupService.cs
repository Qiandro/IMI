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
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository  _grouprepo;

        public GroupService(IGroupRepository groupRepo)
        {
            _grouprepo = groupRepo;
        }

        public async Task<Group> AddGroup(Group group)
        {
            return await _grouprepo.AddGroup(group);
        }

        public async Task<GroupMembers> AddMember(GroupMembers member)
        {
            return await _grouprepo.AddMember(member);
        }
        public async Task<Admin> AddAdmin(Admin admin)
        {
            return await _grouprepo.AddAdmin(admin);
        }

        public async Task<Group> DeleteGroup(Group group)
        {
            return await _grouprepo.DeleteGroup(group);
        }

        public async Task<GroupMembers> DeleteMember(GroupMembers member)
        {
            return await _grouprepo.DeleteMember(member);
        }
        public async Task<Admin> DeleteAdmin(Admin admin)
        {
            return await _grouprepo.DeleteAdmin(admin);
        }

        public Task<IEnumerable<ApplicationUser>> GetAllGroupAdmins(Guid id)
        {
            return _grouprepo.GetAllGroupAdmins(id);
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllGroupMembersFromGroup(Guid id)
        {
            return await _grouprepo.GetAllGroupMembersFromGroup(id);
        }

        public async Task<IEnumerable<Group>> GetAllGroups()
        {
            return await _grouprepo.GetAllGroups();
        }

        public async Task<IEnumerable<Group>> GetAllGroupsFromUser(Guid id)
        {
            return await _grouprepo.GetAllGroupsFromUser(id);
        }

        public async Task<IEnumerable<Group>> GetAllGroupsWithMembersAndAdmins()
        {
            return await _grouprepo.GetAllGroupsWithMembersAndAdmins();
        }

        public async Task<Group> GetGroup(Guid Id)
        {
            return await _grouprepo.GetGroup(Id);
        }

        public async Task<Group> UpdateGroup(Group group)
        {
            return await _grouprepo.UpdateGroup(group);
        }
    }
}
