using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Item
    {
        public Item()
        {
            AccountItems = new HashSet<AccountItem>();
        }

        public string ItemId { get; set; }
        public string Name { get; set; }
        public int Coin { get; set; }
        public string Description { get; set; }
        public string LinkImage { get; set; }
        public bool Delete { get; set; }

        public virtual ICollection<AccountItem> AccountItems { get; set; }
    }
}
