using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class AccountItem
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string ItemId { get; set; }
        public int Amount { get; set; }
        public bool Delete { get; set; }

        public virtual Account Account { get; set; }
        public virtual Item Item { get; set; }
    }
}
