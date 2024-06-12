using Imi.Project.Blazor.Dto_s;

namespace Imi.Project.Blazor.Entities
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public Guid CreatorId { get; set; }
        public IEnumerable<UserDto> Members { get; set; }
        public IEnumerable<UserDto> Admins { get; set; }
    }
}
