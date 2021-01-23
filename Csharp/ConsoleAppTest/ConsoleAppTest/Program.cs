using System;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal salary = 300.0M; //Original salary
            int delay = 11; //Number of days
            decimal punishment = 0.0M;

            for (int i = 1; i <= delay; i++)
            {
                punishment += salary * (i * .01M);
            }
            decimal newSalary = salary + punishment;
            Console.WriteLine($"Employee must be given {newSalary} OMR");
        }
    }
}
