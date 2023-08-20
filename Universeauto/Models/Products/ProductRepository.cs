using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Universeauto.Models.Pages;

namespace Universeauto.Models.Products
{
    public class ProductRepository : Repository<Product>, IRroductRepository
    {
        private DataContext context;
		public ProductRepository(DataContext dbContext) : base(dbContext)
		{
            context = dbContext;
		}
		public IEnumerable<Product> Products => context.Products
            .Include(p => p.Category).ToArray();

        public PagedList<Product> GetProducts(QueryOptions options)
        {
            return new PagedList<Product>(context.Products.Include(p => p.Category), options);
        }

        public Product GetProduct(long key) => context.Products
            .Include(p => p.Category).First(p => p.Id == key);

        public void UpdateAll(Product[] products)
        {
            Dictionary<long, Product> data = products.ToDictionary(p => p.Id);
            IEnumerable<Product> baseline =
                context.Products.Where(p => data.Keys.Contains(p.Id));

            foreach (Product databaseProduct in baseline)
            {
                Product requestProduct = data[databaseProduct.Id];
                databaseProduct.Name = requestProduct.Name;
                databaseProduct.Category = requestProduct.Category;
                databaseProduct.PurchasePrice = requestProduct.PurchasePrice;
                databaseProduct.RetailPrice = requestProduct.RetailPrice;
            }

            context.SaveChanges();
        }
    }
}
