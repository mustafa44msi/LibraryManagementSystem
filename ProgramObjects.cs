using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Objects;

namespace LibraryManagementSystem
{
    public class ProgramObjects
    {

        public static Dictionary<string, Loan> loans = new Dictionary<string, Loan>();
        public static List<Book> books { get; set; } = new()
        {
            
            new Book()
            {
                Title = "Bilgisayar Mühendisliğine Giriş",
                Author = "Toros Rıfat Çölkesen",
                Year = 2022,
                Quantity = 5
            },
            new Book()
            {
                Title = "Kürk Mantolu Madonna",
                Author = "Sabahattin Ali",
                Year = 1937,
                Quantity = 3
            },
            new Book()
            {
                Title = "Saatleri Ayarlama Enstitüsü",
                Author = "Ahmet Hamdi Tanpınar",
                Year = 1961,
                Quantity = 2
            },
            new Book()
            {
                Title = "Kuyucaklı Yusuf",
                Author = "Sabahattin Ali",
                Year = 1937,
                Quantity = 1
            }
        };

    }
}
