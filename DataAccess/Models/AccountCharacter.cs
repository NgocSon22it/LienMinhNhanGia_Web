using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class AccountCharacter
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string CharacterId { get; set; }
        public int HealthBonus { get; set; }
        public int ChakraBonus { get; set; }
        public bool Delete { get; set; }

        public virtual Account Account { get; set; }
        public virtual Character Character { get; set; }
    }
}
