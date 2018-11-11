namespace Microsoft.Library.Core.TestWCFClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using LibraryServiceClient;

    public class Program
    {
        private Books tbl_books = new Books();
        
        private ILibraryService IlibraryService = new LibraryServiceClient.LibraryServiceClient();
        
        static void Main(string[] args)
        {
            Console.WriteLine("Start Calling DAL Test Methods.....");
            Program p = new Program();
            p.AddBooks();
            p.DeleteBook();
            Console.WriteLine("Press Any Key To Exit...");
            Console.ReadLine();
        }

        public void AddBooks()
        {
            tbl_books.Author = "Rahul";
            tbl_books.AvailStatus = true;
            tbl_books.Category = "IT";
            tbl_books.Description = "InfoTech";
            tbl_books.Publisher = "Pearson";
            tbl_books.Title = "Microsoft C++";
            tbl_books.ISBNNumber = "9092323";
            IlibraryService.AddBook(tbl_books);
        }

        public void UpdateBookDetails()
        {
            tbl_books.Author = "ggh";
            tbl_books.AvailStatus = true;
            tbl_books.Category = "IT";
            tbl_books.Description = "HHJJ";
            tbl_books.Publisher = "JJJK";
            tbl_books.Title = "JKJK";
            tbl_books.ISBNNumber = "HJKJJKJ";
            IlibraryService.UpdateBook(tbl_books);
        }

        public void DeleteBook()
        {
            tbl_books.BookId = 301;
            IlibraryService.DeleteBook(tbl_books.BookId);
        }

    }
}
