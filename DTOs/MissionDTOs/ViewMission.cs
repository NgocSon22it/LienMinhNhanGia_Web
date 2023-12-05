using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.MissionDTOs
{
    public class ViewMission
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Request { get; set; }
        public int Target { get; set; }
        public int ExperienceBonus { get; set; }
        public int CoinBonus { get; set; }
        public int State { get; set; }

    }
}
