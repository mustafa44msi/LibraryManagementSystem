using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Objects
{
    public class Book
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int Year { get; set; }
        public int Quantity { get; set; }
    }
}
