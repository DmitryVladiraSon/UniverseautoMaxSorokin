using Universeauto.Models.Pages;

namespace Universeauto.Models.Products
{
    public interface IRroductRepository : IRepository<Product>
    {
        IEnumerable<Product> Products { get; }
        PagedList<Product> GetProducts(QueryOptions options);
        Product GetProduct(long key);
        void UpdateAll(Product[] products);

    }
}
