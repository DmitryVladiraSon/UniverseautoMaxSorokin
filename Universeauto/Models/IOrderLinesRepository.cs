namespace Universeauto.Models
{
    public interface IOrderLinesRepository
    {
        IEnumerable<OrderLine> GetOrderLines();
        IEnumerable<OrderLine> GetOrderLinesByOrder(Order order);

       
    }
}
