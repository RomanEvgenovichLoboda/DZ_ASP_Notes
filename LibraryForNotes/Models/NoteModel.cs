using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForNotes.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Master { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
