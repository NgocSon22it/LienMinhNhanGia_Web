using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Skill
    {
        public Skill()
        {
            AccountSkills = new HashSet<AccountSkill>();
        }

        public string SkillId { get; set; }
        public string CharacterId { get; set; }
        public string Name { get; set; }
        public int Chakra { get; set; }
        public int Damage { get; set; }
        public int Coin { get; set; }
        public int LevelUnlock { get; set; }
        public int UpdateCoin { get; set; }
        public string Description { get; set; }
        public string LinkImage { get; set; }
        public bool Delete { get; set; }

        public virtual Character Character { get; set; }
        public virtual ICollection<AccountSkill> AccountSkills { get; set; }
    }
}
