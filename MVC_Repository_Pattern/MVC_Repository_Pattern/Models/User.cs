﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Repository_Pattern.Models
{
    public class User
    {
        public int ID { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }
    }
}