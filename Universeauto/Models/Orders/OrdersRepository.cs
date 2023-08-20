using Microsoft.EntityFrameworkCore;

namespace Universeauto.Models.Orders
{

    public class OrdersRepository : Repository<Order>, IOrdersRepository
    {
        private DataContext context;


        public OrdersRepository(DataContext cxt) : base(cxt) => context = cxt;
        public IEnumerable<Order> Orders => context.Orders.Include(o => o.Customer)
    .Include(o => o.Lines).ThenInclude(l => l.Product).ToArray();
        public Order GetOrder(long key) => context.Orders
            .Include(o => o.Customer)
            .Include(o => o.Lines)
            .ThenInclude(l => l.Product)
            .First(o => o.Id == key);
    

        public void AddOrderLine(Order order) // Скорее всего его нужно сделать асинхронным)
        {
            context.Orders.Update(order);

            context.SaveChanges();
        }
    }
}
