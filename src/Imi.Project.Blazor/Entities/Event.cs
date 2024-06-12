using System.ComponentModel.DataAnnotations.Schema;

namespace Imi.Project.Blazor.Entities
{
    public class Event
    {
        public Guid EventId { get; set; }
        public Guid GroupId { get; set; }
        public Guid CreatorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? LastEditedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
