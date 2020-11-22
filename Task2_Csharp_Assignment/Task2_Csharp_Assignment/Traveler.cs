using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2_Csharp_Assignment
{
    class Traveler : HotelsBooking, IHotelBooking
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        //public Booking Booking { get; set; }
        //public List<Booking> Bookings { get; set; }

        public override int GetCount()
        {
            if (travelers == null)
                return GetTravelers().Count;
            return travelers.Count;
        }

        public List<Traveler> GetTravelInfo(string nameChar, string emailChar, string phoneDigits)
        {
            var rows = GetTravelers();
            if (!string.IsNullOrEmpty(nameChar))
                rows = rows.Where(x => x.FullName.ToLower().StartsWith(nameChar.ToLower())).ToList();
            if (!string.IsNullOrEmpty(emailChar))
                rows = rows.Where(x => x.Email.ToLower().Contains(emailChar.ToLower())).ToList();
            if (!string.IsNullOrEmpty(phoneDigits))
                rows = rows.Where(x => x.Phone.Substring(4) == phoneDigits).ToList();
            return rows;
        }

        public List<Traveler> GetTravelers()
        {
            return new List<Traveler>()
            {
                new Traveler(){ID = 1, FullName="Eyad", Email="eyad@email.com", Phone = "92201321", Address="s1c515"},
                new Traveler(){ID = 2, FullName="Moayad", Email="moayad@email.com", Phone = "93498751", Address="s48s4"},
                new Traveler(){ID = 3, FullName="Mohanned", Email="mohanned@email.com", Phone = "93658128", Address="dcdac1"},
                new Traveler(){ID = 4, FullName="Mohammed", Email="mohammed@email.com", Phone = "96977812", Address="d5ac5"},
                new Traveler(){ID = 5, FullName="Salim", Email="salim@email.com", Phone = "92122358", Address="adcap"}
            };
        }

        public List<Traveler> travelers = null;
        public void InitializeList()
        {
            if (travelers == null)
            {
                travelers = new List<Traveler>();
                foreach (var item in GetTravelers())
                {
                    travelers.Add(item);
                }
            }
        }

        public int id = 6;
        public void Add(string fullName, string email)
        {
            InitializeList();
            travelers.Add(new Traveler() { ID = id++, FullName = fullName, Email = email });
        }

        public bool GetByID(int id)
        {
            InitializeList();
            return travelers.Any(x => x.ID == id);
        }

        public void DisplayByID(int id)
        {
            var item = travelers.SingleOrDefault(x => x.ID == id);
            Console.WriteLine($"ID\tFullName\tEmail\t\t\tPhone\t\t\tAddress");
            CheckTap(item.FullName, item.Email);
            Console.WriteLine($"{item.ID}\t{item.FullName}\t{tap}{item.Email}\t{tap1}{item.Phone}\t\t{item.Address}");
        }

        public string tap = "";
        public string tap1 = "";
        public void CheckTap(string fullName, string email)
        {
            if (fullName.Length < 8)
                tap = "\t";
            else
                tap = "";
            if (email.Length >= 16)
                tap1 = "";
            else
                tap1 = "\t";
        }
    }
}
