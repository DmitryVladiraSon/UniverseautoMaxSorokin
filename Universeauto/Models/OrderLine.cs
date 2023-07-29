namespace Universeauto.Models
{
    public class OrderLine
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal? PriceCustomer { get; set; }
        //public string? Employee { get; set; }
        public decimal? PriceEmployee { get; set; }
        public long OrderId { get; set; }

        public Order order { get; set; }
    }
}
