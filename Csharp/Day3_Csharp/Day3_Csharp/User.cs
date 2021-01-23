using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Csharp
{
    class User
    {

        public int ID { get; set; }
        public string  Email { get; set; }
        public int  Phone { get; set; }
        public string Password { get; set; }
        
        public List<User> GetUsers()
        {

            return new List<User>()
            {
                new User(){ ID=10,Email="ammar@gmail.com",Password="123",Phone=0785199746 },
                new User(){ ID=11,Email="loay@live.com",Password="1236",Phone=0705199746 },
                new User(){ ID=12,Email="Muayad@outlook.com",Password="1234",Phone=0795199746 },
                new User(){ ID=13,Email="M.zaher@outlook.com",Password="12345",Phone=0745199746 }
            };
        }
        #region loginasone
        public bool Login(string email, string pass)
        {
            bool CheckLogin = false;
            if (email == "ammar" && pass == "123")
            {
                CheckLogin = true;
            }
            return CheckLogin;
        }

        public bool Login(int Phone, string pass)
        {
            bool CheckLogin = false;
            if (Phone == 0785199746 && pass == "123")
            {
                CheckLogin = true;
            }
            return CheckLogin;
        }
        #endregion

        #region loginasmany
        public bool Login2(string email, string pass)
        {
            bool CheckLogin = false;
            foreach (var item in GetUsers())
            {
                if (email == item.Email && pass == item.Password)
                {
                    CheckLogin = true;
                    break;
                }

            }
            return CheckLogin;
        }
        public bool Login2(int Phone, string pass)
        {
            bool CheckLogin = false;
            foreach (var item in GetUsers())
            {
                if (Phone == item.Phone && pass == item.Password)
                {
                    CheckLogin = true;
                    break;
                }

            }
            return CheckLogin;
        }
        #endregion
    }
}
