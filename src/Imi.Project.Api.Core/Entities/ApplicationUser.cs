using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        //public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        //public string Password { get; set; }
        public DateTime LastOnline { get; set; }
        public DateTime BirthDate { get; set; }
        public bool HasApprovedTermsAndConditions { get; set; }


        public ICollection<GroupMembers> GroupMembers { get; set; }
        public ICollection<Admin> Admins { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Event> Events { get; set; }
    }

}
