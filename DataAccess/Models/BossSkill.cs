using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class BossSkill
    {
        public string Id { get; set; }
        public string BossId { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public string Description { get; set; }
        public string LinkImage { get; set; }
        public bool Delete { get; set; }

        public virtual Boss Boss { get; set; }
    }
}
