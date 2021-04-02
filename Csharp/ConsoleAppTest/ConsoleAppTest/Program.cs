using System;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new ClassA();
            var b = a;

            a.name = "Eyad";
            Console.WriteLine(b.name);

            int n = 5;
            int o = n;
            n = 8;
            Console.WriteLine(o);

        }
    }
}
