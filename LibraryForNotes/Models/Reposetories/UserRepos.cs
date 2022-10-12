using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForNotes.Models.Reposetories
{
    public class UserRepos
    {
        string connectionString = @"Data Source=SQL5105.site4now.net;Initial Catalog=db_a8dfed_mydatabase1;User Id=db_a8dfed_mydatabase1_admin;Password=2657sgnusmas";
        //@"Data Source=DESKTOP-54SAU6R\SQLEXPRESS;Initial Catalog=Others;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public IEnumerable<User> GetAllUsers()
        {
            IEnumerable<User> users = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                users = db.GetAll<User>();
            }
            return users;
        }
        public User? GetUserById(int id)
        {
            User? user = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                user = db.Get<User>(id);
            }
            return user;
        }
        public string DeleteById(int id, string token)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                User user = null;
                try
                {
                    user = db.Get<User>(id);
                    if (user.Token == token)
                    {
                        db.Delete<User>(GetUserById(id));
                        return "Deleted !";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return "Error !";
                }



            }
            return "Error !";
        }
        public string PutOne(User user)
        {
            IEnumerable<User> users = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                bool isIn = false;
                users = db.GetAll<User>();
                foreach (User item in users)
                {
                    if(item.Name == user.Name) isIn = true;
                }
                if(!isIn) 
                {
                    db.Insert(user);
                    return "Added !)";
                }
                else return "This Name Taken !(";
            }
            
        }
        //public string GetToken()
        //{
        //    string abc = "abcdefghijklmnopqrstuvwxyz";
        //    string _token = "";
        //    foreach (char symbol in abc)
        //    {

        //    }
        //}

    }
}
