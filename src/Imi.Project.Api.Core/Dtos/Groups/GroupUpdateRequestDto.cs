using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Dtos.Groups
{
    public class GroupUpdateRequestDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public Guid CreatorId { get; set; }
    }
}
