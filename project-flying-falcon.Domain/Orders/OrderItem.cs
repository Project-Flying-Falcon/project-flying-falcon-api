using System.Net.ServerSentEvents;
using Flying.Falcon.Domain.Catalog;

namespace Flying.Falcon.Domain.Orders
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal Price => Item.Price * Quantity;
    }
}