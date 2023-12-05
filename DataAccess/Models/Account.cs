using Obj_Common;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Account
    {
        public Account()
        {
            AccountAbilities = new HashSet<AccountAbility>();
            AccountCharacters = new HashSet<AccountCharacter>();
            AccountItems = new HashSet<AccountItem>();
            AccountMissions = new HashSet<AccountMission>();
            AccountPets = new HashSet<AccountPet>();
            AccountSkills = new HashSet<AccountSkill>();
        }

        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string Avatar { get; set; } 
        public int Coin { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; } = 1;
        public string CheckPoint { get; set; } = "map1_1";
        public int BossKill { get; set; }
        public int AmountSlotSkill { get; set; } = 3;
        public int PointSkill { get; set; }
        public bool Delete { get; set; }

        public virtual ICollection<AccountAbility> AccountAbilities { get; set; }
        public virtual ICollection<AccountCharacter> AccountCharacters { get; set; }
        public virtual ICollection<AccountItem> AccountItems { get; set; }
        public virtual ICollection<AccountMission> AccountMissions { get; set; }
        public virtual ICollection<AccountPet> AccountPets { get; set; }
        public virtual ICollection<AccountSkill> AccountSkills { get; set; }
    }
}
