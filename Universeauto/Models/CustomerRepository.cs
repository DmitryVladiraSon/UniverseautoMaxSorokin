using Microsoft.EntityFrameworkCore;

namespace Universeauto.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private DataContext context;

        public CustomerRepository(DataContext ctx) =>  context = ctx;

        public IEnumerable<Customer> Customers => context.Customers
            .Include(c => c.Cars).ToArray();


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
