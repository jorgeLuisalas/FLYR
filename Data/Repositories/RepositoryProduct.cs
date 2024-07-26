namespace SupermarketCheckout.Data.Repositories
{
    using System.Collections.Generic;
    using SupermarketCheckout.Model.Models;

    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
    }

    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Code = "GR1", Name = "Green tea", Price = 3.11M },
                new Product { Code = "SR1", Name = "Strawberries", Price = 5.00M },
                new Product { Code = "CF1", Name = "Coffee", Price = 11.23M }
            };
        }
    }
}