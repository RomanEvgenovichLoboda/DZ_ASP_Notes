using LibraryForNotes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using LibraryForNotes.Models.Reposetories;

namespace DZ_ASP_Notes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController:Controller
    {
        //string connectionString = @"Data Source=DESKTOP-54SAU6R\SQLEXPRESS;Initial Catalog=Others;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        UserRepos usRep = new UserRepos();
        [HttpGet("GetAll")]
        public IEnumerable<User> GetUsers()
        {
            return usRep.GetAllUsers();
            
        }
        [HttpGet("GetById")]
        public User? GetUserById(int Id)
        {
            return usRep.GetUserById(Id);
            
        }
        [HttpPut("Put")]
        public string PutUser(User user)
        {
            return usRep.PutOne(user);

        }
        [HttpDelete("DeleteById")]
        public string DeleteById(int id, string token)
        {
            return usRep.DeleteById(id, token);

        }
    }
}
