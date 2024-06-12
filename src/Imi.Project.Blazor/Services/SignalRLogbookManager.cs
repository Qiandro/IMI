using Imi.Project.Blazor.Dto_s;
using Imi.Project.Blazor.Entities;
using Imi.Project.Blazor.Interfaces;
using Microsoft.AspNetCore.SignalR.Client;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Imi.Project.Blazor.Services
{
    public class SignalRLogbookManager : ILogbookManager
    {
        private readonly string CreatedEventString = "CreatedEvent";
        private readonly string RefreshEventString = "RefreshEvents";
        private HubConnection _hubConnection;
        private readonly HttpClient _httpClient;
        private static readonly string url = "https://localhost:5001/api";

        public string token { get; set; }

        public event EventHandler RefreshEvents;
        
        public SignalRLogbookManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task OpenConnection()
        { 
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44371/LogbookHub")
                .Build();

            _hubConnection.On(RefreshEventString, () =>
            {
                RefreshEvents?.Invoke(this, new EventArgs());
               
            });

            await _hubConnection.StartAsync();

        }

        public async Task<string> Login()
        {
            LoginResponseDto token = new LoginResponseDto();
            LoginDto dto = new LoginDto();
            dto.Email = "Qiandro.claeys@gmail.com";
            dto.Password = "Test123?";

            var test = await _httpClient.PostAsJsonAsync(url + "/auth/login", dto);

            token = await test.Content.ReadFromJsonAsync<LoginResponseDto>();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
            return token.Token;
        }

        public async Task<IEnumerable<Group>> GetGroups()
        {
           

            var dto = await _httpClient.GetFromJsonAsync<IEnumerable<GroupDto>>(url + "/Groups");

            var groups = dto.Select(x => new Group
            {
                Id = x.Id,
                Admins = x.Admins,
                CreatorId = x.CreatorId,
                Img = x.Img,
                Members = x.Members,
                Name = x.Name,
            });

            return groups;
        }

        public async Task<IEnumerable<Event>> GetEvents(string id)
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
            });

            return events;
        }

        public async Task<string> CreateEvent(CreateEventDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync<CreateEventDto>(url + "/Events", dto);
            
            await _hubConnection.SendAsync(CreatedEventString, "test");

            return "succes";
        }

    }
}
