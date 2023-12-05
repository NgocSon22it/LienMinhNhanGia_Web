using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Character
    {
        public Character()
        {
            AccountCharacters = new HashSet<AccountCharacter>();
            Skills = new HashSet<Skill>();
        }

        public string CharacterId { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Chakra { get; set; }
        public int Damage { get; set; }
        public int Speed { get; set; }
        public string Description { get; set; }
        public string LinkImage { get; set; }
        public bool Delete { get; set; }

        public virtual ICollection<AccountCharacter> AccountCharacters { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
    }
}
