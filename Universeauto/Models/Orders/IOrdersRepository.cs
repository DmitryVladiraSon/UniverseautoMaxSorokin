namespace Universeauto.Models.Orders
{
    public interface IOrdersRepository : IRepository<Order>
    {
        IEnumerable<Order> Orders { get; }

        Order GetOrder(long key);

        void AddOrderLine(Order order);
    }
}

