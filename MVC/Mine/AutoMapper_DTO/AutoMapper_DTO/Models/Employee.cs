using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapper_DTO.Models
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Employee()
        {
            FirstName = "Munib";
            LastName = "Butt";
            StreetAddress = "123 Street One";
            City = "Toronto";
            Province = "Ontario";
            Country = "Canada";
            Email = "test@hotmail.com";
            Phone = "+14161112222";
        }
    }
}
