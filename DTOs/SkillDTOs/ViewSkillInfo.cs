using System.Collections.Generic;

namespace DTOs.SkillDTOs
{
    public class ViewSkillInfo
    {
        public string SkillId { get; set; }
        public string Name { get; set; }
        public int Chakra { get; set; }
        public int Damage { get; set; }
        public int Coin { get; set; }
        public int UpdateCoin { get; set; }
        public int LevelUnlock { get; set; }
        public string Description { get; set; }
        public string LinkImage { get; set; }
    }
}