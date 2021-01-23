using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_Csharp_Assignment
{
    abstract class HotelsBooking
    {
        public int ID { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        abstract public int GetCount();
        public virtual bool? GetItem(int id)
        {
            return false;
        }
    }
}
