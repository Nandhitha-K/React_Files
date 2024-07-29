    using DemoProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Repository
{
    public class ProductRepository : IProductRepository
    {
        DemoDbContext dbContext = new DemoDbContext();
        public async Task DeleteProduct(int productId)
        {
            try
            {
                Product deleteproduct = await GetProductById(productId);
                dbContext.Products.Remove(deleteproduct);
                await dbContext.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("No Product is available..");
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                List<Product> product = await dbContext.Products.ToListAsync<Product>();
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> GetByName(string productName)
        {
            try
            {
                Product product = await(from u in dbContext.Products where u.Name == productName select u).FirstAsync();
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception("Product Name not Exists"); 
            }
        }

        public async Task<Product> GetProductById(int productId)
        {
            try
            {

                Product product= await(from u in dbContext.Products where u.ProductId == productId select u).FirstAsync();
                return product;
            }
            catch
            {
                throw new Exception("Product Id not Exists");
            }
        }

        public async Task InsertProduct(Product product)
        {
            try
            {
                await dbContext.Products.AddAsync(product);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateProduct(int productId, Product product)
        {
            try
            {
                Product update = await GetProductById(productId);
                update.Name = product.Name;
                update.Description = product.Description;
                update.Price = product.Price;
                update.ImageUrl= product.ImageUrl;
                await dbContext.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Invalid Product Id to update");
            }
        }
    }
}
