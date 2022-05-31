using OnlineShop.Data;
using System.Collections.Generic;

namespace OnlineShop.Models
{
    public class ItemDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
        public string ImgSrc { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
