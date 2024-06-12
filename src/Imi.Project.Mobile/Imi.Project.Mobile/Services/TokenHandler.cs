using Imi.Project.Mobile.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Imi.Project.Mobile.Services
{
    public class TokenHandler : ITokenHandler
    {
        const string tokenKey = "AUTHTOKEN";

        public Task<string> GetToken()
            => SecureStorage.GetAsync(tokenKey);

        public async Task SaveToken(string token)
        {
            if (token == null)
                SecureStorage.Remove(tokenKey);
            else
                await SecureStorage.SetAsync(tokenKey, token);
        }

        public bool ValidateToken(string token)
        {
            if (token == null)
                return false;

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.ReadJwtToken(token);

            return
                securityToken.ValidTo.ToUniversalTime() >= DateTime.UtcNow &&
                securityToken.ValidFrom.ToUniversalTime() <= DateTime.UtcNow;
        }

        public async Task<string> GetUserIdFromToken()
        {
            var token = await GetToken();

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.ReadJwtToken(token);
            var claim = securityToken.Claims.FirstOrDefault(c=> c.Type == ClaimTypes.NameIdentifier).ToString();
            var id = claim.Substring(claim.Length-36);
            return id;
        }

    }
}
