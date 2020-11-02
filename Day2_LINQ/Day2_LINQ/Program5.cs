using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_LINQ
{
    class Program5
    {
        static void Main(string[] args)
        {
            // linq Method
            var user_dept = User.GetUsers().Join(Department.GetDepartments(),
                                                               user => user.DepID,
                                                               dpt => dpt.DepID,
                                                              (user, dpt) => new
                                                              {
                                                                  username = user.Email,
                                                                  dptname = dpt.DepName,
                                                              });

            foreach (var item in user_dept)
            {
                Console.WriteLine($" User Name :{ item.username } , User Department {item.dptname}");

            }
            Console.WriteLine("===================================================================");
            var user_dept2 = from user in User.GetUsers()
                             join dpt in Department.GetDepartments()
                             on user.DepID equals dpt.DepID
                             select new
                             {
                                 username = user.Email,
                                 dptname = dpt.DepName
                             };
            foreach (var item in user_dept2)
            {
                Console.WriteLine($" User Name :{ item.username } , User Department {item.dptname}");

            }
        }
    }
}
