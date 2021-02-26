using System;

namespace WebAPI_JWT.Controllers
{
    internal class UserModel
    {
        public string Username { get; set; }

        public string EmailAddress { get; set; }

        public DateTime DateOfJoing { get; set; }
    }
}