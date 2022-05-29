using OnlineShop.Data;
using System.Collections.Generic;

namespace OnlineShop.Models
{
    public class OrderViewModel
    {
        public List<ItemViewModel> Items { get; set; }
        public List<ItemViewModel> ReceivedItems { get; set; }
    }
}
