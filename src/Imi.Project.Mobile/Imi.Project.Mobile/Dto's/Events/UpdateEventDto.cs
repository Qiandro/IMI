using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Dto_s
{
    public class UpdateEventDto
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid GroupId { get; set; }
    }
}
