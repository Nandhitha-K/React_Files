using DemoProject.Model;
using DemoProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DemoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductRepository repository;
        public ProductController(IProductRepository productRepository)
        {
            repository= productRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Product> products = await repository.GetAllProducts();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> Insert(Product product)
        {
            try
            {
                await repository.InsertProduct(product);

                return Created($"api/Task/{product.ProductId}",product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPut("{productid}")]
        public async Task<ActionResult> Update(int productid,Product product)
        {
            try
            {
                await repository.UpdateProduct(productid,product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{productid}")]
        public async Task<ActionResult> Delete(int productid)
        {
            try
            {
                await repository.DeleteProduct(productid);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{productid}")]
        public async Task<ActionResult> GetOne(int productid)
        {
            try
            {
                Product product = await repository.GetProductById(productid);
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("ByProductName/{name}")]
        public async Task<ActionResult> GetByProductName(string name)
        {
            try
            {
                Product product = await repository.GetByName(name);
                return Ok(product);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
