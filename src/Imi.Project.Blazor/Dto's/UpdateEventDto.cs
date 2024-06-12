namespace Imi.Project.Blazor.Dto_s
{
    public class UpdateEventDto
    {
        public Guid GroupId { get; set; }
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
