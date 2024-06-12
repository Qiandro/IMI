using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.IServices
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUser(Guid Id);
        Task<IEnumerable<ApplicationUser>> GetAllUsers();
        Task<ApplicationUser> AddUser(ApplicationUser user);
        Task<ApplicationUser> DeleteUser(ApplicationUser user);
        Task<ApplicationUser> UpdateUser(ApplicationUser user);
    }
}
