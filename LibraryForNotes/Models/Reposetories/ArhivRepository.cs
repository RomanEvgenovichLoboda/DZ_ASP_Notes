using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace LibraryForNotes.Models.Reposetories
{
    public class ArhivRepository
    {
        string connectionString = @"Data Source=SQL5105.site4now.net;Initial Catalog=db_a8dfed_mydatabase1;User Id=db_a8dfed_mydatabase1_admin;Password=2657sgnusmas";
            //@"Data Source=DESKTOP-54SAU6R\SQLEXPRESS;Initial Catalog=Others;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public IEnumerable<Arhiv> Add(int id, string name, string token)
        {
            UserRepos usRep = new UserRepos();
            IEnumerable<User> users = usRep.GetAllUsers();
            IEnumerable<Arhiv> arhivs = null;
            Note? serchNote = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                foreach (var item in users)
                {
                    if (name == item.Name && token == item.Token)
                    {
                        try
                        {
                            serchNote = db.Get<Note>(id);
                            Arhiv arhiv = new Arhiv();
                            arhiv.Master = serchNote.Master;
                            arhiv.Title = serchNote.Title;
                            arhiv.Text = serchNote.Text;
                            arhiv.Date = serchNote.Date;
                            db.Insert(arhiv);
                            db.Delete<Note>(serchNote);
                            arhivs = db.GetAll<Arhiv>();
                            return arhivs;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            return null;
                        }

                    }
                }
            }
            return null;
        }
    }
}
