using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Dtos.GroupMember
{
    public class GroupMemberRequestDto
    {
        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }
    }
}
