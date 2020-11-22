using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_Csharp_Assignment.Demo
{
    class RoomClassFunctions
    {
        public void Run()
        {
            int choice = 0;
            Room room = new Room();
            bool chooseFunction = true;
            var list = new List<Room>();
            while (chooseFunction)
            {
                Console.WriteLine("\nChoose a function in 'Room Class':");
                Console.WriteLine("1 - GetRooms()");
                Console.WriteLine("2 - GetCount()");
                Console.WriteLine("3 - GetItem(id)");
                Console.WriteLine("4 - GetRoomByPrice(min, max)");
                Console.WriteLine("5 - PriceRanking(price)");
                Console.WriteLine("6 - PriceRankGroup()");
                Console.WriteLine("7 - Add(number, price)");
                Console.WriteLine("8 - Display data of room table after Add");
                Console.WriteLine("9 - GetByID(id)");
                Console.WriteLine("10 - Back");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine("========================================================================================================================");
                switch (choice)
                {
                    case 1:
                        list = room.GetRooms();
                        Console.WriteLine($"ID\tNumber\t\tAvailable\tPrice\t\tHotelID\t\tPhone");
                        foreach (var item in list)
                        {
                            Console.WriteLine($"{item.ID}\t{item.Number}\t\t{item.Available}\t\t{item.Price}\t\t{item.HotelID}\t\t{item.Phone}");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Number of rows in room table is " + room.GetCount());
                        break;
                    case 3:
                        Console.Write("Enter room id: ");
                        int id = int.Parse(Console.ReadLine());
                        if (room.GetItem(id) != null)
                        {
                            if (room.GetItem(id) ?? false)
                                Console.WriteLine("Room id is available.");
                            else
                                Console.WriteLine("Room id is not available.");
                        }
                        else
                            Console.WriteLine("Room id is not exist.");
                        break;
                    case 4:
                        Console.Write("Enter minimum price: ");
                        double min = double.Parse(Console.ReadLine());
                        Console.Write("Enter maximum price: ");
                        double max = double.Parse(Console.ReadLine());
                        list = room.GetRoomByPrice(min, max);
                        if (list.Count > 0)
                        {
                            Console.WriteLine($"\nID\tNumber\t\tAvailable\tPrice\t\tHotelID\t\tPhone");
                            foreach (var item in list)
                            {
                                Console.WriteLine($"{item.ID}\t{item.Number}\t\t{item.Available}\t\t{item.Price}\t\t{item.HotelID}\t\t{item.Phone}");
                            }
                        }
                        else
                            Console.WriteLine("There is no room available in this range of price");
                        break;
                    case 5:
                        Console.Write("Enter price: ");
                        double Price = double.Parse(Console.ReadLine());
                        Console.WriteLine(room.PriceRanking(Price));
                        break;
                    case 6:
                        room.PriceRankGroup();
                        break;
                    case 7:
                        Console.Write("Enter room number: ");
                        string number = Console.ReadLine();
                        Console.Write("Enter room price: ");
                        string price = Console.ReadLine();
                        room.Add(number, price);
                        Console.WriteLine("Data inserted successfully.");
                        break;
                    case 8:
                        list = room.rooms;
                        if (list != null)
                        {
                            Console.WriteLine($"ID\tNumber\t\tAvailable\tPrice\t\tHotelID\t\tPhone");
                            foreach (var item in list)
                            {
                                Console.WriteLine($"{item.ID}\t{item.Number}\t\t{item.Available}\t\t{item.Price}\t\t{item.HotelID}\t\t{item.Phone}");
                            }
                        }
                        break;
                    case 9:
                        Console.Write("Enter room id: ");
                        int Id = int.Parse(Console.ReadLine());
                        if (room.GetByID(Id))
                            room.DisplayByID(Id);
                        else
                            Console.WriteLine($"Room id {Id} is not exist.");
                        break;
                    case 10:
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
