using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practical_Project_2.ViewModel
{
    public class UserPurchaseViewModel
    {
        public Guid UserID { get; set; }

        public int NumOfItems { get; set; }

        public double TotalPrice { get; set; }

        public string Date { get; set; }
    }
}