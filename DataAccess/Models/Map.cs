using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Map
    {
        public Map()
        {
            MapMonsters = new HashSet<MapMonster>();
            Missions = new HashSet<Mission>();
        }

        public string MapId { get; set; }
        public string BossId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LinkImage { get; set; }
        public bool Delete { get; set; }

        public virtual Boss Boss { get; set; }
        public virtual ICollection<MapMonster> MapMonsters { get; set; }
        public virtual ICollection<Mission> Missions { get; set; }
    }
}
