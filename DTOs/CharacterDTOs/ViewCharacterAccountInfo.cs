using DTOs.SkillDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.CharacterDTOs
{
    public class ViewCharacterAccountInfo
    {
        public string CharacterId { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Chakra { get; set; }
        public int Damage { get; set; }
        public int Speed { get; set; }
        public string Description { get; set; }
        public string LinkImage { get; set; }
        public virtual ICollection<ViewSkillAccountInfo> Skills { get; set; }
    }
}
