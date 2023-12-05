using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obj_Common
{
    public class Tokens
    {
        public Role Role { get; set; }
        public string Avatar { get; set; }
        public string Access_Token { get; set; }
        public string Refresh_Token { get; set; }
    }
}
