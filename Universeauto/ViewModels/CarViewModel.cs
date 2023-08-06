using Universeauto.Models;
using Universeauto.Models.Pages;

namespace Universeauto.ViewModels
{
    public class CarViewModel : PagedViewModel<Car>
    {
        public IEnumerable<Customer> Customers { get; set; }
        public IQueryable<Car> Cars { get; set; }
    }
}
