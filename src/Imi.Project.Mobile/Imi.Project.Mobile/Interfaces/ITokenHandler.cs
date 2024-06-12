using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Interfaces
{
    public interface ITokenHandler
    {
        bool ValidateToken(string token);

        Task<string> GetToken();

        Task SaveToken(string token);
        Task<string> GetUserIdFromToken();
    }
}
