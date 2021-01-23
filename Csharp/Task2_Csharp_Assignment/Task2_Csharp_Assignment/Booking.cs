using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2_Csharp_Assignment
{
    class Booking : HotelsBooking, IHotelBooking
    {
        public int RoomID { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public int? Guest { get; set; }
        public bool? Paid { get; set; }
        public int? TravelerID { get; set; }
        //public Room Room { get; set; }
        //public Traveler Traveler { get; set; }

        public override int GetCount()
        {
            if (bookings == null)
                return GetBookings().Count;
            return bookings.Count;
        }

        public override bool? GetItem(int id)
        {
            var row = GetBookings().Single(x => x.ID == id);
            if (row != null)
                return row.Paid;
            else
                return null;
        }

        public List<Booking> ShowBooking(string dateTime)
        {
            var list = GetBookings().Where(x => x.CheckIn == DateTime.Parse(dateTime)).OrderByDescending(x => x.DateCreated).ToList();
            var rows = new List<Booking>();
            foreach (var item in list)
            {
                rows.Add(item);
            }
            return rows;
        }

        public List<Booking> ShowBooking(int guest)
        {
            var list = GetBookings().Where(x => x.Guest == guest).OrderBy(x => x.DateCreated).ToList();
            var rows = new List<Booking>();
            foreach (var item in list)
            {
                rows.Add(item);
            }
            return rows;
        }

        public List<Booking> ShowBooking(int travelerID, bool paidStatus)
        {
            var list = GetBookings().Where(x => x.TravelerID == travelerID && x.Paid == paidStatus).ToList();
            var rows = new List<Booking>();
            foreach (var item in list)
            {
                rows.Add(item);
            }
            return rows;
        }

        public void RoomJoinBooking()
        {
            var list = GetBookings().Join(new Room().GetRooms(), b => b.RoomID, r => r.ID, (b, r) => new { roomID = r.ID, travelerID = b.TravelerID, checkIn = b.CheckIn, price = r.Price }).ToList();
            Console.WriteLine("RoomID\t\tTravelerID\tCheckIn\t\t\t\tPrice");
            foreach (var item in list)
            {
                Console.WriteLine($"{item.roomID}\t\t{item.travelerID}\t\t{item.checkIn}\t\t{item.price}");
            }
        }

        public void PaymentAlert()
        {
            var notPaid = GetBookings().Any(x => x.Paid == false);
            if (notPaid)
                Console.WriteLine("Check due date payment");
        }

        public int? GetTotalGuests(string dateTime)
        {
            var list = GetBookings().Where(x => x.CheckIn == DateTime.Parse(dateTime)).ToList();
            int? count = 0;
            foreach (var item in list)
            {
                count += item.Guest;
            }
            return count;
        }

        public Booking LatestBookingDate()
        {
            var dateTime = GetBookings().Max(x => x.DateCreated);
            var row = GetBookings().Find(x => x.DateCreated == dateTime);
            return row;
        }

        public Booking OldestBookingDate()
        {
            var dateTime = GetBookings().Min(x => x.DateCreated);
            var row = GetBookings().Find(x => x.DateCreated == dateTime);
            return row;
        }

        public List<Booking> GetBookings()
        {
            return new List<Booking>()
            {
                new Booking(){ID=1, RoomID=399, DateCreated=DateTime.Parse("03/17/2018"), CheckIn=DateTime.Parse("03/18/2018"), CheckOut=DateTime.Parse("03/26/2018"), Guest=3, Paid=false, TravelerID=5},
                new Booking(){ID=2, RoomID=150, DateCreated=DateTime.Parse("05/29/2017"), CheckIn=DateTime.Parse("05/03/2017"), CheckOut=DateTime.Parse("05/04/2017"), Guest=2, Paid=true, TravelerID=3},
                new Booking(){ID=3, RoomID=150, DateCreated=DateTime.Parse("07/02/2017"), CheckIn=DateTime.Parse("07/03/2017"), CheckOut=DateTime.Parse("07/10/2017"), Guest=5, Paid=true, TravelerID=3},
                new Booking(){ID=4, RoomID=151, DateCreated=DateTime.Parse("09/14/2019"), CheckIn=DateTime.Parse("09/15/2019"), CheckOut=DateTime.Parse("09/20/2019"), Guest=3, Paid=false, TravelerID=4},
                new Booking(){ID=5, RoomID=151, DateCreated=DateTime.Parse("10/08/2019"), CheckIn=DateTime.Parse("10/09/2019"), CheckOut=DateTime.Parse("10/15/2019"), Guest=6, Paid=true, TravelerID=4},
                new Booking(){ID=6, RoomID=355, DateCreated=DateTime.Parse("09/11/2015"), CheckIn=DateTime.Parse("09/12/2015"), CheckOut=DateTime.Parse("09/15/2015"), Guest=4, Paid=true, TravelerID=1},
                new Booking(){ID=7, RoomID=355, DateCreated=DateTime.Parse("10/23/2015"), CheckIn=DateTime.Parse("10/24/2015"), CheckOut=DateTime.Parse("10/25/2015"), Guest=1, Paid=true, TravelerID=1},
                new Booking(){ID=8, RoomID=356, DateCreated=DateTime.Parse("02/20/2015"), CheckIn=DateTime.Parse("02/21/2015"), CheckOut=DateTime.Parse("02/23/2015"), Guest=2, Paid=true, TravelerID=2},
                new Booking(){ID=9, RoomID=356, DateCreated=DateTime.Parse("05/19/2015"), CheckIn=DateTime.Parse("05/20/2015"), CheckOut=DateTime.Parse("05/27/2015"), Guest=1, Paid=true, TravelerID=2}
            };
        }

        public List<Booking> bookings = null;
        public void InitializeList()
        {
            if (bookings == null)
            {
                bookings = new List<Booking>();
                foreach (var item in GetBookings())
                {
                    bookings.Add(item);
                }
            }
        }

        public int id = 10;
        public void Add(string roomID, string dateCreated)
        {
            InitializeList();
            bookings.Add(new Booking() { ID = id++, RoomID = int.Parse(roomID), DateCreated = DateTime.Parse(dateCreated), CheckIn = null, CheckOut = null, Guest = null, Paid = null, TravelerID = null });
        }

        public bool GetByID(int id)
        {
            InitializeList();
            return bookings.Any(x => x.ID == id);
        }

        public void DisplayByID(int id)
        {
            var item = bookings.SingleOrDefault(x => x.ID == id);
            Console.WriteLine($"ID\tRoomID\tDateCreated\t\tCheckIn\t\t\tCheckOut\t\tGuest\tPaid\tTravelerID");
            Console.WriteLine($"{item.ID}\t{item.RoomID}\t{item.DateCreated}\t{item.CheckIn}\t{item.CheckOut}\t{item.Guest}\t{item.Paid}\t{item.TravelerID}");
        }
    }
}
