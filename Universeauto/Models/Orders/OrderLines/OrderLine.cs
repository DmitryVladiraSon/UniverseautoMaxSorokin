using Universeauto.Models.Products;

namespace Universeauto.Models.Orders.OrderLines
{
    public class OrderLine
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public long OrderId { get; set; }

        public Order order { get; set; }
    }
}
