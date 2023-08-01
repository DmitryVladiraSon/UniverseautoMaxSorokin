namespace Universeauto.Models
{
    public interface IOrderLinesRepository
    {
        IEnumerable<OrderLine> GetOrderLines();
    }
}
