using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using arz.eda.InputModels;
using arz.eda.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Linq;
using System.Collections.Generic;

namespace arz.eda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Account> _userManager;
        private readonly SignInManager<Account> _signInManager;

        public AccountController(UserManager<Account> userManager, SignInManager<Account> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<IActionResult> Register(RegisterInputModel model)
        {
            Account account = new() {Email = model.Email, UserName = model.Email};
            // добавляем пользователя
            var result = await _userManager.CreateAsync(account, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(account, "user");
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

        [HttpGet]
        [Route(nameof(UserInfo))]
        [Authorize]
        public async Task<IActionResult> UserInfo()
        {
            var user =
            new {
                name = User.FindFirst(ClaimTypes.Name).Value,
                email = User.FindFirst(ClaimTypes.Email).Value
            };
            return Ok(user);
        }

        [HttpGet]
        [Route(nameof(UserInfoFull))]
        [Authorize]
        public async Task<IActionResult> UserInfoFull()
        {
            var name = User.FindFirst(ClaimTypes.Name);
            if (name == null)
                return BadRequest();
            Account user = await _userManager.FindByNameAsync(name.Value);
            return Ok(new { 
                id = user.Id, 
                name = user.UserName, 
                email = user.Email, 
                address = user.Address,
                entrance = user.Entrance, 
                intercom = user.Intercom, 
                floor = user.Floor, 
                flat = user.Flat 
                });
        }

        [HttpPut]
        [Route(nameof(Update))]
        [Authorize]
        public async Task<IActionResult> Update(AccountInputModel model)
        {
            Account user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
                return BadRequest();
            user.UserName = model.Name;
            user.Email = model.Email;
            user.Address = model.Address;
            user.Entrance = model.Entrance;
            user.Intercom = model.Intercom;
            user.Floor = model.Floor;
            user.Flat = model.Flat;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
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
        [Route(nameof(Login))]
        public async Task<IActionResult> Login(LoginInputModel model)
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

        [HttpPost]
        [Route(nameof(Logout))]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
