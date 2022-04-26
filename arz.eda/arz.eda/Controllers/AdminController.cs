using arz.eda.InputModels;
using arz.eda.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace arz.eda.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<Account> _userManager;
        private readonly SignInManager<Account> _signInManager;

        public AdminController(UserManager<Account> userManager, SignInManager<Account> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route(nameof(Login))]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            Account account = await _userManager.FindByEmailAsync(model.Email);
            if (account != null) {
                var accountRoles = await _userManager.GetRolesAsync(account);
                if (accountRoles.Contains("Admin")) { 
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
                } else
                {
                    ModelState.AddModelError("", "Вы не администратор");
                    return UnprocessableEntity(ModelState);
                }
            }
            ModelState.AddModelError("", "Такого пользователя не существует");
            return UnprocessableEntity(ModelState);
        }

        [HttpPost]
        [Route(nameof(Logout))]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpPost]
        [Route(nameof(CreateManger))]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateManger(RegisterInputModel model)
        {
            Account account = new() { Email = model.Email, UserName = model.Email };
            var result = await _userManager.CreateAsync(account, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(account, "manager");
                // установка куки
                await _signInManager.SignInAsync(account, false);
                return Ok();
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return UnprocessableEntity(ModelState);
            }
        }

        [HttpPost]
        [Route(nameof(Users))]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Users()
        {
            var users = _userManager.Users.ToList();
            var rolesTasks = users.Select(x => _userManager.GetRolesAsync(x));
            var roles = await Task.WhenAll(rolesTasks);
            var oneRoles = roles.Select(x => x.FirstOrDefault());
            var result = users.Zip(oneRoles).Select(x => new
            {
                name = x.First.Name,
                email = x.First.Email,
                role = x.Second
            }).ToList();

            return Ok(result);
        }
    }
}
