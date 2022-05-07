using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using arz.eda.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using arz.eda.InputModels;

namespace arz.eda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private ApplicationContext _db;
        private readonly UserManager<Account> _userManager;

        public OrderController(ApplicationContext context, UserManager<Account> userManager)
        {
            _db = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _db.Orders.AsNoTracking().Include(x => x.Restaurant).Include(x => x.OrderLines).ThenInclude(x => x.Product)
                .Select(x => new {x.Id, x.Date, x.Address, x.RestaurantId, x.Restaurant, x.OrderLines, x.Price}).ToListAsync());
        }

        [HttpGet]
        [Route(nameof(GetByAccount))]
        [Authorize]
        public async Task<IActionResult> GetByAccount()
        {
            var name = User.FindFirst(ClaimTypes.Name);
            if (name == null)
                return NotFound();
            Account user = await _userManager.Users.Include(x => x.Orders).FirstAsync(x => x.UserName == name.Value);
            return Ok(await _db.Orders.AsNoTracking().Include(x => x.Restaurant).Include(x => x.OrderLines).ThenInclude(x => x.Product).Where(x => x.AccountId == user.Id)
                .Select(x => new { x.Id, x.Date, x.Address, x.RestaurantId, x.Restaurant, x.OrderLines, x.Price }).ToListAsync());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateOrder(OrderInputModel model)
        {
            var name = User.FindFirst(ClaimTypes.Name);
            if (name == null)
                return NotFound();
            Account user = await _userManager.FindByNameAsync(name.Value);
            var restaurant = await _db.Restaurants.FirstOrDefaultAsync(x => x.Id == model.RestaurantId);
            if (restaurant == null)
                return NotFound();
            var productIds = model.OrderLines.Select(x => x.ProductID).ToList();
            var products = await _db.Products.Where(x => productIds.Contains(x.Id)).ToListAsync();
            Order order = new()
            {
                Date = model.Date,
                Address = model.Address,
                Entrance = model.Entrance,
                Intercom = model.Intercom,
                Floor = model.Floor,
                Flat = model.Flat,
                Price = model.Price,
                Comment = model.Comment,
                Account = user,
                Restaurant = restaurant,
                OrderLines = model.OrderLines.Select(x => new OrderLine { 
                    Price = x.Price, 
                    Quantity = x.Quantity, 
                    Product = products.First(p => x.ProductID == p.Id) 
                }).ToList(),
            };
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();
            return Ok(order.Id);
        }
    }
}
