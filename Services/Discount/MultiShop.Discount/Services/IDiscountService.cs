using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponsAsync();
        Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id);
        Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto);
        Task DeleteDiscountCouponAsync(int id);
        Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto);
        Task<ResultDiscountCouponDto> GetCodeDetailByCodeAsync(string code);
        Task<int> GetDiscountCouponCount();
    }
}
