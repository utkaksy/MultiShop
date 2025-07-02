using MultiShop.DtoLayer.CatalogDtos.BrandDtos;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices
{
    public interface IBrandServices
    {
        Task<List<ResultBrandDto>> GetAllBrandAsync();
        Task<UpdateBrandDto> GetByIdBrandAsync(string id);
        Task DeleteBrandAsync(string id);
        Task CreateBrandAsync(CreateBrandDto createBrandDto);
        Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
    }
}
