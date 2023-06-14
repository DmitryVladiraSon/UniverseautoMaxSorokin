namespace Universeauto.Models
{
    public interface IOrdersRepository
    {
        IEnumerable<Order> Orders { get; }

        Order GerOrder(long key);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}

