using System;
using System.Collections.Generic;
using System.Text;
using name1.name2; //Access class inside namespace

namespace Csharp_practise
{
    class AddNamespace
    {
        public void Run()
        {
            MyClass.doSomething();
        }
    }
}

namespace name1
{
    namespace name2
    {
        public class MyClass
        {
            public static void doSomething()
            {
                Console.WriteLine("Hellooo!");
            }
        }
    }
}