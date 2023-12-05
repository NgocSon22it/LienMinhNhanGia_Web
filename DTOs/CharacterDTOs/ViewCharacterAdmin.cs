using DTOs.SkillDTOs;
using System.Collections.Generic;

namespace DTOs.CharacterDTOs
{
    public class ViewCharacterAdmin
    {
        public string CharacterId { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Chakra { get; set; }
        public int Damage { get; set; }
        public int Speed { get; set; }
        public string LinkImage { get; set; }
    }
}
