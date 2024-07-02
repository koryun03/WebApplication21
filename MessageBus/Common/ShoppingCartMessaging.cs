namespace WebApp21.MessageBus.Common
{
    public class ShoppingCartMessaging
    {
        public ShoppingCartHeaderMessaging CartHeader { get; set; }
        public IEnumerable<ShoppingCartDetailsMessaging>? CartDetails { get; set; }
    }
    public class ShoppingCartHeaderMessaging
    {
        public int CartHeaderId { get; set; }
        public string? UserId { get; set; }
        public string? CouponCode { get; set; }
        public double Discount { get; set; }
        public double CartTotal { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
    public class ShoppingCartDetailsMessaging
    {
        public int CartDetailsId { get; set; }
        public int CartHeaderId { get; set; }
        public ShoppingCartHeaderMessaging? CartHeader { get; set; }
        public int ProductId { get; set; }
        public ProductMessaging? Product { get; set; }
        public int Count { get; set; }
    }
    public class ProductMessaging
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
