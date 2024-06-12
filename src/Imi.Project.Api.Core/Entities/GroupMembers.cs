using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Entities
{
    public class GroupMembers
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        
        public Guid GroupId { get; set; }

        public Group Group { get; set; }
        public ApplicationUser User { get; set; }

    }
}
