using System;
using System.Collections.Generic;
using System.Linq;
using Task2_Csharp_Assignment.Demo;

namespace Task2_Csharp_Assignment
{
    class MainProgram
    {
        static int choice = 0;
        public static bool chooseClass = true;
        static void Main(string[] args)
        {
            while (chooseClass)
            {
                Console.WriteLine("\nChoose a class:");
                Console.WriteLine("1 - Hotel");
                Console.WriteLine("2 - Room");
                Console.WriteLine("3 - Booking");
                Console.WriteLine("4 - Traveler");
                Console.WriteLine("5 - Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        new HotelClassFunctions().Run();
                        break;
                    case 2:
                        new RoomClassFunctions().Run();
                        break;
                    case 3:
                        new BookingClassFunctions().Run();
                        break;
                    case 4:
                        new TravelerClassFunctions().Run();
                        break;
                    case 5:
                        chooseClass = false;
                        break;
                }
            }
        }
    }
}
