using Microsoft.EntityFrameworkCore;

namespace Universeauto.Models
{

    public class OrdersRepository : IOrdersRepository
    {
        private DataContext context;


        public OrdersRepository(DataContext cxt) => context = cxt;
        public IEnumerable<Order> Orders => context.Orders.Include(o => o.Customer)
    .Include(o => o.Lines).ThenInclude(l => l.Product).ToArray();
        public Order GerOrder(long key) => context.Orders
            .Include(o => o.Lines).First(o => o.Id == key);

        public void AddOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }
        public void UpdateOrder(Order order)
        {
            context.Orders.Update(order);
            context.SaveChanges();
        }
        public void DeleteOrder(Order order)
        {
            context.Orders.Remove(order);
            context.SaveChanges();
        }
    }
}
