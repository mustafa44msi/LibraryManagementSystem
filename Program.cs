using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using LibraryManagementSystem.Objects;
using System.Globalization;

namespace LibraryManagementSystem
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string choice;
            while (true)
            {
                GetMainMenu();
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        AddBook();
                        break;
                    case "2":
                        Console.Clear();
                        BorrowBook();
                        break;
                    case "3":
                        Console.Clear();
                        ReturnBook();
                        break;
                    case "4":
                        Console.Clear();
                        SearchBook();
                        break;
                    case "5":
                        Console.Clear();
                        Report();
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Hoşcakalın :/");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Geçersiz Seçim");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }

        static void AddBook()
        {
            Console.Clear();
            var Book = ProgramObjects.books;
            Console.WriteLine($"Kitap Ekleme Ekranı\n{new string('-', 20)}");
            Console.Write("Kitap Adı: ");
            string Title = Console.ReadLine();
            Console.Write("Yazar Adı: ");
            string Author = Console.ReadLine();
            Console.Write("Yayın Yılı: ");
            int Year = int.Parse(Console.ReadLine());
            Console.Write("Adet: ");
            int Quantity = int.Parse(Console.ReadLine());

            var newBook = new Book()
            {
                Title = Title,
                Author = Author,
                Year = Year,
                Quantity = Quantity
            };
            Book.Add(newBook);
            Console.WriteLine($"{Title} Adlı Kitap Kitap Başarıyla Eklenmiştir");
        }

        static void BorrowBook()
        {
            Console.Clear();
            Console.WriteLine($"Kitap Kiralama Ekranı\n{new string('-', 20)}");
            Console.WriteLine("Elimizdeki Mevcut Kitaplar\n");
            Console.Write($"{string.Join(new string('-', 20), ProgramObjects.books.Select(x => $"\n\n\nKitap Adı: {x.Title}\nKitabın Yazarı: {x.Author}\nYayınlanma Tarihi: {x.Year}\nStoktaki Adet: {x.Quantity}\n\n"))}\n\nLütfen Seçmek İstediğiniz Kitabın Adını Giriniz: ");
            string Title = Console.ReadLine().ToLower();
            var book = ProgramObjects.books.Find(x => x.Title?.IndexOf(Title, StringComparison.OrdinalIgnoreCase) >= 0);

            if (string.IsNullOrEmpty(Title))
            {
                Console.Clear();
                Console.WriteLine("Geçerli Bir Kitap İsmi Giriniz");
                Thread.Sleep(1000);
                BorrowBook();
            }

            if (book == null)
            {
                Console.Clear();
                Console.WriteLine("Kitap Bulunamadı");
                Thread.Sleep(1000);
                return;
            }

            if (book.Quantity == 0)
            {
                Console.Clear();
                Console.WriteLine("İstediğiniz Kitap Stokta Bulunmamaktadır");
                Thread.Sleep(1000);
                return;
            }

            Console.Clear();
            try
            {
                Console.WriteLine("Kaç Gün Kiralamak İstiyorsunuz: ");
                int Days = int.Parse(Console.ReadLine());
                Console.WriteLine("Lütfen Bütçenizi Girin: ");
                int Budget = int.Parse(Console.ReadLine());

                if (Budget < Days * 5)
                {
                    Console.Clear();
                    Console.WriteLine("Bütçeniz Yeterli Değil");
                    Thread.Sleep(1000);
                    return;
                }

                Console.Clear();
                var loan = new Loan(book, Days);
                ProgramObjects.loans.Add(book.Title, loan);
                book.Quantity--;
                Console.WriteLine($"{book.Title} Adlı Kitap {Days} Gün Kiralanmıştır");
                Thread.Sleep(1000);
            }
            catch (Exception x)
            {
                Console.Clear();
                Console.WriteLine($"{x.Message} Bundan Dolayı İşleminiz Gerçekleştirilememiştir.\nMenüye Dönmek İçin 'Enter' Tuşuna Basınız");
                Console.ReadLine();
                return;
            }
            
        }

        static void ReturnBook()
        {
            Console.Clear();
            Console.WriteLine($"Kitap İade Ekranı\n{new string('-', 20)}");
            Console.WriteLine("İade Edebileceğiniz Kitaplar\n");
            foreach (var item in ProgramObjects.loans)
            {
                Console.WriteLine($"Kitabın Adı: {item.Key}");
                Console.WriteLine($"Kiralanma Süresi {item.Value.Days} Gün");
                Console.WriteLine($"İade Tarihi: {item.Value.ReturnDate}");
                Console.WriteLine(new string('-', 20));
            }

            Console.Write("Lütfen İade Etmek İstediğiniz Kitabın Adını Giriniz: ");
            string Title = Console.ReadLine();

            if (ProgramObjects.loans.ContainsKey(Title))
            {
                var book = ProgramObjects.loans[Title];
                ProgramObjects.books.Find(x => x.Title == Title).Quantity++;
                ProgramObjects.loans.Remove(Title);
                Console.Clear();
                Console.WriteLine($"{Title} Adlı Kitap Başarıyla İade Edilmiştir");
                Thread.Sleep(1000);
                return;
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Kitap Bulunamadı");
                Thread.Sleep(1000);
                return;
            }
        }

        static void SearchBook()
        {
            Console.Clear();
            GetSearchMenu();
            string choice = Console.ReadLine();
            var Book = ProgramObjects.books;

            if (choice == "3" || choice == "quit" || choice == " exit")
            {
                Console.Clear();
                Console.WriteLine("Ana Menüye Dönülüyor");
                Thread.Sleep(1000);
                return;
            }

            else if (choice == "1")
            {
                Console.Clear();
                Console.WriteLine("Kitap Adını Giriniz: ");
                string Title = Console.ReadLine();
                var book = ProgramObjects.books.Find(x => x.Title?.IndexOf(Title, StringComparison.OrdinalIgnoreCase) >= 0);
                if (book == null)
                {
                    Console.WriteLine("Aradğınız Kitap Bulunamadı");
                    return;
                }
                else
                {
                    Console.Clear();
                    Console.Write($"{new string('-', 20)}\n\nKitap Adı: {book.Title}\nYazar Adı: {book.Author}\nYayın Yılı: {book.Year}\nStoktaki Adet: {book.Quantity}\n{new string('-', 20)}\n\nMenüye Dönmek İçin 'Enter' Tuşuna Basın.");
                    Console.ReadLine();
                }
            }

            else if (choice == "2")
            {
                Console.Clear();
                Console.WriteLine("Yazar Adını Giriniz: ");
                string Author = Console.ReadLine();
                var book = ProgramObjects.books.FindAll(x => x.Author?.IndexOf(Author, StringComparison.OrdinalIgnoreCase) >= 0);
                if (book.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Aradığınız Yazara Ait Kitap Bulunamadı");
                    return;
                }
                else
                {
                    Console.Clear();
                    foreach (var item in book)
                    {
                        Console.Write($"{new string('-', 20)}\n\nKitap Adı: {item.Title}\nYazar Adı: {item.Author}\nYayın Yılı: {item.Year}\nStoktaki Adet: {item.Quantity}\n{new string('-', 20)}\n\n");
                    }
                    Console.WriteLine("Menüye Dönmek İçin 'Enter' Tuşuna Basın.");
                    Console.ReadLine();
                }
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Geçersiz Seçim");
                Thread.Sleep(1000);
                SearchBook();
            }
        }

        static void Report()
        {
            Console.Clear();
            GetReportMenu();
            string choice = Console.ReadLine();
            var Book = ProgramObjects.books;
            if (choice == "5" || choice == "quit" || choice == "exit")
            {
                Console.Clear();
                Console.WriteLine("Ana Menüye Dönülüyor");
                Thread.Sleep(1000);
                return;
            }

            else if (choice == "1")
            {
                Console.Clear();
                Console.WriteLine("Kitaplar\n");
                foreach (var item in ProgramObjects.books)
                {
                    Console.Write($"{new string('-', 20)}\n\nKitap Adı: {item.Title}\nYazar Adı: {item.Author}\nYayın Yılı {item.Year}\nStoktaki Adet: {item.Quantity}\n\n");
                }

                Console.Write("Menüye Dönmek İçin 'Enter' Tuşuna Basın");
                Console.ReadLine();
            }

            else if (choice == "2")
            {
                Console.Clear();
                Console.WriteLine("Kiralanan Kitaplar\n");
                foreach (var item in ProgramObjects.loans)
                {
                    Console.Write($"{new string('-', 20)}\n\nKitap Adı: {item.Key}\nKiralama Süresi {item.Value.Days} Gün\nİade Tarihi: {item.Value.ReturnDate}\\n");
                }

                Console.WriteLine("Menüye Dönmek İçin 'Enter' Tuşuna Basın");
                Console.ReadLine();
            }

            else if (choice == "3")
            {
                Console.Clear();
                Console.WriteLine("Yazarın Adını Girin: ");
                string Author = Console.ReadLine();
                var book = ProgramObjects.books.FindAll(x => x.Author?.IndexOf(Author, StringComparison.OrdinalIgnoreCase) >= 0);

                if (book.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Aradığınız Yazara Ait Kitap Bulunamadı");
                    Thread.Sleep(1000);
                    return;
                }

                else
                {
                    Console.Clear();
                    foreach (var item in book)
                    {
                        Console.Write($"{new string('-', 20)}\n\nKitap Adı: {item.Title}\nYazar Adı: {item.Author}\nYayın Yılı: {item.Year}\nStoktaki Adet: {item.Quantity}\n{new string('-', 20)}\n\n");

                    }
                    Console.WriteLine("Menüye Dönmek İçin 'Enter' Tuşuna Basın.");
                    Console.ReadLine();
                }
            }



            else if (choice == "4")
            {
                Console.Clear();
                Console.WriteLine("Yayın Yılını Girin: ");
                int Year = int.Parse(Console.ReadLine());
                var book = Book.FindAll(x => x.Year == Year);

                if (book.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Aradığınız Yayın Yılına Ait Kitap Bulunamadı");
                    Thread.Sleep(1000);
                    return;
                }

                else
                {
                    Console.Clear();
                    foreach (var item in book)
                    {
                        Console.Write($"{new string('-', 20)}\n\nKitap Adı: {item.Title}\nYazar Adı: {item.Author}\nYayın Yılı: {item.Year}\nStoktaki Adet: {item.Quantity}\n{new string('-', 20)}\n\n");
                    }
                    Console.WriteLine("Menüye Dönmek İçin 'Enter' Tuşuna Basın.");
                    Console.ReadLine();
                }
            }
        }

        static void GetMainMenu()
        {
            Console.Clear();
            Console.WriteLine(MainMenuString);
            Console.Write("Ana Sayfa>");
        }

        static void GetSearchMenu()
        {
            Console.Clear();
            Console.WriteLine(SearchMenuString);
            Console.Write("Ana Sayfa>Arama Sayfası>");
        }

        static void GetReportMenu()
        {
            Console.Clear();
            Console.WriteLine(ReportMenuString);
            Console.Write("Ana Sayfa>Raporlama Sayfası>");
        }

        static string MainMenuString => $@"{new string('-', 20)}Kütüphaneye Hoşgeldiniz{new string('-', 20)}
Lütfen Yapmak İstediğiniz İşlemi Seçin

1 - Kitap Ekle
2 - Kitap Kirala
3 - Kitap İade
4 - Kitap Arama
5 - Raporlama
6 - Çıkış
";

        static string SearchMenuString => @$"Kitap Arama Ekranı
{new string('-', 20)}
Lütfen Arama Yapmak İstediğiniz İşlemi Seçin

1 - Kitap Adına Göre 
2 - Yazar Adına Göre
3 - Ana Menüye Dön
";

        static string ReportMenuString => @$"Raporlama Ekranı
{new string('-', 20)}
Lütfen Arama Yapmak İstediğiniz İşlemi Seçin

1 - Tüm Kitapları Listele
2 - Kiralanan Kitapları Listele
3 - Belirli Bir Yazarın Kitaplarını Listele
4 - Belirli Bir Yayın Yılına Ait Kitapları Listele
5 - Ana Menüye Dön
";
    }
}