using System.ComponentModel.DataAnnotations;

namespace Universeauto.Models
{
    public class Product
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите нававние")]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите цену покупки")]
        public decimal PurchasePrice { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите цену продажи")]
        public decimal RetailPrice { get; set; }


        [Required(ErrorMessage = "Пожалуйста, введите катекгорию товара")]
        public long? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
