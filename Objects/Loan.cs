using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibraryManagementSystem.Objects
{
    public class Loan
    {
        public Book Book { get; set; }
        public int Days { get; set; }
        public string User { get; set; }
        public DateTime ReturnDate { get; set; }

        public Loan(Book book, int days)
        {
            Book = book;
            Days = days;
            User = "Kullanıcı";
            ReturnDate = DateTime.Now.AddDays(days);
        }

    }
}
