using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Entities
{
    public class Message
    {
        public Guid MessageId { get; set; }
        [ForeignKey("Group")]           
        public Guid GroupId { get; set; }
        [ForeignKey("Sender")]
        public string SenderId { get; set; }
        public DateTime SentTime { get; set; }
        public string Content { get; set; }
        public DateTime? LastEditedOn { get; set; }


        public Group Group { get; set; }
        public ApplicationUser Sender { get; set; }
        
    }
}
