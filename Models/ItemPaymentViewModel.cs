namespace OnlineShop.Models
{
    public class ItemPaymentViewModel
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalPrice { get; set; }
        public string Type { get; set; }
        public int Count { get; set; }
        public string ImgSrc { get; set; }
        public string PaymentMethod { get; set; }
        public string Address { get; set; }
    }
}
