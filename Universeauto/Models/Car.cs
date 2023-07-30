using System.ComponentModel.DataAnnotations;

namespace Universeauto.Models
{
    public class Car
    {
        public long Id { get; set; }

        [Required(ErrorMessage ="Введите навание")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Введите гос. номер")]
        public string GovNomber { get; set; }

        public string ClassAuto { get; set; }

        public long? CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
