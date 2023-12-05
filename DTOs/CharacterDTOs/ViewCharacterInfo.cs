using DTOs.SkillDTOs;
using System.Collections.Generic;

namespace DTOs.CharacterDTOs
{
    public class ViewCharacterInfo
    {
        public string CharacterId { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Chakra { get; set; }
        public int Damage { get; set; }
        public int Speed { get; set; }
        public string Description { get; set; }
        public string LinkImage { get; set; }
        public virtual ICollection<ViewSkillInfo> Skills { get; set; }
    }
}
