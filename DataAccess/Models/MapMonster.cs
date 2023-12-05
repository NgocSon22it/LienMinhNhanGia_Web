using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class MapMonster
    {
        public int Id { get; set; }
        public string MapId { get; set; }
        public string MonsterId { get; set; }
        public bool Delete { get; set; }

        public virtual Map Map { get; set; }
        public virtual Monster Monster { get; set; }
    }
}
