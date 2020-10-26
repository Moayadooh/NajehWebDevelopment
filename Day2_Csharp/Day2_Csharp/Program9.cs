using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_Csharp
{
    struct Movie2020
    {
        private int ID;
         string Title;
         string Hero;
         DateTime Release;
         string Genre;

        public void Assigns(int id, string title, string hero, DateTime release, string genre)
        {
            ID = id;
            Title = title;
            Hero = hero;
            Release = release;
            Genre = genre;
        }

        public void Display()
        {
            Console.WriteLine("ID :" + ID); // get
            Console.WriteLine("Title :" + Title); // get
            Console.WriteLine("Hero :" + Hero); // get
            Console.WriteLine("release :" + Release); // get
            Console.WriteLine("Genre :" + Genre); // get
        }
    }
    class Program9
    {
        static void Main(string[] args)
        {
            Movie2020 mov = new Movie2020();
          
            //mov.Assigns(215, "300", "forget", DateTime.Now, "Action");
            //mov.Display();
            //mov.Assigns(216, "300", "forget", DateTime.Now, "Action");
            //mov.Display();
            Console.WriteLine("Enter numbers of movies:");
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine("Enter an id");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter title");
                var title = Console.ReadLine();
                Console.WriteLine("Enter hero name");
                var hero = Console.ReadLine();
                Console.WriteLine("Enter date");
                var release = DateTime.Parse( Console.ReadLine());
                Console.WriteLine("Enter genre");
                var genre = Console.ReadLine();
                mov.Assigns(id, title, hero, release, genre);
                mov.Display();
            }

        }
    }
}
