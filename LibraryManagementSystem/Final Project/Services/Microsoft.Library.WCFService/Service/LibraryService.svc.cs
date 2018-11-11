using Microsoft.Library.Core.DAL.UnitOfWorks;
using Microsoft.Library.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Microsoft.Library.WCFService.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LibraryService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LibraryService.svc or LibraryService.svc.cs at the Solution Explorer and start debugging.
    public class LibraryService : ILibraryService
    {

        /// <summary>
        /// Add Book
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        public int AddBook(Books books)
        {
            tbl_Books tbl_books = new tbl_Books();
            using (IUnitOfWorks unitOfWorks = new UnitOfWorks())
                try
                {
                    tbl_books.Author = books.Author;
                    tbl_books.AvailStatus = books.AvailStatus;
                    //tbl_books.BookId = books.BookId;
                    tbl_books.Category = books.Category;
                    tbl_books.Description = books.Description;
                    tbl_books.ISBNNumber = books.ISBNNumber;
                    tbl_books.Title = books.Title;
                    tbl_books.Price = books.Price;
                    tbl_books.Publisher = books.Publisher;
                    tbl_books.AvailStatus = true;
                    unitOfWorks.BookRepository.Insert(tbl_books);
                    unitOfWorks.Save();
                    return 1;
                }

                catch (Exception ex)
                {
                    return 0;
                }
        }

        /// <summary>
        /// Add Category
        /// </summary>
        /// <param name="categories"></param>
        /// <returns></returns>
        public int AddCategory(Categories categories)
        {
            tbl_Category tbl_category = new tbl_Category();
            using (IUnitOfWorks unitOfWorks = new UnitOfWorks())
                try
                {
                    var result = unitOfWorks.CategoryRepository.GetByID(x => x.Category == categories.Category);
                    if (result == null)
                    {
                        tbl_category.Category = categories.Category;
                        //tbl_category.CategoryId = categories.CategoryId;
                        unitOfWorks.CategoryRepository.Insert(tbl_category);
                        unitOfWorks.Save();
                        return 1;
                    }
                    else
                        return 0;
                }

                catch (Exception ex)
                {
                    return -99;
                }
        }

        /// <summary>
        /// Add Member
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public int AddMember(Users users)
        {
            tbl_Users tbl_users = new tbl_Users();
            using (IUnitOfWorks unitOfWorks = new UnitOfWorks())
                try
                {
                    tbl_users.DOB = users.DOB;
                    tbl_users.EmailId = users.EmailId;
                    tbl_users.FirstName = users.FirstName;
                    tbl_users.LastName = users.LastName;
                    tbl_users.MobileNo = users.MobileNo;
                    tbl_users.Password = "Infy@123";
                    tbl_users.RoleId = users.RoleId;
                    unitOfWorks.UserRepository.Insert(tbl_users);
                    unitOfWorks.Save();
                    return 1;
                }
                catch (Exception ex)
                {
                    return 0;
                }
        }

        /// <summary>
        /// Update Book
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        public int UpdateBook(Books books)
        {
            tbl_Books updateBook = new tbl_Books();
            using (IUnitOfWorks unitOfWorks = new UnitOfWorks())
                try
                {


                    updateBook.Author = books.Author;
                    updateBook.AvailStatus = books.AvailStatus;
                    updateBook.Category = books.Category;
                    updateBook.Description = books.Description;
                    updateBook.ISBNNumber = books.Description;
                    updateBook.Title = books.Title;
                    updateBook.Price = books.Price;
                    updateBook.Publisher = books.Publisher;
                    updateBook.BookId = books.BookId;
                    unitOfWorks.BookRepository.Update(updateBook);
                    unitOfWorks.Save();
                    return 1;

                }
                catch (Exception ex)
                {
                    return 0;
                }
        }

        /// <summary>
        /// Update Member details
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public int UpdateMemberDetails(Users users)
        {
            tbl_Users tbl_users = new tbl_Users();
            using (IUnitOfWorks unitOfWorks = new UnitOfWorks())
                try
                {
                    //    tbl_Users updateMember = tbl_Users.Single(User => User.userId == userId);
                    tbl_users.DOB = users.DOB;
                    tbl_users.EmailId = users.EmailId;
                    tbl_users.FirstName = users.FirstName;
                    tbl_users.LastName = users.LastName;
                    tbl_users.MobileNo = users.MobileNo;
                    tbl_users.Password = users.Password;
                    tbl_users.RoleId = users.RoleId;
                    tbl_users.UserId = users.UserId;

                    unitOfWorks.UserRepository.Update(tbl_users);
                    unitOfWorks.Save();
                    return 1;

                }
                catch (Exception ex)
                {
                    return 0;
                }
        }

        /// <summary>
        /// Delete Book
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public int DeleteBook(int bookId)
        {
            using (IUnitOfWorks unitOfWorks = new UnitOfWorks())
                try
                {
                    var result = unitOfWorks.TransactionRepository.GetDetailsbyId(bookId).ToList();
                    if (result != null)
                    {
                        result.ToList().ForEach(c =>
                    {
                        Transaction transaction = new Transaction();

                        {
                            transaction.TransactionId = c.TransactionId;
                            unitOfWorks.TransactionRepository.Delete(transaction.TransactionId);
                            unitOfWorks.Save();
                        }

                    });
                    }
                    unitOfWorks.BookRepository.Delete(bookId);
                    unitOfWorks.Save();
                    return 1;
                }
                catch (Exception ex)
                {
                    return 0;
                }
        }

        /// <summary>
        /// Delete Member
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int DeleteMember(int userID)
        {
            using (IUnitOfWorks unitOfWorks = new UnitOfWorks())
                try
                {

                    var result = unitOfWorks.TransactionRepository.GetDetailsbyUserId(userID).ToList();
                    if (result != null)
                    {
                        //var transaction = unitOfWorks.TransactionRepository.GetByID(user => user.UserId == userID && user.ReturnDate != null);
                        //if (transaction != null)
                        //{
                        //    unitOfWorks.TransactionRepository.Delete(transaction.TransactionId);
                        //    unitOfWorks.UserRepository.Delete(userID);
                        //    unitOfWorks.Save();
                        //    return 1;
                        //}

                        result.ToList().ForEach(c =>
                   {
                       Transaction transaction = new Transaction();

                       {
                           transaction.TransactionId = c.TransactionId;
                           unitOfWorks.TransactionRepository.Delete(transaction.TransactionId);
                           unitOfWorks.Save();
                       }

                   });

                    }
                    unitOfWorks.UserRepository.Delete(userID);
                    unitOfWorks.Save();
                    return 1;
                }
                catch (Exception ex)
                {
                    return -99;
                }
        }

        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <returns></returns>
        public List<Categories> GetAllCategories()
        {
            List<Categories> lstcategories = new List<Categories>();

            using (IUnitOfWorks unitOfWorks = new UnitOfWorks())
            {
                var result = unitOfWorks.CategoryRepository.GetAllCategory().ToList();

                result.ToList().ForEach(c =>
                {
                    Categories categories = new Categories();
                    categories.Category = c.Category;
                    categories.CategoryId = c.CategoryId;
                    lstcategories.Add(categories);
                });
            }
            return lstcategories;
        }

        /// <summary>
        /// Get All Transactions
        /// </summary>
        /// <returns></returns>
        public List<Transaction> GetAllTransaction()
        {
            List<Transaction> lsttransaction = new List<Transaction>();

            using (IUnitOfWorks unitOfWorks = new UnitOfWorks())
            {
                var result = unitOfWorks.TransactionRepository.GetAllTransaction().ToList();

                result.ToList().ForEach(c =>
                {
                    Transaction transaction = new Transaction();
                    transaction.BookId = c.BookId;
                    transaction.DueDate = c.DueDate;
                    transaction.IssueDate = c.IssueDate;
                    transaction.ReturnDate = c.ReturnDate;
                    transaction.TransactionId = c.TransactionId;
                    transaction.UserId = c.UserId;
                    lsttransaction.Add(transaction);
                });
            }
            return lsttransaction;
        }

        /// <summary>
        /// Get Self Transactions
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Transaction> GetSelfTransaction(int userId)
        {
            List<Transaction> lsttransaction = new List<Transaction>();

            using (IUnitOfWorks unitOfWorks = new UnitOfWorks())
            {
                var result = unitOfWorks.TransactionRepository.GetSelfTransaction(userId).ToList();
                result.ToList().ForEach(c =>
                    {
                        Transaction transaction = new Transaction();
                        transaction.BookId = c.BookId;
                        transaction.DueDate = c.DueDate;
                        transaction.IssueDate = c.IssueDate;
                        transaction.ReturnDate = c.ReturnDate;
                        transaction.TransactionId = c.TransactionId;
                        transaction.UserId = c.UserId;
                        lsttransaction.Add(transaction);
                    });
            }
            return lsttransaction;
        }

        /// <summary>
        /// Get Book Details
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public Books GetBookDetails(int bookId)
        {
            Books books = new Books();
            using (IUnitOfWorks unitOfWorks = new UnitOfWorks())
            {
                var result = unitOfWorks.BookRepository.GetByID(x => x.BookId == bookId);
                if (result != null)
                {
                    books.Author = result.Author;
                    books.AvailStatus = result.AvailStatus;
                    books.BookId = result.BookId;
                    books.Category = result.Category;
                    books.Description = result.Description;
                    books.ISBNNumber = result.Description;
                    books.Title = result.Title;
                    books.Price = result.Price;
                    books.Publisher = result.Publisher;

                }
            }
            return books;
        }

        /// <summary>
        /// Get Member Details
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Users GetMemberDetails(int userId)
        {
            Users users = new Users();
            using (IUnitOfWorks unitOfWorks = new UnitOfWorks())
            {
                var result = unitOfWorks.UserRepository.GetByID(x => x.UserId == userId);
                if (result != null)
                {
                    users.DOB = result.DOB;
                    users.EmailId = result.EmailId;
                    users.FirstName = result.FirstName;
                    users.LastName = result.LastName;
                    users.MobileNo = result.MobileNo;
                    users.Password = result.Password;
                    users.RoleId = result.RoleId;
                    users.UserId = result.UserId;
                }
            }
            return users;
        }

        /// <summary>
        /// Get Return Book Details
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public Transaction GetReturnDetails(int bookId)
        {
            Transaction transaction = new Transaction();
            using (IUnitOfWorks unitOfWorks = new UnitOfWorks())
            {
                var result = unitOfWorks.TransactionRepository.GetByID(x => x.BookId == bookId && x.ReturnDate == null);
                if (result != null)
                {
                    transaction.BookId = result.BookId;
                    transaction.DueDate = result.DueDate;
                    transaction.IssueDate = result.IssueDate;
                    transaction.ReturnDate = result.ReturnDate;
                    transaction.TransactionId = result.TransactionId;
                    transaction.UserId = result.UserId;
                }
                //unitOfWorks.Save();
            }
            return transaction;
        }


        /// <summary>
        /// Check User Availibility
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int CheckMemberAvlblty(int userID)
        {
            Users users = new Users();
            {
                using (IUnitOfWorks unitOfWorks = new UnitOfWorks())
                {
                    try
                    {
                        var searchMember = unitOfWorks.UserRepository.GetByID(user => user.UserId == userID);

                        if (searchMember != null)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        return 0;
                    }
                }
            }
        }

        public int CheckMemberAvailability(int userID)
        {
            Users users = new Users();
            {
                using (IUnitOfWorks unitOfWorks = new UnitOfWorks())
                {                    
                    try
                    {
                        var searchMember = unitOfWorks.TransactionRepository.GetDetailsbyUserId(userID).ToList();
                        //BookRepository.GetByID(Book => Book.BookId == bookId && Book.AvailStatus == false);
                        if (searchMember != null)
                        {
                            List<tbl_Transaction> lsttransacion = new List<tbl_Transaction>();
                            lsttransacion = searchMember.Where(x => x.ReturnDate == null).ToList();
                            if (lsttransacion.Count > 0)
                            {
                                return 0;
                            }
                            else
                            {
                                return 1;
                            }
                        }
                        else
                        {
                            return 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        return -99;
                    }                    
                }
            }
        }

        /// <summary>
        /// Check Book Availibility 
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public int CheckBookAvailibility(int bookId)
        {
            Books book = new Books();
            {
                using (IUnitOfWorks unitOfWorks = new UnitOfWorks())
                {
                    try
                    {
                        var searchBook = unitOfWorks.BookRepository.GetByID(Book => Book.BookId == bookId);

                        if (searchBook != null)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        return 0;
                    }
                }
            }
        }

        /// <summary>
        /// Check Book Status for Deleting
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public int CheckBookAvlblty(int bookId)
        {
            Books book = new Books();
            {
                using (IUnitOfWorks unitOfWorks = new UnitOfWorks())
                {
                    try
                    {
                        var searchBook = unitOfWorks.BookRepository.GetByID(Book => Book.BookId == bookId && Book.AvailStatus == false);

                        if (searchBook == null)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        return -99;
                    }
                }
            }
        }


        /// <summary>
        /// Check Book Status for Deleting
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public int CheckBookAvlbltyIssue(int bookId)
        {
            Books book = new Books();
            {
                using (IUnitOfWorks unitOfWorks = new UnitOfWorks())
                {
                    try
                    {
                        var searchBook = unitOfWorks.BookRepository.GetByID(Book => Book.BookId == bookId && Book.AvailStatus == true);

                        if (searchBook != null)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        return -99;
                    }
                }
            }
        }

        /// <summary>
        /// Issue Book
        /// </summary>
        /// <param name="issue"></param>
        /// <returns></returns>
        public int IssueBook(Transaction issue)
        {
            tbl_Transaction tbl_transaction = new tbl_Transaction();

            using (IUnitOfWorks unitOfWorks = new UnitOfWorks())
                try
                {
                    var searchbook = unitOfWorks.BookRepository.GetByID(book => book.BookId == issue.BookId && book.AvailStatus == true);
                    if (searchbook != null)
                    {
                        tbl_transaction.BookId = issue.BookId;
                        tbl_transaction.DueDate = issue.DueDate;
                        tbl_transaction.IssueDate = issue.IssueDate;
                        tbl_transaction.ReturnDate = issue.ReturnDate;
                        tbl_transaction.TransactionId = issue.TransactionId;
                        tbl_transaction.UserId = issue.UserId;
                        unitOfWorks.TransactionRepository.Insert(tbl_transaction);
                        unitOfWorks.Save();

                        var UpdateBook = unitOfWorks.BookRepository.GetByID(Book => Book.BookId == tbl_transaction.BookId);
                        UpdateBook.AvailStatus = false;
                        unitOfWorks.Save();
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    return -99;
                }
        }

        /// <summary>
        /// Return Book
        /// </summary>
        /// <param name="returnBook"></param>
        /// <returns></returns>
        public int ReturnBook(Transaction returnBook)
        {
            tbl_Transaction tbl_transaction = new tbl_Transaction();
            using (IUnitOfWorks unitOfWorks = new UnitOfWorks())
                try
                {
                    var searchbook = unitOfWorks.BookRepository.GetByID(book => book.BookId == returnBook.BookId && book.AvailStatus == false);
                    if (searchbook != null)
                    {
                        var transaction = unitOfWorks.TransactionRepository.GetByID(book => book.BookId == returnBook.BookId && book.ReturnDate == null);
                        transaction.ReturnDate = returnBook.ReturnDate;
                        unitOfWorks.Save();

                        var UpdateBook = unitOfWorks.BookRepository.GetByID(Book => Book.BookId == transaction.BookId);
                        UpdateBook.AvailStatus = true;
                        unitOfWorks.Save();
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    return 0;
                }
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Users Login(int userId, string password)
        {
            Users users = new Users();
            using (IUnitOfWorks unitOfWorks = new UnitOfWorks())
            {
                var result = unitOfWorks.UserRepository.Login(userId, password);
                if (result != null)
                {
                    users.FirstName = result.FirstName;
                    users.LastName = result.LastName;
                    users.RoleId = result.RoleId;
                    users.EmailId = result.EmailId;
                    users.UserId = result.UserId;
                    users.Password = result.Password;
                }
            }
            return users;
        }

        /// <summary>
        /// Get Authentication Details
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns></returns>
        public Users GetAuthenticationDetails(string emailId)
        {
            Users users = new Users();

            using (IUnitOfWorks unitOfWorks = new UnitOfWorks())
            {
                var result = unitOfWorks.UserRepository.GetByID(x => x.EmailId == emailId);
                if (result != null)
                {
                    users.UserId = result.UserId;
                    users.Password = result.Password;
                    //users.DOB = users.DOB;
                    //users.EmailId = users.EmailId;
                    //users.FirstName = users.FirstName;
                    //users.LastName = users.LastName;
                    //users.MobileNo = users.MobileNo;
                    //users.RoleId = users.RoleId;
                    //unitOfWorks.Save();
                }
            }
            return users;
        }

        /// <summary>
        /// Search Books
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="searchItems"></param>
        /// <returns></returns>
        public List<Books> SearchBooks(string columnName, string searchItems)
        {
            List<Books> lstbooks = new List<Books>();

            using (IUnitOfWorks unitOfWorks = new UnitOfWorks())
            {
                var result = unitOfWorks.BookRepository.SearchBooks(columnName, searchItems).ToList();

                result.ToList().ForEach(c =>
                {
                    Books books = new Books();
                    books.Title = c.Title;
                    books.Author = c.Author;
                    books.Category = c.Category;
                    books.Description = c.Description;
                    books.ISBNNumber = c.ISBNNumber;
                    books.Publisher = c.Publisher;
                    books.AvailStatus = c.AvailStatus;
                    books.BookId = c.BookId;
                    lstbooks.Add(books);
                });
            }
            return lstbooks;
        }
    }
}
