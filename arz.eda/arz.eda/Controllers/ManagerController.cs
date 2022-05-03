using arz.eda.InputModels;
using arz.eda.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace arz.eda.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "manager")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private ApplicationContext _db;
        private readonly UserManager<Account> _userManager;
        private readonly SignInManager<Account> _signInManager;

        public ManagerController(ApplicationContext context, UserManager<Account> userManager, SignInManager<Account> signInManager)
        {
            _db = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost]
        [Route(nameof(Login))]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            Account account = await _userManager.FindByEmailAsync(model.Email);
            if (account != null)
            {
                var accountRoles = await _userManager.GetRolesAsync(account);
                if (accountRoles.Contains("manager"))
                {
                    var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Ok();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                        return UnprocessableEntity(ModelState);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Вы не менеджер");
                    return UnprocessableEntity(ModelState);
                }
            }
            ModelState.AddModelError("", "Такого пользователя не существует");
            return UnprocessableEntity(ModelState);
        }

        [HttpGet]
        [Route(nameof(RestaurantInfo))]
        public async Task<IActionResult> RestaurantInfo()
        {
            var name = User.FindFirst(ClaimTypes.Name);
            if (name == null)
                return BadRequest();
            Account user = await _userManager.FindByNameAsync(name.Value);
            if (user.RestaurantId != null)
            {
                var restaurant = await _db.Restaurants.AsNoTracking()
                    .Select(x => new {
                        x.Id,
                        x.Name,
                        x.Description,
                        x.Address,
                        x.Image,
                        Categories = x.Categories.Select(x => x.Id),
                        x.Products,
                        x.TimeWorkStart,
                        x.TimeWorkEnd,
                        x.DeliveryPrice,
                        x.MinSum
                    })
                    .FirstAsync(x => x.Id == user.RestaurantId);
                return Ok(restaurant);
            }
            return NoContent();
        }

        [HttpPost]
        [Route(nameof(Logout))]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
