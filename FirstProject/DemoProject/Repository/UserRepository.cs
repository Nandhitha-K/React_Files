using DemoProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Repository
{
    public class UserRepository : IUserRepository
    {
        DemoDbContext dbContext=new DemoDbContext();
        public async Task<Users> GetUsersByEmail(string email)
        {
            try
            {
                Users user = await (from u in dbContext.Users where u.Email == email select u).FirstAsync();
                return user;
            }
            catch(Exception ex)
            {
                throw new Exception("Email not exists");
            }
        }

        public async Task InsertUser(Users user)
        {
             try
            {
                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<(bool IsSuccess, string Message, int UserId, string UserName)> IsLogin(string email, string password)
        {
            Users account = await GetUsersByEmail(email);
            if (account == null)
            {
                return (false, "No such user", 0, "");
            }
            else
            {
                if (account.Password == password)
                {
                    return (true, "Login successful", account.UserId, account.UserName);
                }
                else
                {
                    return (false, "Password does not match", 0, "");
                }
            }
        }

        public async Task<(bool IsSuccess, string Message)> SignUp(Users account)
        {
            try
            {
                Users acc = await GetUsersByEmail(account.Email);
                return (false, "User already exists");
            }
            catch (Exception ex)
            {
                await InsertUser(account);
                return (true, "Account created successfully");
            }
        }

    }
}
