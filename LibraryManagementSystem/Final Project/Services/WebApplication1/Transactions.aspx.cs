using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCFService = WebApplication1.LibraryServiceClient;

namespace WebApplication1
{
    public partial class Transactions : System.Web.UI.Page
    {
        private WCFService.ILibraryService IlibraryService = new LibraryServiceClient.LibraryServiceClient();
        private WCFService.Books books = new WCFService.Books();
        private WCFService.Categories category = new WCFService.Categories();
        private WCFService.Transaction transaction = new WCFService.Transaction();

        /// <summary>
        /// PAGE LOAD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                lblGetReturnDetails.Visible = false;
                lblReturnBook.Visible = false;
                lblBookAvlblty.Visible = false;
                lblIssueBook.Visible = false;
                lblMemberAvlblty.Visible = false;

                var lstTransaction = IlibraryService.GetAllTransaction();
                gvAllTransactions.DataSource = lstTransaction;
                gvAllTransactions.DataBind();
                gvAllTransactions.Visible = false;
            }            
        }

        /// <summary>
        /// Check Book Availability
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCheckBookAvlblty_Click(object sender, EventArgs e)
        {
            try
            {
                int bookId = Convert.ToInt32(txtBookIdIssue.Text);
                int result = IlibraryService.CheckBookAvlbltyIssue(bookId);
                if (result == 1)
                {
                    lblBookAvlblty.Text = "Book is Available";
                    txtBookIdIssue.Enabled = false;
                    lblBookAvlblty.Visible = true;
                    //pnlProceedToIssue.Visible = true;
                    
                }
                else
                {
                    lblBookAvlblty.Text = "Book is not Available, Please Enter valid BookId";
                    lblBookAvlblty.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }
        }

        /// <summary>
        /// Check Member Availability
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CheckMemberAvlblty_Click(object sender, EventArgs e)
        {
            try
            {
                int userId = Convert.ToInt32(txtUserIdIssue.Text);
                int result = IlibraryService.CheckMemberAvlblty(userId);
                if (result == 1)
                {
                    lblMemberAvlblty.Text = "User is Available";
                    lblMemberAvlblty.Visible = true;
                    //pnlIssueBook.Visible = true;
                    txtIssueDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    txtIssueDate.Enabled = false;
                    txtDueDate.Text = DateTime.Now.AddDays(10).ToString("yyyy-MM-dd");
                    txtDueDate.Enabled = false;
                }
                else
                {
                    lblMemberAvlblty.Text = "User is not Available, Please Enter valid UserId";
                    lblMemberAvlblty.Visible = true;
                    // pnlIssueBook.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }

        }

        
        /// <summary>
        /// ISSUE BOOK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIssueBook_Click(object sender, EventArgs e)
        {
            try
            {
                transaction.BookId = Convert.ToInt32(txtBookIdIssue.Text);
                transaction.UserId = Convert.ToInt32(txtUserIdIssue.Text);
                transaction.IssueDate = DateTime.Now;
                transaction.DueDate = DateTime.Now.AddDays(10);
                int result = IlibraryService.IssueBook(transaction);
                if (result == 1)
                {
                    lblIssueBook.Text = "Book Issued successfully";
                    lblIssueBook.Visible = true;
                }
                else if (result == 0)
                {
                    lblIssueBook.Text = "Book is already issued";
                    lblIssueBook.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }
        }

        /// <summary>
        /// GET DETAILS FOR RETURNING BOOK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGetDetailsReturnBook_Click(object sender, EventArgs e)
        {
            try
            {
                int bookId = Convert.ToInt32(txtBookIdReturn.Text);
                var result = IlibraryService.GetReturnDetails(bookId);
                if (result.BookId != null)
                {
                    if (result.ReturnDate == null)
                    {
                        lblGetReturnDetails.Text = "Proceed to Return";
                        txtReturnDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                        txtReturnDate.Enabled = false;
                        lblGetReturnDetails.Visible = true;
                    }
                    else
                    {
                        lblGetReturnDetails.Text = "Book is not yet issued";
                        lblGetReturnDetails.Visible = true;
                    }
                }
                else
                {                    
                    lblGetReturnDetails.Text = "Book is not available";
                    lblGetReturnDetails.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }
        }

        /// <summary>
        /// RETURN BOOK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReturnBook_Click(object sender, EventArgs e)
        {
            try
            {
                lblReturnBook.Visible = false;
                transaction.BookId = Convert.ToInt32(txtBookIdReturn.Text);
                //transaction.ReturnDate = DateTime.Now;
                transaction.ReturnDate = DateTime.Now;
                
                int result = IlibraryService.ReturnBook(transaction);
                if (result == 1)
                {
                    lblReturnBook.Text = "Book Returned Successfully";
                    lblReturnBook.Visible = true;                                    
                }

                else if (result == 0)
                {                   
                    lblReturnBook.Text = "Book is already returned";
                    lblReturnBook.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }


        }

        /// <summary>
        /// RESET Issue Details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnResetIssueBook_Click(object sender, EventArgs e)
        {
            try
            {
                txtBookIdIssue.Text = string.Empty;
                txtUserIdIssue.Text = string.Empty;
                txtIssueDate.Text = string.Empty;
                txtDueDate.Text = string.Empty;
                lblBookAvlblty.Visible = false;
                lblIssueBook.Visible = false;
                lblMemberAvlblty.Visible = false;
                txtBookIdIssue.Enabled = true;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }
        }

        /// <summary>
        /// RESET Return Details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnResetReturnBook_Click(object sender, EventArgs e)
        {
            try
            {
                txtBookIdReturn.Text = string.Empty;
                txtReturnDate.Text = string.Empty;
                lblGetReturnDetails.Visible = false;
                lblReturnBook.Visible = false;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }
        }

        /// <summary>
        /// VIEW ALL Transactions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnViewAllTransactions_Click(object sender, EventArgs e)
        {
            try
            {
                gvAllTransactions.Visible = true;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }
        }

        /// <summary>
        /// Page Index Changing for Transactions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvAllTransactions_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                var lstTransaction = IlibraryService.GetAllTransaction();
                gvAllTransactions.DataSource = lstTransaction;
                gvAllTransactions.DataBind();
                gvAllTransactions.PageIndex = e.NewPageIndex;
                gvAllTransactions.DataSource = lstTransaction;
                gvAllTransactions.Page.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }
        }


    }
}