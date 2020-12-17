using MVC_Repository_Pattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MVC_Repository_Pattern.GenericRepo
{
    public class UserRepo : Repository<User>, IUserRepo
    {
        public User GetLogin(string email, string pass)
        {
            var data = Table.SingleOrDefault(x => x.Email == email && x.Password == pass);
            return data;
        }

        public User GetUser(string email)
        {
            return Table.SingleOrDefault(x => x.Email == email);
        }

        public void Insert(User user)
        {
            var hashpass = GetHash(user.Password);
            user.Password = hashpass;
            Add(user);
        }

        public string GetHash(string pass)
        {
            var stringofbyte = Encoding.UTF8.GetBytes(pass);
            var hashbytes = SHA1.Create().ComputeHash(stringofbyte);
            return Convert.ToBase64String(hashbytes);
        }
    }
}