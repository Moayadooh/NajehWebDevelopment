﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day3_MVC.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public decimal Salary { get; set; }
    }
}