using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.OrderDtos;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Services.OrderServices.OrderAddressServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderAddressService _orderAddressService;
        private readonly IUserService _userService;

        public OrderController(IOrderAddressService orderAddressService, IUserService userService)
        {
            _orderAddressService = orderAddressService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index(int rate)
        {
            ViewBag.directory1 = "MultiShop";
            ViewBag.directory2 = "Sipariş";
            ViewBag.directory3 = "Sipraiş Ver";
            ViewBag.rate = rate;
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateOrderAddressDto createOrderAddressDto)
        {
            var userInfo = await _userService.GetUserInfo();
            createOrderAddressDto.UserId = userInfo.Id;
            createOrderAddressDto.Description = "aa";

            await _orderAddressService.CreateOrderAddressAsync(createOrderAddressDto);

            return RedirectToAction("Index", "Payment");
        }
    }
}
