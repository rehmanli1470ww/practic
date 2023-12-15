using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic.Models
{
    public class User
    {
        public int id { get; set; }
        public string?name { get; set; }
        public string?username { get; set; }
        public string?email { get; set; }
        public Adress?address { get; set; }
        public string?website { get; set; }
        public Company?company { get; set; }
        public User()
        {
            address = new();
            company = new ();
        }
        public override string ToString()
        {
            return name;
        }
    }
}
