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
    public class NoteReposiory
    {
        string connectionString = @"Data Source=DESKTOP-54SAU6R\SQLEXPRESS;Initial Catalog=Others;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public IEnumerable<Note> GetAllNotes(string name, string token)
        {
            IEnumerable<Note> notes = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                UserRepos usRep = new UserRepos();
                IEnumerable<User> users = usRep.GetAllUsers();
                foreach (var item in users)
                {
                    if (item.Name == name && item.Token == token)
                    {
                        notes = db.GetAll<Note>();
                        return notes;
                    }
                }
            }
            return null;
        }
        public IEnumerable<Note> GetNotesByDate(DateTime strt, DateTime end, string name, string token)
        {
            IEnumerable<Note> notes = null;
            List<Note> dateNotes =new List<Note>();
            UserRepos usRep = new UserRepos();
            IEnumerable<User> users = usRep.GetAllUsers();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                foreach (var item in users)
                {
                    if (item.Name == name && item.Token == token)
                    {
                        notes = db.GetAll<Note>();
                        foreach (var note in notes)
                        {
                            if(note.Date >= strt && note.Date <= end)
                            {
                                dateNotes.Add(note);
                            }
                        }
                    }
                }
            }
            return dateNotes;
        }
        public Note? GetNoteById(int id, string name, string token)
        {
            Note? note = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                UserRepos usRep = new UserRepos();
                IEnumerable<User> users = usRep.GetAllUsers();
                foreach (var item in users)
                {
                    if (item.Name == name && item.Token == token)
                    {
                        try
                        {
                            note = db.Get<Note>(id);
                            return note;
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
        public string DeleteNoteById(int id, string token)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                Note note = null;
                UserRepos usRep = new UserRepos();
                IEnumerable<User> users = usRep.GetAllUsers();
                try
                {
                    note = db.Get<Note>(id);
                    foreach (var item in users)
                    {
                        if (note.Master == item.Name && token == item.Token)
                        {
                            db.Delete<Note>(note);
                            return "Deleted !";
                        }
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
        public string PutOneNote(Note note, string token)
        {
            UserRepos usRep = new UserRepos();
            IEnumerable<User> users = usRep.GetAllUsers();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                foreach (var item in users)
                {
                    if (note.Master == item.Name && token == item.Token)
                    {
                        db.Insert(note);
                        return "Added!)";
                    }
                }
                   
            }
            return "Wrong Data!(";
        }


    }
}
