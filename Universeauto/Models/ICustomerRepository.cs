namespace Universeauto.Models
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> Customers { get; }

        Customer GetCustomer(long key);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
    }
}
