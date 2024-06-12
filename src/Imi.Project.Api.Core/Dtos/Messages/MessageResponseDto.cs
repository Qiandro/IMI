using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Dtos.Messages
{
    public class MessageResponseDto
    {
        public Guid MessageId { get; set; }
        public Guid GroupId { get; set; }
        public Guid SenderId { get; set; }
        public DateTime SentTime { get; set; }
        public string Content { get; set; }
    }
}
