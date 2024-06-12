using Imi.Project.Api.Core.Dtos.Users;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Dtos.Groups
{
    public class GroupResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public Guid CreatorId { get; set; }
        public IEnumerable<UserResponseDto> Members { get; set; }
        public IEnumerable<UserResponseDto> Admins { get; set; }
    }
}
