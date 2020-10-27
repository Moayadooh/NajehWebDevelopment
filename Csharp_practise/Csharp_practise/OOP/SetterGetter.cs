using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_practise.OOP
{
    class Employee
    {
        private int _ID;
        private string _Name;
        private Guid _Code;

        //getter and setter by C#
        public int ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }

        //Normal get and set methods
        public void SetCode(Guid Code)
        {
            _Code = Code;
        }
        public Guid GetCode()
        {
            return _Code;
        }
    }
    class SetterGetter
    {
        public void Run()
        {
            Employee employee = new Employee();

            employee.ID = 1;
            employee.Name = "Eyad";
            Console.WriteLine("Employee id: {0}", employee.ID);
            Console.WriteLine("Employee name: {0}", employee.Name);

            employee.SetCode(Guid.NewGuid());
            Console.WriteLine("Employee code: {0}", employee.GetCode());
        }
    }
}
