using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.ViewComponents.ShoppingCartViewComponent
{
    public class _ShoppingCartProductListComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;

        public _ShoppingCartProductListComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _basketService.GetBasket();
            return View(values);
        }
    }
}
