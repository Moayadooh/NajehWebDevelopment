using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_LINQ
{
    class Profile
    {
        public int ID { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public int Age { get; set; }
        public Student Student { get; set; } // One Student To One Profile
        public Trainer Trainer { get; set; } // One Trainer To One Profile

        public List<Profile> GetProfiles()
        {
            return new List<Profile>
            {
                new Profile { ID=100,Address="ammar",Age=37,Image="sdsdf.jpg"},
                new Profile { ID=101,Address="ali",Age=25,Image="sffff.jpg"},
                new Profile { ID=102,Address="zaqi",Age=30,Image="vnnnn.jpg"},
                new Profile { ID=103,Address="saad",Age=20,Image="tyyt.jpg"},
                new Profile { ID=104,Address="waad",Age=22,Image="nbbn.jpg"},
                new Profile { ID=567987,Address="Mohammad",Age=22,Image="nbbn.jpg"},
            };
        }
    }
}
