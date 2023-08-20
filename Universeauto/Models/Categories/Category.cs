using System.ComponentModel.DataAnnotations;
using Universeauto.Models.Products;

namespace Universeauto.Models.Categories
{
    public class Category
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Введите название категории")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Дайте описание категории")]

        public string Description { get; set; }

        public IEnumerable<Product>? Products { get; set; } //
    }
}
