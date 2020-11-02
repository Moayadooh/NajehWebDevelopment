using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_LINQ
{
    class Program6
    {
        static void Main(string[] args)
        {
            var user_dpt_group = Department.GetDepartments().GroupJoin(User.GetUsers(),
                                                                        dpt => dpt.DepID,
                                                                        user => user.DepID,
                                                                        (dpt, user) => new 
                                                                        { 
                                                                            employee = user,
                                                                            dptName = dpt.DepName
                                                                        });

            foreach (var itemDept in user_dpt_group)
            {
                Console.WriteLine("Department Name : " + itemDept.dptName);
                Console.WriteLine("------------------------------------------------");
                foreach (var itemempdetails in itemDept.employee)
                {
                    Console.WriteLine($"{ itemempdetails.Email  } , {itemempdetails.Address} , {itemempdetails.Phone} , { itemDept.dptName}");
                }
                Console.WriteLine("=============================================================================");
            }
        }
    }
}
