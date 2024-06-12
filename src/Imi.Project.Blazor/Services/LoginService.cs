using Imi.Project.Blazor.Dto_s;
using Imi.Project.Blazor.Interfaces;

namespace Imi.Project.Blazor.Services
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _httpClient;
        private static readonly string url = "https://localhost:5001/api";

        public string token { get; set; }

        public LoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Login()
        {
            LoginResponseDto token = new LoginResponseDto();
            LoginDto dto = new LoginDto();
            dto.Email = "Qiandro.claeys@gmail.com";
            dto.Password = "Test123?";

            var test = await _httpClient.PostAsJsonAsync(url + "/auth/login", dto);
            
            var response = test.Content.ReadFromJsonAsync<LoginResponseDto>();
            
            token = response.Result;

            return token.Token;
        }


    }
}
