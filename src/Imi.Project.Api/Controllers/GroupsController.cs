using Imi.Project.Api.Core.Dtos.GroupMember;
using Imi.Project.Api.Core.Dtos.Groups;
using Imi.Project.Api.Core.Dtos.Users;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.IServices;
using Imi.Project.Api.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace Imi.Project.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;
        private readonly IUserService _userService;

        public GroupsController(IGroupService groupService, IUserService userService)
        {
            _groupService = groupService;
            _userService = userService;
        }

        [HttpGet("{GroupId}")]
        public async Task<IActionResult> GetGroup(Guid GroupId)
        {
            var user = await _groupService.GetGroup(GroupId);
            var groupMembers = await _groupService.GetAllGroupMembersFromGroup(GroupId);
            var AdminMembers = await _groupService.GetAllGroupAdmins(GroupId);

            var requestDto = new GroupResponseDto
            {
                CreatorId = Guid.Parse(user.CreatorId),
                Id = user.Id,
                Img = user.Img,
                Name = user.Name,
                Members = groupMembers.Select(m => new UserResponseDto
                {
                    LastOnline = DateTime.Now,
                    Id = Guid.Parse(m.Id),
                    Email = m.Email,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    
                }),
                Admins = groupMembers.Select(m => new UserResponseDto
                {
                    LastOnline = DateTime.Now,
                    Id = Guid.Parse(m.Id),
                    Email = m.Email,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                   
                })
            };
            return Ok(requestDto);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllGroups()
        {
            var groups = await _groupService.GetAllGroupsWithMembersAndAdmins();


            var requestDto = groups.Select(g => new GroupResponseDto
            {

                Id = g.Id,
                Name = g.Name,
                CreatorId = Guid.Parse(g.CreatorId),
                Img = g.Img,
                Members = g.GroupMembers.Select(m => new UserResponseDto
                {
                    LastOnline = _userService.GetUser(Guid.Parse(m.UserId)).Result.LastOnline,
                    Email = _userService.GetUser(Guid.Parse(m.UserId)).Result.Email,
                    FirstName = _userService.GetUser(Guid.Parse(m.UserId)).Result.FirstName,
                    LastName = _userService.GetUser(Guid.Parse(m.UserId)).Result.LastName,
                    Id =  Guid.Parse( _userService.GetUser(Guid.Parse(m.UserId)).Result.Id),
                    
                }),
                Admins = g.Admins.Select(m => new UserResponseDto
                {
                    LastOnline = _userService.GetUser(Guid.Parse(m.UserId)).Result.LastOnline,
                    Email = _userService.GetUser(Guid.Parse(m.UserId)).Result.Email,
                    FirstName = _userService.GetUser(Guid.Parse(m.UserId)).Result.FirstName,
                    LastName = _userService.GetUser(Guid.Parse(m.UserId)).Result.LastName,
                    Id = Guid.Parse(_userService.GetUser(Guid.Parse(m.UserId)).Result.Id),
                    
                })

            });


            var test = requestDto;
            return Ok(requestDto);
        }

        [HttpGet("/Groups/User/{UserId}")]
        public async Task<IActionResult> GetAllGroupsFromUser(Guid UserId)
        {
            var groups = await _groupService.GetAllGroupsFromUser(UserId);
            var requestDto = groups.Select(g => new GroupUserResponseDto
            {
                Id = g.Id,
                Name = g.Name,
                CreatorId = Guid.Parse(g.CreatorId),
                Img = g.Img
            });
            return Ok(requestDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup(GroupRequestDto groupRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }


            var group = new Core.Entities.Group
            {
                Name = groupRequestDto.Name,
                Img = groupRequestDto.Img,
                CreatorId = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value,
            };

            await _groupService.AddGroup(group);

            return Ok(group);
        }

        [HttpPost("{GroupId}/User/{UserId}")]
        public async Task<IActionResult> AddMember(Guid GroupId, Guid UserId)
        {
            var group = await _groupService.GetGroup(GroupId);
            var user = await _userService.GetUser(UserId);

            if (group == null)
            {
                return NotFound($"No group with ID {GroupId} found");
            }
            else if (user == null)
            {
                return NotFound($"No user with ID {UserId} found");
            }

            var member = new GroupMembers
            {
                UserId = user.Id,
                GroupId = group.Id,
            };

            await _groupService.AddMember(member);
            return Ok();
        }

        [HttpPost("{GroupId}/Admin/{UserId}")]
        public async Task<IActionResult> AddAdmin(Guid GroupId, Guid UserId)
        {
            var group = await _groupService.GetGroup(GroupId);
            var user = await _userService.GetUser(UserId);

            if (group == null)
            {
                return NotFound($"No gropu with ID {GroupId} found");
            }
            else if (user == null)
            {
                return NotFound($"No user with ID {UserId} found");
            }

            var Admin = new Admin
            {
                UserId = Guid.Parse(user.Id).ToString(),
                GroupId = group.Id,
            };

            await _groupService.AddAdmin(Admin);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGroup(GroupUpdateRequestDto groupUpdateRequestDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            var group = await _groupService.GetGroup(groupUpdateRequestDto.Id);

            if (group == null)
            {
                return NotFound($"No event with ID {groupUpdateRequestDto.Id} found");
            }

            group.Name = groupUpdateRequestDto.Name;
            group.CreatorId = groupUpdateRequestDto.CreatorId.ToString();
            group.Img = groupUpdateRequestDto.Img;
            

            await _groupService.UpdateGroup(group);

            return Ok(group);
        }

        [HttpDelete("{GroupId}")]
        public async Task<IActionResult> DeleteGroup(Guid GroupId)
        {
            var group = await _groupService.GetGroup(GroupId);

            if (group == null)
            {
                return NotFound($"No group with ID {GroupId} found");
            }

            await _groupService.DeleteGroup(group);
            return Ok(group);
        }

        [HttpDelete("{GroupId}/User/{UserId}")]
        public async Task<IActionResult> DeleteUserFromGroup(Guid GroupId, Guid UserId) 
        { 
            var group = await _groupService.GetGroup(GroupId);
            var user = await _userService.GetUser(UserId);

            if (group == null)
            {
                return NotFound($"No gropu with ID {GroupId} found");
            }
            else if (user == null)
            {
                return NotFound($"No user with ID {UserId} found");
            }

            var member = new GroupMembers
            {
                UserId = user.Id,
                GroupId = group.Id,
            };

            await _groupService.DeleteMember(member);
            return Ok(member);

        }

        [HttpDelete("{GroupId}/Admin/{UserId}")]
        public async Task<IActionResult> DeleteAdmin(Guid GroupId, Guid UserId) 
        {
            var group = await _groupService.GetGroup(GroupId);
            var user = await _userService.GetUser(UserId);

            if (group == null)
            {
                return NotFound($"No gropu with ID {GroupId} found");
            }
            else if (user == null)
            {
                return NotFound($"No user with ID {UserId} found");
            }

            var admin = new Admin
            {
                UserId = Guid.Parse(user.Id).ToString(),
                GroupId = group.Id,
            };

            await _groupService.DeleteAdmin(admin);
            return Ok(admin);
        }

    }
}

