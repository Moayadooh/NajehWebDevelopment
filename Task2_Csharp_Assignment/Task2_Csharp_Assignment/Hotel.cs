using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2_Csharp_Assignment
{
    class Hotel : HotelsBooking, IHotelBooking
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public int? Rate { get; set; }
        //public Room Room { get; set; }
        //public List<Room> Rooms { get; set; }

        public override int GetCount()
        {
            if(hotels==null)
                return GetHotels().Count;
            return hotels.Count;
        }

        public void StarsGroup()
        {
            var list = GetHotels().GroupBy(x => x.Rate).ToList();
            foreach (var itemKey in list)
            {
                Console.WriteLine("\nRate: " + itemKey.Key + " stars hotel");
                Console.WriteLine($"ID\tName\t\tAddress\t\tStreet\t\tPhone\t\tRate");
                foreach (var item in itemKey)
                {
                    Console.WriteLine($"{item.ID}\t{item.Name}\t\t{item.Address}\t\t{item.Street}\t\t{item.Phone}\t{item.Rate} Stars");
                }
            }
        }

        public void HotelJoinRoom()
        {
            var list = GetHotels().GroupJoin(new Room().GetRooms().Where(x => x.Available == true), h => h.ID, r => r.HotelID, (h, r) => new { hotelName = h.Name, rooms = r }).ToList();
            Console.WriteLine($"Hotel Group Name\tRoom ID\t\tRoom Availability");
            foreach (var item in list)
            {
                foreach (var room in item.rooms)
                {
                    Console.WriteLine($"{item.hotelName}\t\t\t{room.ID}\t\t{room.Available}");
                }
            }
        }

        public List<Hotel> GetHotels()
        {
            return new List<Hotel>()
            {
                new Hotel(){ID = 1, Phone = "96430801", Address="sd1d515", Name="Family", Street="354", Rate=4},
                new Hotel(){ID = 2, Phone = "91541821", Address="ds51sdc", Name="Barka", Street="882", Rate=5},
                new Hotel(){ID = 3, Phone = "96123784", Address="515dc1s", Name="Relax ", Street="224", Rate=5}
            };
        }

        public List<Hotel> hotels = null;
        public void InitializeList()
        {
            if (hotels == null)
            {
                hotels = new List<Hotel>();
                foreach (var item in GetHotels())
                {
                    hotels.Add(item);
                }
            }
        }

        public int id = 4;
        public void Add(string name, string address)
        {
            InitializeList();
            hotels.Add(new Hotel() { ID = id++, Phone = null, Address = address, Name = name, Street = null, Rate = null });
        }

        public bool GetByID(int id)
        {
            InitializeList();
            return hotels.Any(x => x.ID == id);
        }

        public void DisplayByID(int id)
        {
            var item = hotels.SingleOrDefault(x => x.ID == id);
            Console.WriteLine($"ID\tName\t\tAddress\t\tStreet\t\tPhone\t\tRate(Stars)");
            Console.WriteLine($"{item.ID}\t{item.Name}\t\t{item.Address}\t\t{item.Street}\t\t{item.Phone}\t{item.Rate}");
        }
    }
}
