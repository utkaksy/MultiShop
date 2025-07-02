using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _VendorDefaultComponentPartial : ViewComponent
    {
        private readonly IBrandServices _brandServices;

        public _VendorDefaultComponentPartial(IBrandServices brandServices)
        {
            _brandServices = brandServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _brandServices.GetAllBrandAsync();
            return View(values);
        }
    }
}
