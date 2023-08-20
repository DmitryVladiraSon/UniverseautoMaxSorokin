using Universeauto.Models.Customers;
using Universeauto.Models.Orders;
using Universeauto.Models.Orders.OrderLines;

namespace Universeauto.ViewModels
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<OrderLine> Lines { get; set; }
    }
}
