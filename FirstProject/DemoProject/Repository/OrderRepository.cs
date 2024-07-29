
using DemoProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DemoProject.Repository
{
    public class OrderRepository : IOrderRepository
    {
        DemoDbContext dbContext = new DemoDbContext();
        public async Task DeleteOrder(int orderId)
        {
            try
            {
                Order ordertodelete = await GetOrderById(orderId);
                dbContext.Orders.Remove(ordertodelete);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Order>> GetAllOrders()
        {
            try
            {
                List<Order> orders = await dbContext.Orders.Include(order => order.User).Include(order => order.Product).ToListAsync();
                return orders;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            try
            {
                Order order = await(from o in dbContext.Orders.Include(order => order.User).Include(order => order.Product) where o.OrderId == orderId select o).FirstAsync();
                return order;
            }
            catch (Exception)
            {
                throw new Exception("Order not Exists");
            }
        }

        public async Task<List<Order>> GetOrderByProduct(int productId)
        {
            try
            {
                List<Order> order = await(from o in dbContext.Orders.Include(order => order.User).Include(order => order.Product) where o.ProductId == productId select o).ToListAsync();
                return order;
            }
            catch (Exception)
            {
                throw new Exception("Product not Exists");
            }
        }

        public async Task<List<Order>> GetOrderByUser(int userId)
        {
            try
            {
                List<Order> order = await(from o in dbContext.Orders.Include(order => order.User).Include(order => order.Product) where o.UserId == userId select o).ToListAsync();
                return order;
            }
            catch (Exception)
            {
                throw new Exception("User Id not Exists");
            }
        }

        public async Task InsertOrder(Order order)
        {
            try
            {
                await dbContext.Orders.AddAsync(order);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       
    }
}
