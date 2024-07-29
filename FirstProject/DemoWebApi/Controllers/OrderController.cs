using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DemoProject.Model;
using DemoProject.Repository;

namespace DemoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderRepository repository;
        public OrderController(IOrderRepository orderRepo)
        {
            repository = orderRepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllOrderDetails()
        {
            List<Order> orders = await repository.GetAllOrders();
            return Ok(orders);
        }
        [HttpGet("ByOrderId/{orderId}")]
        public async Task<ActionResult> GetOne(int orderId)
        {
            try
            {
                Order order = await repository.GetOrderById(orderId);
                return Ok(order);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("ByUserId/{userId}")]
        public async Task<ActionResult> GetByUser(int userId)
        {
            try
            {
                List<Order> order = await repository.GetOrderByUser(userId);
                return Ok(order);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("ByProductId/{productId}")]
        public async Task<ActionResult> GetByProduct(int productId)
        {
            try
            {
                List<Order> order = await repository.GetOrderByProduct(productId);
                return Ok(order);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Insert(Order order)
        {
            try
            {
                await repository.InsertOrder(order);
                return Created($"api/Order/{order.OrderId}", order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpDelete("{orderId}")]
        public async Task<ActionResult> Delete(int orderId)
        {
            try
            {
                await repository.DeleteOrder(orderId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
