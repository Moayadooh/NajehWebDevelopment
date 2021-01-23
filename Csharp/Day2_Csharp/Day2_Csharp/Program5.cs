using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_Csharp
{
    class Program5
    {
        public static void AssignAddress(Employee emp)
        {
            emp.Address = "Musqat";
        }

        static void Main(string[] args)
        {
            Calc obj = new Calc();
            Console.WriteLine("Th value is " + obj.getValue(3));
            Console.WriteLine("Th minimum is " + obj.getMinValue(3,2));
            //==================================================================
            Console.WriteLine("===================================================================");
            int a = 45;
            obj.getByVal(a);
            Console.WriteLine("Get BY Val " + a);
            obj.getByRef(ref a);
            Console.WriteLine("Get BY Ref " + a);
            //====================================================
            int z = 50;
            Calc.getByVal2(z);
            Console.WriteLine("Get BY Val " + z);
            Calc.getByRef2(ref z);
            Console.WriteLine("Get BY Ref " + z);

            //================================================================================
            Employee emp2 = new Employee();
            emp2.Address = "Sour";
            AssignAddress(emp2);
            Console.WriteLine(emp2.Address);
        }



    }
}
