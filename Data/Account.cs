using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Data
{
    public class Account
    {
        [Key]
        public string Email { get; set; }
        [Required]
        public string NickName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsSubscriber { get; set; }
    }
}
