using LibraryForNotes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using LibraryForNotes.Models.Reposetories;

namespace DZ_ASP_Notes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController: Controller
    {
        NoteReposiory notRep = new NoteReposiory();
        [HttpGet("GetAllNotes")]
        public IEnumerable<Note> GetUsers(string name, string token)
        {
            return notRep.GetAllNotes(name,token);

        }
        [HttpGet("GetNotesByDate")]
        public IEnumerable<Note> GetNotesByDate(DateTime strt, DateTime end, string name, string token)
        {
            return notRep.GetNotesByDate(strt,end,name,token);
        }
        [HttpGet("GetNoteById")]
        public Note? GetNoteById(int id,string name, string token)
        {
            return notRep.GetNoteById(id, name, token);
        }
        [HttpPut("PutOneNote")]
        public string PutOneNote(Note note, string token)
        {
            return notRep.PutOneNote(note,token);

        }
        [HttpPut("PutToArhiv")]
        public string PutToArhiv(int id, string name, string token)
        {
            ArhivRepository arRep = new ArhivRepository();

            return arRep.Add(id,name, token);

        }
        [HttpDelete("DeleteNoteById")]
        public string DeleteNoteById(int id, string token)
        {
            return notRep.DeleteNoteById(id, token);

        }
    }
}
