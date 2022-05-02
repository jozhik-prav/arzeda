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
    public class CategoryController : Controller
    {
        private ApplicationContext _db;

        public CategoryController(ApplicationContext context)
        {
            _db = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _db.Categories.Select(x => new
            {
                x.Id, x.Name
            }).ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _db.Categories.Select(x => new
            {
                x.Id,
                x.Name
            }).FirstOrDefaultAsync(x => x.Id == id));
        }

        [HttpPost]
        [Route("{name}")]
        public async Task<IActionResult> CreateCategory(string name)
        {
            Category category = new () { Name = name };
            _db.Categories.Add(category);
            try
            {
                await _db.SaveChangesAsync();
                return Ok(category.Id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            _db.Categories.Remove(new Category() { Id = id });
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
