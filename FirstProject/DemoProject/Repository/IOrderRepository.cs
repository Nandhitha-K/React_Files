using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoProject.Model;


namespace DemoProject.Repository
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrderById(int orderId);
        Task<List<Order>> GetOrderByUser(int userId);
        Task<List<Order>> GetOrderByProduct(int productId);
        Task InsertOrder(Order order);
        Task DeleteOrder(int orderId);
    }
}
