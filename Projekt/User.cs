using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class User
    {
        public int User_id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public DateTime Birth_Date { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Number { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public string Actual_position { get; set; }
        public string Position_description { get; set; }
        public List<string> Experience { get; set; }
        public List<string> Education { get; set; }
        public List<string> Languages { get; set; }
        public List<string> Skills { get; set; }
        public List<string> Courses { get; set; }
        public List<string> Links { get; set; }
    }
}
