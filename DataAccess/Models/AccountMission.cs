using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class AccountMission
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string MissionId { get; set; }
        public int State { get; set; }
        public int Current { get; set; }
        public bool Delete { get; set; }

        public virtual Account Account { get; set; }
        public virtual Mission Mission { get; set; }
    }
}
