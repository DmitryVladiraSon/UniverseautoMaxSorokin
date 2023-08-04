﻿using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Universeauto.Models.Pages;

namespace Universeauto.Models
{
    public class DataRepository : IRepository
    {
        private DataContext context;
        public DataRepository(DataContext dataContext) => context = dataContext;
        public IEnumerable<Product> Products => context.Products
            .Include(p => p.Category).ToArray();

        public PagedList<Product> GetProducts(QueryOptions options)
        {
            return new PagedList<Product>(context.Products.Include(p => p.Category), options);
        }

        public Product GetProduct(long key) => context.Products
            .Include(p => p.Category).First(p => p.Id == key);

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }
        public void UpdateProduct(Product product)
        {
            Product p = context.Products.Find(product.Id);
            p.Name = product.Name;
            //p.Category = product.Category;
            p.CategoryId = product.CategoryId;
            p.PurchasePrice = product.PurchasePrice;
            p.RetailPrice = product.RetailPrice;

            //context.Products.Update(product);
            context.SaveChanges();
        }

        public void UpdateAll(Product[] products)
        {
            //context.Products.UpdateRange(products);
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

        public void Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }


    }
}
