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
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApplicationUser> AddUser(ApplicationUser user)
        {
            return await _repository.AddUser(user);
        }

        public async Task<ApplicationUser> DeleteUser(ApplicationUser user)
        {
            return await _repository.DeleteUser(user);
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
        {
            return await _repository.GetAllUsers();
        }

        public async Task<ApplicationUser> GetUser(Guid Id)
        {
            return await _repository.GetUser(Id);
        }

        public async Task<ApplicationUser> UpdateUser(ApplicationUser user)
        {
            return await _repository.UpdateUser(user);
        }
    }
}
