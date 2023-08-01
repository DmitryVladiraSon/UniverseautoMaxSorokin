namespace Universeauto.Models
{
    public class OrderLinesRepository : IOrderLinesRepository
    {
        private DataContext _context;
        public OrderLinesRepository( DataContext context) {
            _context = context;
        }
        public IEnumerable<OrderLine> GetOrderLines()
                => _context.OrderLines;
        
    }
}
