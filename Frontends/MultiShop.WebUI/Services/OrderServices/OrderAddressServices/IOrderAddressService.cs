using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderAddressServices
{
    public interface IOrderAddressService
    {
        //Task<List<ResultAboutDto>> GetAllAboutAsync();
        //Task<UpdateAboutDto> GetByIdAboutAsync(string id);
        //Task DeleteAboutAsync(string id);
        Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto);
        //Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
    }
}
