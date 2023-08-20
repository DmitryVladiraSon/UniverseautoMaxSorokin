namespace Universeauto.Models.Customers
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> Customers { get; }

        Customer GetCustomer(long key);

        List<Customer> SearchCustomersByName(string searchQuery);
    }
}
