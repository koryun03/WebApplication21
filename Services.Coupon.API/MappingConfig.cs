using AutoMapper;
using WebApp21.Services.CouponAPI.Models;
using WebApp21.Services.CouponAPI.Models.Dto;

namespace WebApp21.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
