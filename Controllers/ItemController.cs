using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.Repository;
using System.Collections.Generic;
using System.Linq;

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
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Type = item.Type,
                    ImgSrc = item.ImgSrc,
                });
            }
            return View(viewModel);
        }
        public IActionResult AddItem()
        {
            
            if (!HttpContext.Request.Cookies.TryGetValue("Email", out string Email))
            {
                return RedirectToAction("Index", "Account");
            }
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
            HttpContext.Request.Cookies.TryGetValue("Email", out string Email);
            item.OwnerEmail = Email;
            db.Items.Add(item);
            db.SaveChanges();
            return Json(item);
        }
        [HttpPost]
        public IActionResult AddOrderBtn(Order order)
        {
            if(!HttpContext.Request.Cookies.TryGetValue("Email", out string Email))
            {
                return RedirectToAction("Index", "Account");
            }
            order.BuyerEmail = Email;
            Order? oldOrder = db.Orders.FirstOrDefault(x => x.ItemId == order.ItemId && x.BuyerEmail == Email);
            if (oldOrder != null) //已經有重複訂單，同一買家買同個商品
            {
                oldOrder.Count++;
                db.Orders.Update(oldOrder);
            }
            else
            {
                db.Orders.Add(order);
            }
            db.SaveChanges();
            return Json(order);
        }
        public IActionResult Order()
        {
            HttpContext.Request.Cookies.TryGetValue("Email", out string Email);
            var viewModel = new OrderViewModel { Items = new List<ItemViewModel>(), ReceivedItems = new List<ItemViewModel>() };
            List<Order> orders = db.Orders.ToList().Where(x => x.BuyerEmail == Email).ToList();
            foreach (var order in orders)
            {
                Item item = db.Items.Find(order.ItemId);
                viewModel.Items.Add(new ItemViewModel 
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Type = item.Type,
                    ImgSrc = item.ImgSrc,
                    Count = order.Count
                });
            }
            List<int> ItemIdList = db.Items.ToList().Where(x => x.OwnerEmail == Email).Select(x => x.Id).ToList();
            orders = db.Orders.ToList().Where(x => ItemIdList.Contains(x.ItemId)).ToList(); // Receive
            foreach (var order in orders)
            {
                Item item = db.Items.Find(order.ItemId);
                string buyerName = db.Accounts.Find(order.BuyerEmail).NickName;
                viewModel.ReceivedItems.Add(new ItemViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Type = item.Type,
                    ImgSrc = item.ImgSrc,
                    BuyerName = buyerName,
                    Count = order.Count
                });
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult deleteOrderBtn(int itemId)
        {
            HttpContext.Request.Cookies.TryGetValue("Email", out string Email);
            Order order = db.Orders.FirstOrDefault(x => x.ItemId == itemId && x.BuyerEmail == Email);
            db.Orders.Remove(order);
            db.SaveChanges();
            return Json(order);
        }
    }
}
