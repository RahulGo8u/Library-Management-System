using Microsoft.Library.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Microsoft.Library.WCFService.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILibraryService" in both code and config file together.
    [ServiceContract]
    public interface ILibraryService
    {
        //Master Methods
     
        //ADD BOOK
        [OperationContract]
        int AddBook(Books books);

        //ADD CATEGORY
        [OperationContract]
        int AddCategory(Categories addcategory);

        //ADD MEMBER
        [OperationContract]        
        int AddMember(Users users);

        //UPDATE BOOK
        [OperationContract]
        int UpdateBook(Books books);

        //UPDATE MEMBER DETAILS
        [OperationContract]
        int UpdateMemberDetails(Users users);

        //DELETE MEMBER
        [OperationContract]
        int DeleteMember(int userID);

        //Delete Book
        [OperationContract]        
        int DeleteBook(int bookId);        

        //GET ALL CATEGORIES
        [OperationContract]        
        List<Categories> GetAllCategories();

        //GET ALL TRANSACTIONS
        [OperationContract]        
        List<Transaction> GetAllTransaction();

        //GET DETAILS TO UPDATE BOOK
        [OperationContract]
        Books GetBookDetails(int bookId);
        
        //GET DETAILS TO UPDATE MEMBER
        [OperationContract]
        Users GetMemberDetails(int userId);

        //GET DETAILS TO RETURN BOOK
        [OperationContract]
        Transaction GetReturnDetails(int bookId);

        //GET SELF TRANSACTIONS
        [OperationContract]
        List<Transaction> GetSelfTransaction(int userId);

        //SEARCH BOOKS
        [OperationContract]
        List<Books> SearchBooks(string columnName, string searchItems);

        //Check Member Availibility
        [OperationContract]
        int CheckMemberAvlblty(int userID);
        
        //Check Member Availibility for Deleting
        [OperationContract]
        int CheckMemberAvailability(int userID);
        //Check Book Availbility
        [OperationContract]
        int CheckBookAvailibility(int bookId);

        //Check Book Availbility for Deleting
        [OperationContract]
        int CheckBookAvlblty(int bookId);

        //Check Book Availbility for Issue
        [OperationContract]
        int CheckBookAvlbltyIssue(int bookId);
        //ISSUE BOOK
        [OperationContract]
        int IssueBook(Transaction issue);
        
        //RETURN BOOK
        [OperationContract]
        int ReturnBook(Transaction returnBook);

        //Login Details
        [OperationContract]
        Users Login(int userId, string password);

        //Authentication Details
        [OperationContract]
        Users GetAuthenticationDetails(string emailId);
    }

    [DataContract]
    public class Books
    {
        [DataMember]
        public int BookId { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Publisher { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public string ISBNNumber { get; set; }
        [DataMember]
        public Nullable<System.Boolean> AvailStatus { get; set; }
    }

    [DataContract]
    public class Categories
    {
        [DataMember]
        public int CategoryId { get; set; }

        [DataMember]
        public string Category { get; set; }
    }

    [DataContract]
    public class Roles
    {
        [DataMember]
        public int RoleId { get; set; }

        [DataMember]
        public string Role { get; set; }
    }

    [DataContract]
    public class Transaction
    {
        [DataMember]
        public int TransactionId { get; set; }

        [DataMember]
        public Nullable<int> UserId { get; set; }

        [DataMember]
        public Nullable<int> BookId { get; set; }

        [DataMember]
        public System.DateTime IssueDate { get; set; }

        [DataMember]
        public System.DateTime DueDate { get; set; }

        [DataMember]
        public Nullable<System.DateTime> ReturnDate { get; set; }

        [DataMember]
        public virtual tbl_Books tbl_Books { get; set; }

        [DataMember]
        public virtual tbl_Users tbl_Users { get; set; }
    }

    [DataContract]
    public class Users
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public System.DateTime DOB { get; set; }

        [DataMember]
        public string MobileNo { get; set; }

        [DataMember]
        public string EmailId { get; set; }

        [DataMember]
        public Nullable<int> RoleId { get; set; }
    }
}
