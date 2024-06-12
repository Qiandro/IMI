using Imi.Project.Api.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Imi.Project.Api.Core.Dtos.Events;
using Microsoft.EntityFrameworkCore;
using Imi.Project.Api.Core.Interfaces.IServices;
using Imi.Project.Api.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Globalization;

namespace Imi.Project.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public EventsController(IEventService eventService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _eventService = eventService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _eventService.GetAllEvents();
            var responseDto = events.Select(e => new EventResponseDto
            {
                CreatorId = Guid.Parse(e.CreatorId),
                EventId = e.EventId,
                CreationDate = e.CreationDate,
                Description = e.Description,
                GroupId = e.GroupId,
                Name = e.Name,
                LastEditedOn = e.LastEditedOn,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                DeletedOn = e.DeletedOn
            });
            return Ok(responseDto);
        }
        [HttpGet("{EventId}")]
        public async Task<IActionResult> GetEvent(Guid EventId)
        {
            var evnt = await _eventService.GetEvent(EventId);
            var responseDto = new EventResponseDto
            {
                CreatorId = Guid.Parse(evnt.CreatorId),
                EventId = evnt.EventId,
                CreationDate = evnt.CreationDate,
                Description = evnt.Description,
                GroupId = evnt.GroupId,
                Name = evnt.Name,
                StartDate = evnt.StartDate,
                EndDate = evnt.EndDate,
                DeletedOn = evnt.DeletedOn
            };
            return Ok(responseDto);
        }

        [HttpGet("Group/{GroupId}")]
        public async Task<IActionResult> GetAllEventsFromGroup(Guid GroupId)
        {
            var events = await _eventService.GetAllEventsFromGroup(GroupId);
            var requestDto = events.Select(e => new EventResponseDto
            {
                CreatorId = Guid.Parse(e.CreatorId),
                EventId = e.EventId,
                CreationDate = e.CreationDate,
                Description = e.Description,
                GroupId = e.GroupId,
                Name = e.Name,
                LastEditedOn = e.LastEditedOn,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                DeletedOn = e.DeletedOn
            });
            return Ok(requestDto);
        }

        [HttpGet("{GroupId}/{CreatorId}")]
        public async Task<IActionResult> GetEventsFromUserInGroup(Guid CreatorId, Guid GroupId)
        {
            var events = await _eventService.GetAllEventsFromUserInGroup(GroupId, CreatorId);
            var requestDto = events.Select(e => new EventResponseDto
            {
                CreatorId = Guid.Parse(e.CreatorId),
                EventId = e.EventId,
                CreationDate = e.CreationDate,
                Description = e.Description,
                GroupId = e.GroupId,
                Name = e.Name,
                LastEditedOn = e.LastEditedOn,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                DeletedOn = e.DeletedOn
            });
            return Ok(requestDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(EventRequestDto eventRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            var evnt = new Event
            {
                CreatorId = User.Claims.FirstOrDefault(u=> u.Type == ClaimTypes.NameIdentifier).Value,
                Description = eventRequestDto.Description,
                GroupId = eventRequestDto.GroupId,
                Name = eventRequestDto.Name,
                StartDate = eventRequestDto.StartDate,
                EndDate = eventRequestDto.EndDate
            };


            await _eventService.AddEvent(evnt);

            return Ok(evnt);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEvent(EventUpdateRequestDto eventRequestDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            var evnt = await _eventService.GetEvent(eventRequestDto.EventId);

            if (evnt == null)
            {
                return NotFound($"No event with ID {eventRequestDto.EventId} found");
            }
            
            if (evnt.DeletedOn is not null)
            {
                return NotFound($"u are not allowed to update something that is softDeleted");
            }

            evnt.Description = eventRequestDto.Description;
            evnt.Name = eventRequestDto.Name;
            evnt.StartDate = eventRequestDto.StartDate;
            evnt.EndDate = eventRequestDto.EndDate;
            evnt.GroupId = eventRequestDto.GroupId;

            await _eventService.UpdateEvent(evnt);

            return Ok(evnt);
        }

        [HttpDelete("{EventId}")]
        public async Task<IActionResult> DeleteEvent(Guid EventId)
        {
            var evnt = await _eventService.GetEvent(EventId);

            if (evnt == null)
            {
                return NotFound($"No event with ID {EventId} found");
            }

            await _eventService.DeleteEvent(evnt);



            return Ok(evnt);
        }

        [HttpDelete("{EventId}/SoftDelete")]
        public async Task<IActionResult> SoftDeleteEvent(Guid EventId)
        {
            var evnt = await _eventService.GetEvent(EventId);
            if (evnt == null)
            {
                return NotFound($"No event with ID {EventId} found");
            }

            await _eventService.SoftDeleteEvent(evnt);

            return Ok(evnt);
        }

    }
}
