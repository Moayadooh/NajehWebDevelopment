using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_practise
{
    class Arrays
    {
        public void Run()
        {
            string[] languages = new string[6] { "C#", "Java", "SQL", "HTML", "CSS", "JavaScript" };
            //string[] languages = { "C#", "Java", "SQL", "HTML", "CSS", "JavaScript" };
            foreach (var item in languages)
            {
                Console.WriteLine(item);
            }
        }
    }
}
