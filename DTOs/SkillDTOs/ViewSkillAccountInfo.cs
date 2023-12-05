using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.SkillDTOs
{
    public class ViewSkillAccountInfo
    {
        public string SkillId { get; set; }
        public string Name { get; set; }
        public int Chakra { get; set; }
        public int Damage { get; set; }
        public int Coin { get; set; }
        public int CurrentLevel { get; set; }
        public string Description { get; set; }
        public string LinkImage { get; set; }
    }
}
