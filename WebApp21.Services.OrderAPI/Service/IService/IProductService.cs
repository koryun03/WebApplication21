using WebApp21.Services.OrderAPI.Models.Dto;

namespace WebApp21.Services.OrderAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
