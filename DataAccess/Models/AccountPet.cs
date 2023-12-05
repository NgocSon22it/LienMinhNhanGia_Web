using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class AccountPet
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string PetId { get; set; }
        public int CurrentLevel { get; set; }
        public bool Equip { get; set; }
        public bool Delete { get; set; }

        public virtual Account Account { get; set; }
        public virtual Pet Pet { get; set; }
    }
}
