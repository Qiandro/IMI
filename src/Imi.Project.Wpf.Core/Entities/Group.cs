using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Wpf.Core.Entities
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public Guid CreatorId { get; set; }
        public IEnumerable<User> Members { get; set; }
        public IEnumerable<User> Admins { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
