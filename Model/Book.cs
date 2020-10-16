using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestBookService.Model
{
    public class Book
    {
        private string title;
        private string author;
        private int pageNumber;
        private string isbn13;

        public Book()
        {

        }


        public Book(string title, string author, int pageNumber, string isbn13)
        {
            Title = title;
            Author = author;
            PageNumber = pageNumber;
            Isbn13 = isbn13;
        }

        public string Title
        {
            get { return title; }
            set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Title must consist of two characters at least");
                }

                title = value;
            }
        }


        public string Author { get; set; }

        public int PageNumber
        {
            get { return pageNumber; }
            set
            {
                if (value < 10 || value >= 1000)
                {
                    throw new ArgumentException("Page number should be no shorter than 10 and no longer or equal than 1000");
                }

                pageNumber = value;
            }
        }

        public string Isbn13
        {
            get { return isbn13; }
            set
            {
                if (value.Length < 13 || value.Length > 13)
                {
                    throw new ArgumentException("Isbn should be 13 characters long");
                }

                isbn13 = value;
            }
        }
        public override string ToString()
        {
            return Isbn13 + ":" + Title + ":" + Author + ":" + PageNumber;
        }
    }
    }

