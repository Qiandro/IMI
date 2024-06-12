using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Dto_s
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime LastOnline { get; set; }
    }
}
