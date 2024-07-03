namespace WebApp21.MessageBus.Common
{
    public class CartAfterOrderMessaging
    {
        public string? UserId { get; set; }
        public int CartDetailsId { get; set; }
        public int CartHeaderId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}
