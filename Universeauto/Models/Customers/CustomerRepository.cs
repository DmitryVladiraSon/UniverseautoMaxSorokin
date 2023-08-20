using Microsoft.EntityFrameworkCore;

namespace Universeauto.Models.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private DataContext context;
        private List<Customer> customers = new List<Customer>();
        public CustomerRepository(DataContext ctx) => context = ctx;

        public IEnumerable<Customer> Customers => context.Customers
            .Include(c => c.Cars).ToArray();

        public List<Customer> SearchCustomersByName(string searchQuery)
        {
            if (string.IsNullOrEmpty(searchQuery))
            {
                return customers; // Если поисковый запрос пустой, вернуть все записи
            }

            // Выполнить поиск клиентов, у которых имя содержит заданный поисковый запрос
            var searchResults = customers.Where(c => c.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();

            return searchResults;
        }

        public void AddCustomer(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
        }

        public Customer GetCustomer(long key) => context.Customers
            .Include(c => c.Cars).First(c => c.Id == key);

        public void UpdateCustomer(Customer customer)
        {
            context.Customers.Update(customer);
            context.SaveChanges();
        }
    }
}
