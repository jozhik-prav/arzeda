using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using arz.eda.Models;
using Microsoft.EntityFrameworkCore;
using arz.eda.InputModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace arz.eda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : Controller
    {
        private ApplicationContext _db;
        private readonly UserManager<Account> _userManager;

        public RestaurantController(ApplicationContext context, UserManager<Account> userManager)
        {
            _db = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(Guid? categoryId = null)
        {
            if (categoryId == null)
                return Ok(await _db.Restaurants.Include(x => x.Categories).Include(x => x.Products).Select(x =>
                    new
                    {
                        x.Id, x.Name, x.Description, x.Address, x.Image, x.Categories, x.Products,
                        x.TimeWorkStart,
                        x.TimeWorkEnd,
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
                    x.Id, x.Name, x.Description, x.Address, x.Image, x.Categories, x.Products, x.TimeWorkStart, x.TimeWorkEnd,
                    x.DeliveryPrice, x.MinSum
                }).FirstOrDefaultAsync(x => x.Id == id));
        }

        [HttpPost]
        [Authorize(Roles = "manager")]
        public async Task<IActionResult> CreateRestaurant(RestaurantInputModel model)
        {
            var name = User.FindFirst(ClaimTypes.Name);
            if (name == null)
                return BadRequest();
            Account user = await _userManager.FindByNameAsync(name.Value);
            var categoriesIds = model.Categories;
            var categories = await _db.Categories.Where(x => categoriesIds.Contains(x.Id)).ToListAsync();
            Restaurant restaurant = new()
            {
                Name = model.Name,
                Description = model.Description,
                Image = model.Image,
                Address = model.Address,
                DeliveryPrice = model.DeliveryPrice,
                MinSum = model.MinSum,
                TimeWorkStart = model.TimeWorkStart,
                TimeWorkEnd = model.TimeWorkEnd,
                Products = new List<Product>(),
                Categories = categories
            };
            _db.Restaurants.Add(restaurant);
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            user.Restaurant = restaurant;
            await _userManager.UpdateAsync(user);
            return Ok(restaurant.Id);
        }

        [HttpPut]
        [Authorize(Roles = "manager")]
        [Route("{restaurantId}")]
        public async Task<IActionResult> Update(Guid restaurantId, RestaurantInputModel model)
        {
            var restaurant = await _db.Restaurants.Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id == restaurantId);
            if (restaurant == null)
                return NotFound();
            var categoriesIds = model.Categories;
            var categories = await _db.Categories.Where(x => categoriesIds.Contains(x.Id)).ToListAsync();
            restaurant.Name = model.Name;
            restaurant.Description = model.Description;
            restaurant.Address = model.Address;
            restaurant.TimeWorkStart = model.TimeWorkStart;
            restaurant.TimeWorkEnd = model.TimeWorkEnd;
            restaurant.DeliveryPrice = model.DeliveryPrice;
            restaurant.MinSum = model.MinSum;
            restaurant.Image = model.Image;
            restaurant.Categories.Clear();
            restaurant.Categories.AddRange(categories);
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

        [HttpGet]
        [Route("{restaurantId}/products")]
        public async Task<IActionResult> GetProductsByRestaurant(Guid restaurantId)
        {
            var resraurant = await _db.Restaurants.AsNoTracking().Include(x => x.Products)
                .Select(x => new
                {
                    x.Id,
                    x.Products,
                }).FirstOrDefaultAsync(x => x.Id == restaurantId);
           if (resraurant == null)
                return NotFound();
           return Ok(resraurant.Products.Select(x => new
           {
               x.Id, x.Name, x.Description, x.Image, x.Price
           }).ToList());
        }

        [HttpPost]
        [Authorize(Roles = "manager")]
        [Route("{restaurantId}/product")]
        public async Task<IActionResult> AddProduct(Guid restaurantId, ProductInputModel model)
        {
            var restaurant = await _db.Restaurants.FirstOrDefaultAsync(x => x.Id == restaurantId);
            if(restaurant == null)
                return NotFound();
            Product product = new()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Image = model.Image,
                Restaurant = restaurant,
            };
            product.RestaurantId = restaurantId;
            _db.Products.Add(product);
            try
            {
                await _db.SaveChangesAsync();
                return Ok(product.Id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Authorize(Roles = "manager")]
        [Route("{id}/product")]
        public async Task<IActionResult> UpdateProduct(Guid id, ProductInputModel model)
        {
            var product = _db.Products.FirstOrDefault(x => x.Id == id);
            if(product == null)
                return NotFound();
            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Image = model.Image;
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

        [HttpDelete]
        [Authorize(Roles = "manager")]
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
