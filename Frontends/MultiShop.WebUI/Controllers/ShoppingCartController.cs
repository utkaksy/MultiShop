using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public ShoppingCartController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index(string code,int rate)
        {
            ViewBag.code = code;
            ViewBag.rate = rate;
            var values = await _basketService.GetBasket();
            ViewBag.total = values.TotalPrice;
            var totalPriceWithTax = values.TotalPrice+values.TotalPrice * 1 / 10;
            ViewBag.totalPriceWithTax = totalPriceWithTax;
            var tax = values.TotalPrice * 1 / 10;
            ViewBag.tax = tax;
            ViewBag.totalPriceWithDiscount = totalPriceWithTax - totalPriceWithTax * rate / 100;
            return View();
        }

        public async Task<IActionResult> AddItem(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            var item = new BasketItemDto
            {
                Price = values.ProductPrice,
                ProductID = values.ProductId,
                ProductName = values.ProductName,
                Quantity = 1,
                ProductImageUrl = values.ProductImageUrl
            };
            await _basketService.AddBasketItem(item);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> RemoveItem(string id)
        {
            await _basketService.DeleteBasketItem(id);
            return RedirectToAction("Index");
        }
    }
}
