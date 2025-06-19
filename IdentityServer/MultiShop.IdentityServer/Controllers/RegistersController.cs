using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using static Duende.IdentityServer.IdentityServerConstants;

namespace MultiShop.IdentityServer.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _usermanager;

        public RegistersController(UserManager<ApplicationUser> usermanager)
        {
            _usermanager = usermanager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
        {
            var value = new ApplicationUser()
            {
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.Email,
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname
            };
            var result = await _usermanager.CreateAsync(value, userRegisterDto.Password);
            if (result.Succeeded)
            {
                return Ok("Kullanıcı Başarıyla Eklendi");
            }
            else
            {
                return Ok("Bir Hata Oluştu Tekrar Deneyiniz");
            }
        }
    }
}
