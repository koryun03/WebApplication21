namespace WebApp21.Services.EmailAPI.Models.Dto
{
    public class CartDto //mvc models copy 
    {
        public CartHeaderDto CartHeader { get; set; }
        public IEnumerable<CartDetailsDto>? CartDetails { get; set; }
    }
}
