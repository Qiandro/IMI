using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Entities
{
    public class Admin
    {
        public Guid GroupId { get; set; }
        //[ForeignKey("User")]
        public string UserId { get; set; }

        public Group Group { get; set; }
        public ApplicationUser User { get; set; }  
    }
}
