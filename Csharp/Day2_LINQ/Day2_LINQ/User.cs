using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_LINQ
{
    class User
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public int Salary { get; set; }
        public int DepID { get; set; }

        public static List<User> GetUsers()
        {
            return new List<User>()
            {
                new User { ID= 10, Email="Mohammad",Address="Bidyya",Password="123", Phone=55895, Salary=2000,DepID=100  },
                new User { ID= 11, Email="Loay",Address="alkhwair",Password="1234", Phone=67895 , Salary=3000,DepID=101 },
                new User { ID= 12, Email="Muayyad",Address="alkhwair",Password="1236", Phone=88895 ,Salary=200,DepID=101 },
                new User { ID= 13, Email="Amani",Address="alkhwair",Password="1237", Phone=805895 , Salary=3000,DepID=102 },

                new User { ID= 14, Email="fatma",Address="matrah",Password="1239", Phone=325895, Salary=5000,DepID=100  },
                new User { ID= 15, Email="nouf",Address="matrah",Password="1233", Phone=1225895 , Salary=5000 ,DepID=102},
                new User { ID= 16, Email="mai",Address="alsaib",Password="6233", Phone=95895 , Salary=5000,DepID=100 },
                new User { ID= 17, Email="balqees",Address="alsaib",Password="8833", Phone=75895 , Salary=3000, DepID=100 },

                new User { ID= 18, Email="khloud",Address="sour",Password="7233", Phone=18895 , Salary=9000,DepID=101 },
                new User { ID= 19, Email="Ayat",Address="albremy",Password="7233", Phone=45895 , Salary=9000,DepID=101 },
                new User { ID= 20, Email="hajar",Address="alkhoudh",Password="1233", Phone=1225895 , Salary=9500,DepID=102 },
                new User { ID= 21, Email="maithaa",Address="sour",Password="1233", Phone=025895, Salary=9500,DepID=100  },

                new User { ID= 22, Email="iman",Address="alkhwair",Password="1233", Phone=95895 , Salary=6000,DepID=100 },
                new User { ID= 23, Email="eman",Address="alazaiba",Password="1233", Phone=35895  ,Salary=6000,DepID=102},
                new User { ID= 24, Email="lubna",Address="alazaiba",Password="1233", Phone=85895 , Salary= 60000,DepID=100 }
            };
        }

        public static void Show(List<User> userparam)
        {
            Console.WriteLine("ID \t Email \t Address \t Phone \t ");
            Console.WriteLine("--------------------------------------------------------");
            foreach (var item in userparam)
            {
                Console.WriteLine($"{item.ID} \t {item.Email} \t {item.Address} \t {item.Phone}");
                Console.WriteLine("--------------------------------------------------------");
            }
        }

        public string getSalaryGroup()
        {
            if (Salary >= 5000)
            {
                return "Exellent";
            }
            else if (Salary > 1000)
            {
                return "very good";
            }
            else
            {
                return "good";
            }
        }
    }
}
