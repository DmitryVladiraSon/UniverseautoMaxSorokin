using Microsoft.EntityFrameworkCore;

namespace Universeauto.Models.Orders.OrderLines
{
    public class OrderLinesRepository : IOrderLinesRepository
    {
        private DataContext _context;
        public OrderLinesRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<OrderLine> GetOrderLines()
                => _context.OrderLines.Include(ol => ol.Product)
            .Include(ol => ol.order);

        public IEnumerable<OrderLine> GetOrderLinesByOrder(Order order)
        {
            return _context.OrderLines.Include(ol => ol.Product)
            .Include(ol => ol.order)
            .Where(l => l.OrderId == order.Id);
        }
    }
}
