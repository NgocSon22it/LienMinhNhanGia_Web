using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Ability
    {
        public Ability()
        {
            AccountAbilities = new HashSet<AccountAbility>();
        }

        public string AbilityId { get; set; }
        public string Name { get; set; }
        public int LevelUnlock { get; set; }
        public string Description { get; set; }
        public string LinkImage { get; set; }
        public bool Delete { get; set; }

        public virtual ICollection<AccountAbility> AccountAbilities { get; set; }
    }
}
