using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Dto_s.Events
{
    public class CreateEventDto
    {
        public Guid GroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
