using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Entities
{
    public class Event
    {
        public Guid EventId { get; set; }
        [ForeignKey("Group")]
        public Guid GroupId { get; set; }
        [ForeignKey("Creator")]
        public string CreatorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set;}
        public DateTime EndDate { get; set;}
        public DateTime CreationDate { get; set; }
        public DateTime? LastEditedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        public Group Group { get; set; }
        public ApplicationUser Creator { get; set; }
    }
}
