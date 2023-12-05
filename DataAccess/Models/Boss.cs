using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Boss
    {
        public Boss()
        {
            BossSkills = new HashSet<BossSkill>();
            Maps = new HashSet<Map>();
        }

        public string BossId { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Speed { get; set; }
        public int CoinBonus { get; set; }
        public int ExperienceBonus { get; set; }
        public int PointSkillBonus { get; set; }
        public int PercentBonus { get; set; }
        public string Description { get; set; }
        public string LinkImage { get; set; }
        public bool Delete { get; set; }

        public virtual ICollection<BossSkill> BossSkills { get; set; }
        public virtual ICollection<Map> Maps { get; set; }
    }
}
