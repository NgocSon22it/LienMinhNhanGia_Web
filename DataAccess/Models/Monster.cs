using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Monster
    {
        public Monster()
        {
            MapMonsters = new HashSet<MapMonster>();
        }

        public string MonsterId { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Speed { get; set; }
        public int CoinBonus { get; set; }
        public string Description { get; set; }
        public string LinkImage { get; set; }
        public bool Delete { get; set; }

        public virtual ICollection<MapMonster> MapMonsters { get; set; }
    }
}
