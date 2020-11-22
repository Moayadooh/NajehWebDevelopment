using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_Csharp_Assignment.Demo
{
    class HotelClassFunctions
    {
        public void Run()
        {
            int choice = 0;
            Hotel hotel = new Hotel();
            bool chooseFunction = true;
            var list = new List<Hotel>();
            while (chooseFunction)
            {
                Console.WriteLine("\nChoose a function in 'Hotel Class':");
                Console.WriteLine("1 - GetHotels()");
                Console.WriteLine("2 - GetCount()");
                Console.WriteLine("3 - StarsGroup()");
                Console.WriteLine("4 - HotelJoinRoom()");
                Console.WriteLine("5 - Add(name, address)");
                Console.WriteLine("6 - Display data of hotel table after Add");
                Console.WriteLine("7 - GetByID(id)");
                Console.WriteLine("8 - Back");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine("========================================================================================================================");
                switch (choice)
                {
                    case 1:
                        list = hotel.GetHotels();
                        Console.WriteLine($"ID\tName\t\tAddress\t\tStreet\t\tPhone\t\tRate(Stars)");
                        foreach (var item in list)
                        {
                            Console.WriteLine($"{item.ID}\t{item.Name}\t\t{item.Address}\t\t{item.Street}\t\t{item.Phone}\t{item.Rate}");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Number of rows in hotel table is " + hotel.GetCount());
                        break;
                    case 3:
                        hotel.StarsGroup();
                        break;
                    case 4:
                        hotel.HotelJoinRoom();
                        break;
                    case 5:
                        Console.Write("Enter hotel name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter hotel address: ");
                        string address = Console.ReadLine();
                        hotel.Add(name, address);
                        Console.WriteLine("Data inserted successfully.");
                        break;
                    case 6:
                        list = hotel.hotels;
                        if (list != null)
                        {
                            Console.WriteLine($"ID\tName\t\tAddress\t\tStreet\t\tPhone\t\tRate(Stars)");
                            foreach (var item in list)
                            {
                                Console.WriteLine($"{item.ID}\t{item.Name}\t\t{item.Address}\t\t{item.Street}\t\t{item.Phone}\t{item.Rate}");
                            }
                        }
                        break;
                    case 7:
                        Console.Write("Enter hotel id: ");
                        int Id = int.Parse(Console.ReadLine());
                        if (hotel.GetByID(Id))
                            hotel.DisplayByID(Id);
                        else
                            Console.WriteLine($"Hotel id {Id} is not exist.");
                        break;
                    case 8:
                        Console.WriteLine("========================================================================================================================");
                        return;
                }
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("\nDo you want to continue ?");
                Console.WriteLine("1 - Yes");
                Console.WriteLine("2 - No");
                choice = int.Parse(Console.ReadLine());
                if (choice == 2)
                {
                    chooseFunction = false;
                    MainProgram.chooseClass = false;
                }
            }
        }
    }
}
