using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class AccountSkill
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string SkillId { get; set; }
        public int CurrentLevel { get; set; } = 1;
        public int SlotIndex { get; set; }
        public bool Delete { get; set; }

        public virtual Account Account { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
