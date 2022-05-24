using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.Repository;
using System.Collections.Generic;

namespace OnlineShop.Controllers
{
    public class ItemController : Controller
    {
        private MyDbContext db;
        public ItemController(MyDbContext dbContext)
        {
            db = dbContext;
        }
        public IActionResult Index()
        {
            var viewModel = new ItemListViewModel
            {
                Items = new List<ItemViewModel>(),
            };
            foreach(var item in db.Items)
            {
                viewModel.Items.Add(new ItemViewModel
                {
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Type = item.Type,
                });
            }
            return View(viewModel);
        }
        public IActionResult AddItem()
        {
            var viewModel = new ItemViewModel
            {
                Name = "itemname",
                Description = "description",
                Price = 0,
                Type = "CD"
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddItemBtn(Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();
            return Json(item);
        }
    }
}
