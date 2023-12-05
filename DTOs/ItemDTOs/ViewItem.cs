using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.ItemDTOs
{
    public class ViewItem
    {
        public string ItemId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Coin { get; set; }
        public string Description { get; set; }
        public string LinkImage { get; set; }
    }
}
