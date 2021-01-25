using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using arz.eda.Models;
using Microsoft.EntityFrameworkCore;

namespace arz.eda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private ApplicationContext _db;

        public OrderController(ApplicationContext context)
        {
            _db = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _db.Orders.AsNoTracking().Include(x => x.Restaurant).Include(x => x.OrderLines).ThenInclude(x => x.Product)
                .Select(x => new {x.Id, x.Date, x.Address, x.RestaurantId, x.Restaurant, x.OrderLines, x.Price}).ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();
            return Ok(order.Id);
        }
    }
}
