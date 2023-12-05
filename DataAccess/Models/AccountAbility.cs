using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class AccountAbility
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string AbilityId { get; set; }
        public bool Delete { get; set; }

        public virtual Ability Ability { get; set; }
        public virtual Account Account { get; set; }
    }
}
