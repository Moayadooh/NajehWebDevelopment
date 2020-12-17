using MVC_Repository_Pattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Repository_Pattern.GenericRepo
{
    public interface IUserRepo : IRepository<User>
    {
        User GetUser(string email);

        User GetLogin(string email, string pass);

        void Insert(User user);
    }
}