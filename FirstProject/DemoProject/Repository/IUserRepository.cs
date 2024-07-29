using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoProject.Model;

namespace DemoProject.Repository
{
    public interface IUserRepository
    {
       
        Task<Users>GetUsersByEmail(string email);
        Task InsertUser(Users user);
        Task<(bool IsSuccess, string Message, int UserId, string UserName)> IsLogin(string email, string password);
        Task<(bool IsSuccess, string Message)> SignUp(Users account);
    }
}
