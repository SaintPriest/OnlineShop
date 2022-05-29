using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.Repository;

namespace OnlineShop.Controllers
{
    public class AccountController : Controller
    {
        private MyDbContext db;
        public AccountController(MyDbContext dbContext)
        {
            db = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddAccount()
        {
            var viewModel = new AddAccountViewModel
            {
                Email = "example@com",
                Password = "password"
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddAccountAddBtn(Account account)
        {
            db.Accounts.Add(account);
            db.SaveChanges();
            return Json(account);
        }

        [HttpPost]
        public IActionResult Login(Account account)
        {
            Account found = db.Accounts.Find(account.Email);
            if (found == null)
            {
                return Json(false);
            }
            if (found.Password == account.Password)
            {
                HttpContext.Response.Cookies.Append("Email", account.Email);
                return Json(true);
            }
            return Json(false);
        }
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("Email");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Register()
        {
            return RedirectToAction("addAccount");
        }
    }
}
