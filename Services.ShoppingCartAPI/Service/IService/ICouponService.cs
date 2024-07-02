
using WebApp21.Services.ShoppingCartAPI.Models.Dto;

namespace WebApp21.Services.ShoppingCartAPI.Service.IService
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponCode);
    }
}
