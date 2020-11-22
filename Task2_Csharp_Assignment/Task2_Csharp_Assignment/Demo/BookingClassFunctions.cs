using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_Csharp_Assignment.Demo
{
    class BookingClassFunctions
    {
        public void Run()
        {
            int choice = 0;
            Booking booking = new Booking();
            bool chooseFunction = true;
            var list = new List<Booking>();
            Booking items;
            while (chooseFunction)
            {
                Console.WriteLine("\nChoose a function in 'Booking Class':");
                Console.WriteLine("1 - GetBookings()");
                Console.WriteLine("2 - GetCount()");
                Console.WriteLine("3 - GetItem(id)");
                Console.WriteLine("4 - ShowBooking(dateTime)");
                Console.WriteLine("5 - ShowBooking(guest)");
                Console.WriteLine("6 - ShowBooking(travelerID, paidStatus)");
                Console.WriteLine("7 - RoomJoinBooking()");
                Console.WriteLine("8 - PaymentAlert()");
                Console.WriteLine("9 - GetTotalGuests(dateTime)");
                Console.WriteLine("10 - LatestBookingDate()");
                Console.WriteLine("11 - OldestBookingDate()");
                Console.WriteLine("12 - Add(roomID, dateCreated)");
                Console.WriteLine("13 - Display data of booking table after Add");
                Console.WriteLine("14 - GetByID(id)");
                Console.WriteLine("15 - Back");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine("========================================================================================================================");
                switch (choice)
                {
                    case 1:
                        list = booking.GetBookings();
                        Console.WriteLine($"ID\tRoomID\tDateCreated\t\tCheckIn\t\t\tCheckOut\t\tGuest\tPaid\tTravelerID");
                        foreach (var item in list)
                        {
                            Console.WriteLine($"{item.ID}\t{item.RoomID}\t{item.DateCreated}\t{item.CheckIn}\t{item.CheckOut}\t{item.Guest}\t{item.Paid}\t{item.TravelerID}");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Number of rows in booking table is " + booking.GetCount());
                        break;
                    case 3:
                        Console.Write("Enter booking id: ");
                        int id = int.Parse(Console.ReadLine());
                        if (booking.GetItem(id) != null)
                        {
                            if (booking.GetItem(id) ?? false)
                                Console.WriteLine("Booking id is available.");
                            else
                                Console.WriteLine("Booking id is not available.");
                        }
                        else
                            Console.WriteLine("Booking id is not exist.");
                        break;
                    case 4:
                        Console.Write("Enter booking check in date(mm/dd/yyyy): ");
                        string date = Console.ReadLine();
                        list = booking.ShowBooking(date);
                        if (list.Count > 0)
                        {
                            Console.WriteLine($"\nID\tRoomID\tDateCreated\t\tCheckIn\t\t\tCheckOut\t\tGuest\tPaid\tTravelerID");
                            foreach (var item in list)
                            {
                                Console.WriteLine($"{item.ID}\t{item.RoomID}\t{item.DateCreated}\t{item.CheckIn}\t{item.CheckOut}\t{item.Guest}\t{item.Paid}\t{item.TravelerID}");
                            }
                        }
                        else
                            Console.WriteLine("No records matching!");
                        break;
                    case 5:
                        Console.Write("Enter number of guests: ");
                        int guest = int.Parse(Console.ReadLine());
                        list = booking.ShowBooking(guest);
                        if (list.Count > 0)
                        {
                            Console.WriteLine($"\nID\tRoomID\tDateCreated\t\tCheckIn\t\t\tCheckOut\t\tGuest\tPaid\tTravelerID");
                            foreach (var item in list)
                            {
                                Console.WriteLine($"{item.ID}\t{item.RoomID}\t{item.DateCreated}\t{item.CheckIn}\t{item.CheckOut}\t{item.Guest}\t{item.Paid}\t{item.TravelerID}");
                            }
                        }
                        else
                            Console.WriteLine("No records matching!");
                        break;
                    case 6:
                        Console.Write("Enter traveler ID: ");
                        int travelerID = int.Parse(Console.ReadLine());
                        Console.WriteLine("Choose paid status: ");
                        Console.WriteLine("1 - Paid");
                        Console.WriteLine("2 - Not Paid");
                        int paidStatus = int.Parse(Console.ReadLine());
                        bool paid = false;
                        if (paidStatus == 1)
                            paid = true;
                        list = booking.ShowBooking(travelerID, paid);
                        if (list.Count > 0)
                        {
                            Console.WriteLine($"\nID\tRoomID\tDateCreated\t\tCheckIn\t\t\tCheckOut\t\tGuest\tPaid\tTravelerID");
                            foreach (var item in list)
                            {
                                Console.WriteLine($"{item.ID}\t{item.RoomID}\t{item.DateCreated}\t{item.CheckIn}\t{item.CheckOut}\t{item.Guest}\t{item.Paid}\t{item.TravelerID}");
                            }
                        }
                        else
                            Console.WriteLine("No records matching!");
                        break;
                    case 7:
                        booking.RoomJoinBooking();
                        break;
                    case 8:
                        booking.PaymentAlert();
                        break;
                    case 9:
                        Console.Write("Enter booking check in date(mm/dd/yyyy): ");
                        string Date = Console.ReadLine();
                        Console.WriteLine($"\nTotal number of guests in {Date} is {booking.GetTotalGuests(Date)}");
                        break;
                    case 10:
                        items = booking.LatestBookingDate();
                        Console.WriteLine("Latest Booking:");
                        Console.WriteLine($"\nID\tRoomID\tDateCreated\t\tCheckIn\t\t\tCheckOut\t\tGuest\tPaid\tTravelerID");
                        Console.WriteLine($"{items.ID}\t{items.RoomID}\t{items.DateCreated}\t{items.CheckIn}\t{items.CheckOut}\t{items.Guest}\t{items.Paid}\t{items.TravelerID}");
                        break;
                    case 11:
                        items = booking.OldestBookingDate();
                        Console.WriteLine("Oldest Booking:");
                        Console.WriteLine($"\nID\tRoomID\tDateCreated\t\tCheckIn\t\t\tCheckOut\t\tGuest\tPaid\tTravelerID");
                        Console.WriteLine($"{items.ID}\t{items.RoomID}\t{items.DateCreated}\t{items.CheckIn}\t{items.CheckOut}\t{items.Guest}\t{items.Paid}\t{items.TravelerID}");
                        break;
                    case 12:
                        Console.Write("Enter room ID: ");
                        string roomID = Console.ReadLine();
                        booking.Add(roomID, DateTime.Now.ToString());
                        Console.WriteLine("Data inserted successfully.");
                        break;
                    case 13:
                        list = booking.bookings;
                        if (list != null)
                        {
                            Console.WriteLine($"ID\tRoomID\tDateCreated\t\tCheckIn\t\t\tCheckOut\t\tGuest\tPaid\tTravelerID");
                            foreach (var item in list)
                            {
                                Console.WriteLine($"{item.ID}\t{item.RoomID}\t{item.DateCreated}\t{item.CheckIn}\t{item.CheckOut}\t{item.Guest}\t{item.Paid}\t{item.TravelerID}");
                            }
                        }
                        break;
                    case 14:
                        Console.Write("Enter booking id: ");
                        int Id = int.Parse(Console.ReadLine());
                        if (booking.GetByID(Id))
                            booking.DisplayByID(Id);
                        else
                            Console.WriteLine($"Booking id {Id} is not exist.");
                        break;
                    case 15:
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
