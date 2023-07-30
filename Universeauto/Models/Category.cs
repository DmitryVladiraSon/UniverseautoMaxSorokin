using System.ComponentModel.DataAnnotations;

namespace Universeauto.Models
{
    public class Category
    {
        public long Id { get; set; }
        [Required(ErrorMessage ="Введите название категории")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Дайте описание категории")]

        public string Description { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
