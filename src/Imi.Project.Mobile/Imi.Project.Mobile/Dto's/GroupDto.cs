using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Dto_s
{
    public class GroupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public Guid CreatorId { get; set; }
        public IEnumerable<UserDto> Members { get; set; }
        public IEnumerable<UserDto> Admins { get; set; }
    }
}
