using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_Csharp_Assignment.Demo
{
    class TravelerClassFunctions
    {
        public void Run()
        {
            int choice = 0;
            Traveler traveler = new Traveler();
            bool chooseFunction = true;
            var list = new List<Traveler>();
            while (chooseFunction)
            {
                Console.WriteLine("\nChoose a function in 'Traveler Class':");
                Console.WriteLine("1 - GetTravelers()");
                Console.WriteLine("2 - GetCount()");
                Console.WriteLine("3 - GetTravelInfo(nameChar, emailChar, phoneDigits)");
                Console.WriteLine("4 - Add(fullName, email)");
                Console.WriteLine("5 - Display data of room table after Add");
                Console.WriteLine("6 - GetByID(id)");
                Console.WriteLine("7 - Back");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine("========================================================================================================================");
                switch (choice)
                {
                    case 1:
                        list = traveler.GetTravelers();
                        Console.WriteLine($"ID\tFullName\tEmail\t\t\tPhone\t\t\tAddress");
                        foreach (var item in list)
                        {
                            traveler.CheckTap(item.FullName, item.Email);
                            Console.WriteLine($"{item.ID}\t{item.FullName}\t{traveler.tap}{item.Email}\t{traveler.tap1}{item.Phone}\t\t{item.Address}");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Number of rows in traveler table is " + traveler.GetCount());
                        break;
                    case 3:
                        Console.Write("Enter first character/characters of the name: ");
                        string nameChar = Console.ReadLine();
                        Console.Write("Enter any character/characters in email: ");
                        string emailChar = Console.ReadLine();
                        Console.Write("Enter last 4 digits of phone number: ");
                        string phoneDigits = Console.ReadLine();
                        list = traveler.GetTravelInfo(nameChar, emailChar, phoneDigits);
                        if (list.Count > 0)
                        {
                            Console.WriteLine($"\nID\tFullName\tEmail\t\t\tPhone\t\t\tAddress");
                            foreach (var item in list)
                            {
                                traveler.CheckTap(item.FullName, item.Email);
                                Console.WriteLine($"{item.ID}\t{item.FullName}\t{traveler.tap}{item.Email}\t{traveler.tap1}{item.Phone}\t\t{item.Address}");
                            }
                        }
                        else
                            Console.WriteLine("No records matching!");
                        break;
                    case 4:
                        Console.Write("Enter traveler full name: ");
                        string fullName = Console.ReadLine();
                        Console.Write("Enter traveler email: ");
                        string email = Console.ReadLine();
                        traveler.Add(fullName, email);
                        Console.WriteLine("Data inserted successfully.");
                        break;
                    case 5:
                        list = traveler.travelers;
                        if (list != null)
                        {
                            Console.WriteLine($"\nID\tFullName\tEmail\t\t\tPhone\t\t\tAddress");
                            foreach (var item in list)
                            {
                                traveler.CheckTap(item.FullName, item.Email);
                                Console.WriteLine($"{item.ID}\t{item.FullName}\t{traveler.tap}{item.Email}\t{traveler.tap1}{item.Phone}\t\t{item.Address}");
                            }
                        }
                        break;
                    case 6:
                        Console.Write("Enter traveler id: ");
                        int Id = int.Parse(Console.ReadLine());
                        if (traveler.GetByID(Id))
                            traveler.DisplayByID(Id);
                        else
                            Console.WriteLine($"Traveler id {Id} is not exist.");
                        break;
                    case 7:
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
