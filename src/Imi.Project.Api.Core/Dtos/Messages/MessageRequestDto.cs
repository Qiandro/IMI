using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Dtos.Messages
{
    public class MessageRequestDto
    {
        public Guid GroupId { get; set; }
        public string Content { get; set; }
    }
}
