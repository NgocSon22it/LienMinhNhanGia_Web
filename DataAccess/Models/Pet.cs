using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Pet
    {
        public Pet()
        {
            AccountPets = new HashSet<AccountPet>();
        }

        public string PetId { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public float AttackSpeed { get; set; }
        public int AttackRange { get; set; }
        public int BossKillUnlock { get; set; }
        public int Coin { get; set; }
        public int UpdateCoin { get; set; }
        public string Description { get; set; }
        public string LinkImage { get; set; }
        public bool Delete { get; set; }

        public virtual ICollection<AccountPet> AccountPets { get; set; }
    }
}
