using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task<UpdateCategoryDto> GetByIdCategoryAsync(string id);
        Task DeleteCategoryAsync(string id);
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
    }
}
