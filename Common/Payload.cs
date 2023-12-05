using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obj_Common
{
    public class Payload
    {
        public Payload() { }

        public string AccountId { get; set; }
        public Role Role { get; set; }
        public string Avatar { get; set; }
    }
}
