using System.ComponentModel.DataAnnotations;
using Universeauto.Models.Customers;
using Universeauto.Models.Orders.OrderLines;

namespace Universeauto.Models.Orders
{
    public class Order
    {
        public long Id { get; set; }
        
        public DateTime DateAdded { get; private set; }

        [Required(ErrorMessage = "Укажите статус заказа")]
        public string Status { get; set; }  // заменить на emun

        [Required(ErrorMessage = "Укажите клиента для заказа")]
        public long CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [Required(ErrorMessage = "Укажите машину для заказа")]
        public string Car { get; set; } // создать отдельный класс

        [Required(ErrorMessage = "Укажите дату начала")]
        public string DateStart { get; set; }

        [Required(ErrorMessage = "Укажите дату окончания")]
        public string DateFinish { get; set; }

        [Required(ErrorMessage = "Укажите финальную цену")]
        public decimal CustomerPrice { get; set; }
        public decimal SalonPrice { get; set; }
        [Required(ErrorMessage = "Укажите хотя бы одну строку заказа")]

        public IEnumerable<OrderLine> Lines { get; set; }

        public Order()
        {
            DateAdded = DateTime.Now;
        }
    }
}
