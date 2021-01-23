using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Csharp
{
    class Employee
    {
        public Employee()
        {
            // Constructor
            Console.WriteLine("Connection Established!!");
        }
        public Employee(string emp)
        {
            // Constructor
            Console.WriteLine("This is " + emp);
        }
        protected int _ID;
        protected string _Name;
        protected string _Code;
        
        // Override function
        public virtual double Getsalary(double amount)
        {
            return amount;
        }

        // Override Property
        public virtual string empcode
        {
            get { return _Code; }
            set { _Code = value; }
        }

        public string getconnection()
        {
            return "load data..";
        }

        ~Employee()
        {
            // destructor
            Console.WriteLine("Connection Closed!!");

        }
    }

    class Developer : Employee
    {
        public Developer() : base("Developer Information") { }

        public int hours { get; set; }
        public int DevID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string DevName
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public override double Getsalary(double amount)
        {
            return base.Getsalary(amount) + hours * 20;
        }
        public override string empcode 
        { get => "Dev-" + Guid.NewGuid().ToString(); 
          //set => base.empcode = value; 
        }
    }
    class Designer : Employee
    {
        public Designer() : base("Designer Information") { }
        public double commision { get; set; }
        public double Sale { get; set; }
        public int DesID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string DesName
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public override double Getsalary(double amount)
        {
            return base.Getsalary(amount) + (Sale * commision)  ;
        }
        public override string empcode 
        { 
            get => "Des-" + Guid.NewGuid().ToString(); 
            set => base.empcode = value; 
        }
    }
}
