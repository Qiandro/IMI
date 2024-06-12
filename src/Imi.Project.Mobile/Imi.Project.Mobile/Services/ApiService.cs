using FreshMvvm;
using Imi.Project.Mobile.Dto_s;
using Imi.Project.Mobile.Dto_s.Events;
using Imi.Project.Mobile.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Services
{
    public class ApiService : IApiService
    {
        private ITokenHandler _tokenHandler;
        public readonly string _url = "https://5wfgv6cg-5001.euw.devtunnels.ms/";

        //private static readonly string _url = "https://localhost:5001/";
        private HttpClient _HttpClient { get; set; }

        public ApiService(ITokenHandler token, HttpClient httpClient)
        {
            _tokenHandler = token;
            _HttpClient = httpClient;
            _HttpClient.BaseAddress = new Uri(_url);

        }

        public async Task<bool> Login(string email, string password)
        {
            var dto = new UserLoginDto
            {
                Email = email,
                Password = password,
            };
            string url = "api/auth/login";

            _HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("BEARER", await _tokenHandler.GetToken());

            var test = _HttpClient;
            var response = await _HttpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json"));


            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<LoginResultDto>(json);

                //save token!
                await _tokenHandler.SaveToken(result.Token);
                return true;
            }

            return false;
            
        }

        public Task Logout()
        {
            return _tokenHandler.SaveToken(null);
        }

        private async Task AddAuthAsync()
        {
            string token = await _tokenHandler.GetToken();
            if (_tokenHandler.ValidateToken(token))
            {
                _HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("BEARER", await _tokenHandler.GetToken());
            }
            else
            {
                _HttpClient.DefaultRequestHeaders.Authorization = null;
            }
        }

        public async Task<IEnumerable<GroupDto>> GetGroups()
        {
            var id = await _tokenHandler.GetUserIdFromToken();
            var response = await _HttpClient.GetStringAsync($"Groups/User/{id}");

            var result = JsonConvert.DeserializeObject<IEnumerable<GroupDto>>(response);

            return result;
        }

        public async Task<IEnumerable<EventDto>> GetEvents(string GroupId)
        {
            var response = await _HttpClient.GetStringAsync($"api/Events/Group/{GroupId}");

            var result = JsonConvert.DeserializeObject<IEnumerable<EventDto>>(response);

            return result;
        }

        public async Task DeleteEvent(string EventId)
        {
            var response = await _HttpClient.DeleteAsync($"api/Events/{EventId}");
        }

        public async Task UpdateEvent(UpdateEventDto dto)
        {
            var response = await _HttpClient.PutAsync($"api/Events", new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json"));
        }

        public async Task CreateEvent(CreateEventDto dto)
        {
            var response = await _HttpClient.PostAsync($"api/Events", new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json"));
        }

    }
}
