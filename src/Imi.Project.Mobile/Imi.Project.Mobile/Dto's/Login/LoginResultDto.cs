using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Dto_s
{
    public class LoginResultDto
    {
        public string Token { get; set; }
        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
