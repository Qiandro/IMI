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
    public class UserRepository : IUserRepository
    {
        private readonly IMIDbContext _dbContext;

        public UserRepository(IMIDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<ApplicationUser> AddUser(ApplicationUser user)
        {
            //user.Password = "123";
            user.LastOnline = DateTime.Now;
            user.Id = Guid.NewGuid().ToString();

            _dbContext.users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<ApplicationUser> DeleteUser(ApplicationUser user)
        {
            _dbContext.users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
        {
            return await _dbContext.users.ToListAsync();
        }

        public async Task<ApplicationUser> GetUser(Guid Id)
        {
            return await _dbContext.users.Where(e => e.Id == Id.ToString()).FirstOrDefaultAsync();
        }

        public async Task<ApplicationUser> UpdateUser(ApplicationUser user)
        {
            _dbContext.users.Update(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
    }
}
