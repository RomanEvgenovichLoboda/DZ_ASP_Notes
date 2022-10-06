using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForNotes.Models
{
    public class User
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
    }
}
