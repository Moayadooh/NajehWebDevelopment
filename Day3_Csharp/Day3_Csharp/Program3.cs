using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Csharp
{
    class Program3
    {
        static void Main(string[] args)
        {
            // List<Book> Books = new List<Book>(); // empty list  or var;
            var Books = new List<Book>(); // empty list ;

            Console.WriteLine("Enter Books Number:");
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                var onebook = new Book();
                Console.WriteLine("Enter Book Name:");
                onebook.Name = Console.ReadLine();
                onebook.GenreBook = Genre.Thriller;
                Books.Add(onebook);
            }

            foreach (var item in Books)
            {
                Console.Write("Book Name :" + item.Name + "\t");
                Console.Write("Book Genre :" + item.GenreBook + "\n");
            }

            foreach (var item in Book.GetBooks())
            {
                Console.Write("Book Name :" + item.Name + "\t");
                Console.Write("Book Genre :" + item.GenreBook + "\n");
            }
        }
    }
}
