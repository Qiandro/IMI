using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Entities
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public string CreatorId { get; set; }

        public ApplicationUser Creator { get; set; }
        public ICollection<GroupMembers> GroupMembers { get; set; }
        public ICollection<Admin> Admins { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Event> Events { get; set; }

    }
}
