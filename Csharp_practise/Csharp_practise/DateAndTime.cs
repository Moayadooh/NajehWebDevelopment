using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_practise
{
    class DateAndTime
    {
        public void Run()
        {
            DateTime dateTime = DateTime.Parse("04/11/2020");
            Console.WriteLine("Date: " + dateTime.Date);
            //Console.WriteLine("Day: " + dateTime.Day);
            //Console.WriteLine("Month: " + dateTime.Month);
            //Console.WriteLine("Year: " + dateTime.Year);
            //Console.WriteLine("Current date and time: " + DateTime.Now);
        }
    }
}
