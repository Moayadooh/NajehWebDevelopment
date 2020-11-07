using System;
using System.Collections.Generic;
using System.Text;

namespace Day1_LINQ_Practise
{
    class User
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }

        public static List<User> GetUsers()
        {
            return new List<User>()
            {
                new User { ID= 10, Email="Mohammad",Address="Bidyya",Password="123", Phone=55895  },
                new User { ID= 11, Email="Loay",Address="alkhwair",Password="1234", Phone=67895  },
                new User { ID= 12, Email="Muayyad",Address="suhar",Password="1236", Phone=88895  },
                new User { ID= 13, Email="Amani",Address="albatna",Password="1237", Phone=805895  },

                new User { ID= 14, Email="fatma",Address="matrah",Password="1239", Phone=325895  },
                new User { ID= 15, Email="nouf",Address="matrah",Password="1233", Phone=1225895  },
                new User { ID= 16, Email="mai",Address="alsaib",Password="6233", Phone=95895  },
                new User { ID= 17, Email="balqees",Address="alsaib",Password="8833", Phone=75895  },

                new User { ID= 18, Email="khloud",Address="sour",Password="7233", Phone=18895  },
                new User { ID= 19, Email="Ayat",Address="albremy",Password="7233", Phone=45895  },
                new User { ID= 20, Email="hajar",Address="alkhoudh",Password="1233", Phone=1225895  },
                new User { ID= 21, Email="maithaa",Address="sour",Password="1233", Phone=025895  },

                new User { ID= 22, Email="iman",Address="ghala",Password="1233", Phone=95895  },
                new User { ID= 23, Email="eman",Address="alazaiba",Password="1233", Phone=35895  },
                new User { ID= 24, Email="lubna",Address="alazaiba",Password="1233", Phone=85895  }
            };
        }

        public static void Display(List<User> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine($"{item.ID}\t{item.Email}\t{item.Password}\t{item.Address}\t{item.Phone}");
            }
        }

        public static void Display(List<int> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
