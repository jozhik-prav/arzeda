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
    public class RestaurantController : Controller
    {
        private ApplicationContext _db;

        public RestaurantController(ApplicationContext context)
        {
            _db = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(Guid? categoryId = null)
        {
            if (categoryId == null)
                return Ok(await _db.Restaurants.Include(x => x.Categories).Include(x => x.Products).Select(x =>
                    new
                    {
                        x.Id, x.Name, x.Description, x.Address, x.Image, x.Categories, x.Products, x.TimeWork,
                        x.DeliveryPrice, x.MinSum
                    }).ToListAsync());

            return Ok(await _db.Restaurants.Include(x => x.Categories).Include(x => x.Products)
                .Where(x => x.Categories.Any(c => c.Id == categoryId)).ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _db.Restaurants.Include(x => x.Categories).Include(x => x.Products)
                .Select(x => new
                {
                    x.Id, x.Name, x.Description, x.Address, x.Image, x.Categories, x.Products, x.TimeWork,
                    x.DeliveryPrice, x.MinSum
                }).FirstOrDefaultAsync(x => x.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant(Restaurant restaurant)
        {
            var categoriesIds = restaurant.Categories.Select(x => x.Id).ToList();
            var categories = await _db.Categories.Where(x => categoriesIds.Contains(x.Id)).ToListAsync();
            restaurant.Categories = restaurant.Categories.Select(x =>
                categories.Any(c => c.Id == x.Id) ? categories.FirstOrDefault(c => c.Id == x.Id) : x).ToList();
            _db.Restaurants.Add(restaurant);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRestaurant(Guid id)
        {
            _db.Restaurants.Remove(new Restaurant {Id = id});
            try
            {
                await _db.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("{restaurantId}/product")]
        public async Task<IActionResult> AddProduct(Guid restaurantId, Product product)
        {
            product.RestaurantId = restaurantId;
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("{id}/product")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            _db.Products.Remove(new Product() { Id = id });
            try
            {
                await _db.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("{categoryId}/{restaurantId}/category")]
        public async Task<IActionResult> AddCategory(Guid categoryId, Guid restaurantId)
        {
            var category = await _db.Categories.FindAsync(categoryId);
            var restaurant = await _db.Restaurants.FindAsync(restaurantId);
            restaurant.Categories.Add(category);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("{categoryId}/{restaurantId}/category")]
        public async Task<IActionResult> DeleteCategory(Guid categoryId, Guid restaurantId)
        {
            var category = await _db.Categories.FindAsync(categoryId);
            var restaurant = await _db.Restaurants.FindAsync(restaurantId);
            restaurant.Categories.Remove(category);
            try
            {
                await _db.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
        }
    }
}
