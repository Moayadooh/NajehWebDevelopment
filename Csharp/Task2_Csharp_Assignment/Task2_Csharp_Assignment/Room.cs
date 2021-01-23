using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2_Csharp_Assignment
{
    class Room : HotelsBooking, IHotelBooking
    {
        public int Number { get; set; }
        public bool? Available { get; set; }
        public double Price { get; set; }
        public int? HotelID { get; set; }
        //public Hotel Hotel { get; set; }
        //public Booking Booking { get; set; }
        //public List<Booking> Bookings { get; set; }

        public override int GetCount()
        {
            if (rooms == null)
                return GetRooms().Count;
            return rooms.Count;
        }

        public override bool? GetItem(int id)
        {
            var row = GetRooms().SingleOrDefault(x => x.ID == id);
            if (row != null)
                return row.Available;
            else
                return null;
        }

        public List<Room> GetRoomByPrice(double min, double max)
        {
            var list = GetRooms().Where(x => x.Price >= min && x.Price <= max).ToList();
            var rows = new List<Room>();
            foreach (var item in list)
            {
                rows.Add(item);
            }
            return rows;
        }

        public string PriceRanking(double price)
        {
            if (price > 1000)
                return "Expensive!!";
            if (price >= 300 && price <= 700)
                return "Fair enough!";
            return "Not valid!";
        }

        public void PriceRankGroup()
        {
            var rows = GetRooms().ToLookup(x => x.PriceRanking(x.Price)).ToList();
            foreach (var itemKey in rows)
            {
                Console.WriteLine("\nCategory: " + itemKey.Key);
                Console.WriteLine($"ID\tNumber\t\tAvailable\tPrice\t\tHotelID\t\tPhone");
                foreach (var item in itemKey)
                {
                    Console.WriteLine($"{item.ID}\t{item.Number}\t\t{item.Available}\t\t{item.Price}\t\t{item.HotelID}\t\t{item.Phone}");
                }
            }
        }

        public List<Room> GetRooms()
        {
            return new List<Room>()
            {
                new Room(){ID = 150, Number=101, Available=true, Price=455.5, HotelID=1, Phone = "96430801"},
                new Room(){ID = 151, Number=102, Available=true, Price=700.5, HotelID=1, Phone = "91541821"},
                new Room(){ID = 399, Number=381, Available=true, Price=320.0, HotelID=2, Phone = "96123784"},
                new Room(){ID = 355, Number=225, Available=true, Price=100.0, HotelID=3, Phone = "97411258"},
                new Room(){ID = 356, Number=226, Available=false, Price=1000.5, HotelID=3, Phone = "93197825"}
            };
        }

        public List<Room> rooms = null;
        public void InitializeList()
        {
            if (rooms == null)
            {
                rooms = new List<Room>();
                foreach (var item in GetRooms())
                {
                    rooms.Add(item);
                }
            }
        }

        static Random random = new Random();
        public int id = random.Next(10, 50);
        public void Add(string number, string price)
        {
            InitializeList();
            rooms.Add(new Room() { ID = id, Number = int.Parse(number), Available = null, Price = double.Parse(price), HotelID = null, Phone = null });
        }

        public bool GetByID(int id)
        {
            InitializeList();
            return rooms.Any(x => x.ID == id);
        }

        public void DisplayByID(int id)
        {
            var item = rooms.SingleOrDefault(x => x.ID == id);
            Console.WriteLine($"ID\tNumber\t\tAvailable\tPrice\t\tHotelID\t\tPhone");
            Console.WriteLine($"{item.ID}\t{item.Number}\t\t{item.Available}\t\t{item.Price}\t\t{item.HotelID}\t\t{item.Phone}");
        }
    }
}
