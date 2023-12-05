using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.AccountDTOs
{
    public class UpdateGameSpecs
    {
        public int Coin { get; set; } = -1;
        public int Experience { get; set; } = -1;
        public int Level { get; set; } = -1;
        public string CheckPoint { get; set; }
        public int BossKill { get; set; } = -1;
        public int AmountSlotSkill { get; set; } = -1;
        public int PointSkill { get; set; } = -1;
    }
}
