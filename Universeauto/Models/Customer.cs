using System.ComponentModel.DataAnnotations;

namespace Universeauto.Models
{
    public class Customer
    {
        public long Id { get; set; }
        
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите телефон")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Введите Email")]
        [EmailAddress]
        public string Email { get; set; }

     public ICollection<Car>? Cars { get; set; }

    }
}
