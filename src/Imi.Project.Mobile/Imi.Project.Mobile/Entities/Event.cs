using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Entities
{
    public class Event
    {
        public Guid EventId { get; set; }
        public Guid GroupId { get; set; }
        public Guid CreatorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Date { get; set; }
        public DateTime? LastEditedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
