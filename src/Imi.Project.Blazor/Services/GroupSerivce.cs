using Imi.Project.Blazor.Dto_s;
using Imi.Project.Blazor.Entities;
using Imi.Project.Blazor.Interfaces;
using System.Net.Http.Headers;

namespace Imi.Project.Blazor.Services
{
    public class GroupSerivce : IGroupService
    {

        private readonly HttpClient _httpClient;
        private static readonly string url = "https://localhost:5001/api";

        public GroupSerivce(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Group>> GetGroups(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

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

    }
}
