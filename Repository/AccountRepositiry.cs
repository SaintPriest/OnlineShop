using Microsoft.Extensions.Configuration;

namespace OnlineShop.Repository
{
    public class AccountRepositiry
    {
        private readonly IConfiguration _configuration;

        public AccountRepositiry(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
