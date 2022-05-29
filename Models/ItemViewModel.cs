namespace OnlineShop.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
        public string ImgSrc { get; set; }
        public int Count  { get; set; }
        public string BuyerName { get; set; }
    }
}
