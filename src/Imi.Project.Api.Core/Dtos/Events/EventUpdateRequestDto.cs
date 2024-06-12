using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Dtos.Events
{
    public class EventUpdateRequestDto
    {
        public Guid GroupId { get; set; }
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set;}
        public DateTime EndDate { get; set;}
    }
}
