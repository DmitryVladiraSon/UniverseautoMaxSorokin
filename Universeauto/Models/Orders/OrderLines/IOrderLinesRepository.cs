namespace Universeauto.Models.Orders.OrderLines
{
    public interface IOrderLinesRepository
    {
        IEnumerable<OrderLine> GetOrderLines();
        IEnumerable<OrderLine> GetOrderLinesByOrder(Order order);


    }
}
