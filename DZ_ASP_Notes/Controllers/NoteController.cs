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
        public IEnumerable<Note> GetUsers()
        {
            return notRep.GetAllNotes();

        }
        [HttpGet("GetNoteById")]
        public Note? GetNoteById(int id)
        {
            return notRep.GetNoteById(id);
            ;
        }
        [HttpPut("PutOneNote")]
        public string PutOneNote(Note note, string token)
        {
            return notRep.PutOneNote(note,token);

        }
        [HttpDelete("DeleteNoteById")]
        public string DeleteNoteById(int id, string token)
        {
            return notRep.DeleteNoteById(id, token);

        }
    }
}
