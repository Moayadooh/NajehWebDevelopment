using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Csharp
{
    class Student
    {
        private  int _ID; //access to db record
        private  string _Name; // access to db record
        private  Guid _Code; // access to db record

        // Getter Setter by Property
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        // Getter Setter by Property
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        // Getter Setter by function
        public Guid GetCode()
        {
            return _Code;
        }

        public void SetCode(Guid g)
        {
            _Code = g;
        }
    }
}
