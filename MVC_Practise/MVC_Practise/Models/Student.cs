using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Practise.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Score { get; set; }
        public DateTime Birth { get; set; }
    }
}