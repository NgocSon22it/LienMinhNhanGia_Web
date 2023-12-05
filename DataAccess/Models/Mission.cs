using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Mission
    {
        public Mission()
        {
            AccountMissions = new HashSet<AccountMission>();
        }

        public string MissionId { get; set; }
        public string MapId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Request { get; set; }
        public int Target { get; set; }
        public int ExperienceBonus { get; set; }
        public int CoinBonus { get; set; }
        public bool Delete { get; set; }

        public virtual Map Map { get; set; }
        public virtual ICollection<AccountMission> AccountMissions { get; set; }
    }
}
