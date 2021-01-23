using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_Csharp
{
    struct Movie
    {
        public int ID;
        public string Title;
        public string Hero;
        public DateTime release;
        public string Genre;
    }
    class Programm8
    {
        static void Main(string[] args)
        {
            Movie movei1;
            movei1.ID = 10; //set
            movei1.Title = "I am legend";
            movei1.Hero = "Will smith";
            movei1.release = DateTime.Now;
            movei1.Genre = "Horror";
            Console.WriteLine("ID :" + movei1.ID); // get
            Console.WriteLine("Title :" + movei1.Title); // get
            Console.WriteLine("Hero :" + movei1.Hero); // get
            Console.WriteLine("release :" + movei1.release); // get
            Console.WriteLine("Genre :" + movei1.Genre); // get
        }
    }
}
