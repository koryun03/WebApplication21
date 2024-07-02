using AutoMapper;
using WebApp21.MessageBus.Common;
using WebApp21.Services.EmailAPI.Models.Dto;

namespace WebApp21.Services.EmailAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CartDto, ShoppingCartMessaging>().ReverseMap();
                config.CreateMap<CartHeaderDto, ShoppingCartHeaderMessaging>().ReverseMap();
                config.CreateMap<CartDetailsDto, ShoppingCartDetailsMessaging>().ReverseMap();
                config.CreateMap<ProductDto, ProductMessaging>().ReverseMap();

            });

            return mappingConfig;
        }
    }
}
