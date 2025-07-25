﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderSummaryComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;

        public _OrderSummaryComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basketTotal = await _basketService.GetBasket();
            return View(basketTotal);
        }
    }
}
