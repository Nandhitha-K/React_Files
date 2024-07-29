using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DemoProject.Model;
using DemoProject.Repository;
namespace DemoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepository repository;
        public UserController(IUserRepository userRepository)
        {
            repository = userRepository;
        }
        [HttpGet("ByEmail/{email}")]
        public async Task<ActionResult> GetOne(string email)
        {
            try
            {
                Users user = await repository.GetUsersByEmail(email);
                return Ok(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

  
        [HttpGet("Login/{email}/{password}")]
        public async Task<ActionResult> Login(string email, string password)
        {
            try
            {
                var response = await repository.IsLogin(email, password);
                return Ok(new { isSuccess = response.IsSuccess, message = response.Message, userId = response.UserId, name = response.UserName });
            }
            catch (Exception ex)
            {
                return Ok(new { isSuccess = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> SignUp(Users account)
        {
            try
            {
                var response = await repository.SignUp(account);
                return Ok(new { isSuccess = response.IsSuccess, message = response.Message, });
            }
            catch (Exception ex)
            {
                return Ok(new { isSuccess = false, message = ex.Message });
            }
        }

        
    }
}
