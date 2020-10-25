using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_practise
{
    class Student
    {
        //int id; //by default the property is private
        public int id;
        public string firstName;
        public string lastName;
        public Student(int id, string firstName, string lastName)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
        }
        //public void setId(int id)
        //{
        //    this.id = id;
        //}
        //public void setfirstName(string firstName)
        //{
        //    this.firstName = firstName;
        //}
        //public void setlastName(string lastName)
        //{
        //    this.lastName = lastName;
        //}
        public int getId()
        {
            return id;
        }
        public string getFirstName()
        {
            return firstName;
        }
        public string getLastName()
        {
            return lastName;
        }
    }
}
