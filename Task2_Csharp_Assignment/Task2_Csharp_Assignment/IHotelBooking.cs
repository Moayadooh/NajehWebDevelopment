using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_Csharp_Assignment
{
    interface IHotelBooking
    {
        void Add(string x, string y);
        bool GetByID(int id);
        void DisplayByID(int id);
    }
}
