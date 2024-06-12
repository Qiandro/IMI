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
    public class GroupRepository : IGroupRepository
    {
        private readonly IMIDbContext _DBcontext;

        public GroupRepository(IMIDbContext context)
        {
            _DBcontext = context;
        }


        public async Task<Group> AddGroup(Group group)
        {
            group.Id = Guid.NewGuid();

            _DBcontext.groups.Add(group);
            await _DBcontext.SaveChangesAsync();
            return group;
        }

        public async Task<GroupMembers> AddMember(GroupMembers member)
        {
            _DBcontext.members.Add(member);
            await _DBcontext.SaveChangesAsync();
            return member;
        }

        public async Task<Admin> AddAdmin(Admin admin)
        {
            _DBcontext.Admin.Add(admin);
            await _DBcontext.SaveChangesAsync();
            return admin;
        }

        public async Task<Group> DeleteGroup(Group group)
        {
            _DBcontext.groups.Remove(group);
            await _DBcontext.SaveChangesAsync();
            return group;
        }

        public async Task<GroupMembers> DeleteMember(GroupMembers member)
        {
            _DBcontext.members.Remove(member);
            await _DBcontext.SaveChangesAsync();
            return member;
        }

        public async Task<Admin> DeleteAdmin(Admin admin)
        {
            _DBcontext.Admin.Remove(admin);
            await _DBcontext.SaveChangesAsync();
            return admin;
        }

        public async Task<IEnumerable<Group>> GetAllGroups()
        {
            return await _DBcontext.groups.ToListAsync();
        }

        public async Task<IEnumerable<Group>> GetAllGroupsFromUser(Guid id)
        {
            var members = await _DBcontext.members.Where(m=> m.UserId == id.ToString()).ToListAsync();
            List<Group> groups = new List<Group>();

            foreach (var member in members)
            {
                groups.Add(await _DBcontext.groups.Where(g => g.Id == member.GroupId).FirstOrDefaultAsync());
                //groups.Append(await _DBcontext.groups.Where(g => g.Id == member.GroupId).FirstOrDefaultAsync());
            }

            return groups;

        }

        public async Task<Group> GetGroup(Guid Id)
        {
            return await _DBcontext.groups.Where(g => g.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<Group> UpdateGroup(Group group)
        {
            _DBcontext.groups.Update(group);
            await _DBcontext.SaveChangesAsync();
            return group;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllGroupMembersFromGroup(Guid id)
        {
            var groupMembers = await _DBcontext.members.Where(g => g.GroupId == id).ToListAsync();

            List<ApplicationUser> members = new List<ApplicationUser>();

            foreach (var member in groupMembers)
            {
                members.Add(await _DBcontext.users.Where(u => u.Id == member.UserId.ToString()).FirstOrDefaultAsync());
            }
            return members;
        }

        public async Task<IEnumerable<Group>> GetAllGroupsWithMembersAndAdmins()
        {
            return await _DBcontext.groups.Include(g=> g.GroupMembers).Include(g=> g.Admins).ToListAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllGroupAdmins(Guid id)
        {
            var groupAdmins = await _DBcontext.Admin.Where(g => g.GroupId == id).ToListAsync();

            List<ApplicationUser> members = new List<ApplicationUser>();

            foreach (var member in groupAdmins)
            {
                members.Add(await _DBcontext.users.Where(u => u.Id == member.UserId.ToString()).FirstOrDefaultAsync());
            }

            return members;
        }
    }
}
