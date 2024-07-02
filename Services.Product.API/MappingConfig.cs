using AutoMapper;
using WebApp21.Services.ProductAPI.Models;
using WebApp21.Services.ProductAPI.Models.Dto;

namespace WebApp21.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
