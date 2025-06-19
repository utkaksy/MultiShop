using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using System.Threading.Tasks;

namespace MultiShop.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signManager;

        public LoginsController(SignInManager<ApplicationUser> signManager)
        {
            _signManager = signManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
        {
            var result = await _signManager.PasswordSignInAsync(userLoginDto.Username, userLoginDto.Password, false, false);
            if (result.Succeeded)
            {
                return Ok("Giriş Başarılı");
            }
            return Ok("kullanıcı Adı veya Şifre Hatalı");
        }
    }
}
