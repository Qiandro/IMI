using Imi.Project.Blazor.Dto_s;
using Imi.Project.Blazor.Entities;
using System.Text.RegularExpressions;
using System.Linq;
using Imi.Project.Blazor.Interfaces;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

namespace Imi.Project.Blazor.Services
{
    public class Eventservice : IEventservice
    {
        private readonly HttpClient _httpClient;
        private static readonly string url = "https://localhost:5001/api";

        public Eventservice(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Event>> GetEvents(string id)
        {
            var dto = await _httpClient.GetFromJsonAsync<IEnumerable<EventDto>>(url + $"/Events/Group/{id}");

            var events = dto.Select(x => new Event
            {
                EventId = x.EventId,
                GroupId = x.GroupId,
                CreatorId = x.CreatorId,
                Name = x.Name,
                Description = x.Description,
                CreationDate = x.CreationDate,
                LastEditedOn = x.LastEditedOn,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                DeletedOn = x.DeletedOn
            }).ToList();

            return events;
        }

        public async Task<Event> GetEventById(Guid id)
        {
            var dto = await _httpClient.GetFromJsonAsync<EventDto>(url + $"/Events/{id}");

            Event evnt = new Event
            {
                EventId = dto.EventId,
                GroupId = dto.GroupId,
                CreatorId = dto.CreatorId,
                Name = dto.Name,
                Description = dto.Description,
                CreationDate = dto.CreationDate,
                LastEditedOn = dto.LastEditedOn,

            };


            return evnt;
        }

        public async Task<Event> CreateEvent(CreateEventDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync<CreateEventDto>(url + "/Events", dto);
            var events = await _httpClient.GetFromJsonAsync<IEnumerable<EventDto>>(url + $"/Events/Group/{dto.GroupId}");

            Event evnt = events.Select(x => new Event
            {
                EventId = x.EventId,
                GroupId = x.GroupId,
                CreatorId = x.CreatorId,
                Name = x.Name,
                Description = x.Description,
                CreationDate = x.CreationDate,
                LastEditedOn = x.LastEditedOn,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                DeletedOn = x.DeletedOn,
            }).FirstOrDefault();

            return evnt;
        }

        public async Task SoftDeleteEvent(Guid id)
        {
            await _httpClient.DeleteAsync(url + $"/Events/{id}/SoftDelete");
        }

        public async Task<Event> UpdateEvent(UpdateEventDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync<UpdateEventDto>(url + $"/Events", dto);
            var evnt = await _httpClient.GetFromJsonAsync<Event>(url + $"/Events/{dto.EventId}");
            return evnt;
        }

    }
}
