using Imi.Project.Api.Core.Dtos.Events;
using Imi.Project.Api.Core.Dtos.Users;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.IServices;
using Imi.Project.Api.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetUser(Guid UserId)
        {
            var user = await _userService.GetUser(UserId);
            var requestDto = new UserResponseDto
            {
                Id = Guid.Parse(user.Id),
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                LastOnline = user.LastOnline,
            };

            return Ok(requestDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            var requestDto = users.Select(u => new UserResponseDto
            {
                Email = u.Email,
                FirstName = u.FirstName,
                Id = Guid.Parse(u.Id),
                LastName = u.LastName,
                LastOnline = u.LastOnline,
                
            });
            return Ok(requestDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRequestDto userRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            var user = new ApplicationUser
            {
                Email = userRequestDto.Email,
                FirstName= userRequestDto.FirstName,
                LastName= userRequestDto.LastName,
            };

            await _userService.AddUser(user);

            return Ok(user);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserUpdateRequestDto userRequestDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            var user = await _userService.GetUser(userRequestDto.Id);

            if (user == null)
            {
                return NotFound($"No event with ID {userRequestDto.Id} found");
            }

            user.Email = userRequestDto.Email;
            user.FirstName = userRequestDto.FirstName;  
            user.LastName = userRequestDto.LastName;        
  


            await _userService.UpdateUser(user);

            return Ok(user);
        }

        [HttpDelete("{UserId}")]
        public async Task<IActionResult> DeleteUser(Guid UserId)
        {
            var user = await _userService.GetUser(UserId);

            if (user == null)
            {
                return NotFound($"No event with ID {UserId} found");
            }

            await _userService.DeleteUser(user);
            return Ok(user);
        }

    }
}
