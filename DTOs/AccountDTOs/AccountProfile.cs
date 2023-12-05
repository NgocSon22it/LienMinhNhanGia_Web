using Obj_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.AccountDTOs
{
    public class AccountProfile
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
        public string Avatar { get; set; }
        public int Coin { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
    }
}
