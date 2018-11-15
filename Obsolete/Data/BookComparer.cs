using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrarian.Data
{
    class BookComparer : IComparer<Book>
    {

        public enum CompareType 
        {
            authorAsc,
            authorDesc,
            titleAsc,
            titleDesc,
            dateAsc,
            dateDesc

        }
        public CompareType sortBy = CompareType.authorDesc;

        public int Compare(Book book1, Book book2)
        {
            switch (sortBy)
            {
                case CompareType.authorDesc:
                    return -1 * String.Compare(book1.Author, book2.Author);
                case CompareType.titleAsc:
                    return String.Compare(book1.Title, book2.Title);
                case CompareType.titleDesc:
                    return -1 * String.Compare(book1.Title, book2.Title);
                case CompareType.dateAsc:
                    return DateTime.Compare(book1.Date, book2.Date);
                case CompareType.dateDesc:
                    return -1 * DateTime.Compare(book1.Date, book2.Date);
                default:
                    return String.Compare(book1.Author, book2.Author);
            }

        }
        
    }
}
