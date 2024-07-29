using DemoProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int productId);
        Task<Product> GetByName(string productName);
        Task InsertProduct(Product product);
        Task UpdateProduct(int productId, Product product);
        Task DeleteProduct(int productId);
    }
}
