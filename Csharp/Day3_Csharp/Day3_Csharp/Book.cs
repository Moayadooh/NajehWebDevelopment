using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Csharp
{
    class Book
    {
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public Genre GenreBook { get; set; }

        public static List<Book> GetBooks()
        {
            return new List<Book>()
            {
                new Book{ _Name="Sharlekhomes ", GenreBook = Genre.Action},
                new Book{ _Name="Black Tulips ", GenreBook = Genre.Drama},
                new Book{ _Name="pastchio theory", GenreBook = Genre.Thriller},
                new Book{ _Name="gone with the wind", GenreBook = Genre.War}
            };
        }
    }

    public enum Genre
    {
        Drama, Thriller, War, Action
    }
}
