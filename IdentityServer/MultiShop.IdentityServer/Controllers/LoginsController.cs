using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using MultiShop.IdentityServer.Tools;
using System.Threading.Tasks;

namespace MultiShop.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signManager;
        private readonly UserManager<ApplicationUser> _usermanager;

        public LoginsController(SignInManager<ApplicationUser> signManager, UserManager<ApplicationUser> usermanager)
        {
            _signManager = signManager;
            _usermanager = usermanager;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
        {
            var result = await _signManager.PasswordSignInAsync(userLoginDto.Username, userLoginDto.Password, false, false);
            var user = await _usermanager.FindByNameAsync(userLoginDto.Username);

            if (result.Succeeded)
            {
                GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
                model.Username = userLoginDto.Username;
                model.Id = user.Id;
                var token = JwtTokenGenerator.GenerateToken(model);
                return Ok(token);
            }
            return Ok("kullanıcı Adı veya Şifre Hatalı");
        }
    }
}
