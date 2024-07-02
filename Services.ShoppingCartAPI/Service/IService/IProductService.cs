
using WebApp21.Services.ShoppingCartAPI.Models.Dto;

namespace WebApp21.Services.ShoppingCartAPI.Service.IService

{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
