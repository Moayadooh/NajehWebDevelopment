using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MVC_DB_First.ViewModel
{
    public class MiscCode
    {
        public static string PassHasher(string password)
        {
            var encText = Encoding.UTF8.GetBytes(password);
            var hashpass = SHA256.Create().ComputeHash(encText);
            return Convert.ToBase64String(hashpass);
        }
    }
}