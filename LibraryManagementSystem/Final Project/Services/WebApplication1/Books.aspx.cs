using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCFService = WebApplication1.LibraryServiceClient;

namespace WebApplication1
{
    public partial class Books : System.Web.UI.Page
    {
        private WCFService.ILibraryService IlibraryService = new LibraryServiceClient.LibraryServiceClient();
        private WCFService.Books books = new WCFService.Books();
        private WCFService.Categories category = new WCFService.Categories();

        /// <summary>
        /// PAGE LOAD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {                       
            var lstCategory = IlibraryService.GetAllCategories();
            if (!IsPostBack)
            {
                gvCategories.DataSource = lstCategory;
                gvCategories.DataBind();

                ddlCategory.DataSource = lstCategory;
                ddlCategory.DataValueField = "CategoryId";
                ddlCategory.DataTextField = "Category";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("--Select--", "0"));                
                ddlCategory.SelectedIndex = 0;

                ddlCategoryUpdate.DataSource = lstCategory;
                ddlCategoryUpdate.DataValueField = "CategoryId";
                ddlCategoryUpdate.DataTextField = "Category";
                ddlCategoryUpdate.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlCategory.SelectedIndex = 0;
                
                pnlGetBookDetails.Visible = false;
                pnlDeleteBook.Visible = false;
                pnlCheckStatus.Visible = false;
                gvCategories.Visible = false;
                lblAddBook.Visible = false;
                lblAddCategory.Visible = false;
                lblDeleteBook.Visible = false;
                lblUpdateBook.Visible = false;
                lblGetDetailsDelete.Visible = false;
                lblStatus.Visible = false;
                lblStatusBookId.Visible = false;
            }

        }
                
        /// <summary>
        /// ADD BOOK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmitBook_Click(object sender, EventArgs e)
        {
            try
            {
                books.Title = txtTitle.Text;
                books.Category = ddlCategory.SelectedItem.Text;
                books.Author = txtAuthor.Text;
                books.Publisher = txtPublisher.Text;
                books.Price = Convert.ToDecimal(txtPrice.Text);
                books.ISBNNumber = txtISBN.Text;
                books.Description = txtDescription.Text;
                books.AvailStatus = true;
                int result = IlibraryService.AddBook(books);
                if (result == 1)
                {
                    lblAddBook.Text = "Book Added successfully";
                    lblAddBook.Visible = true;
                }
                else
                {
                    lblAddBook.Text = "Some Error occured, Please verify details";
                    lblAddBook.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }
        }

        /// <summary>
        /// Reset Book Details while Inserting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnResetBook_Click(object sender, EventArgs e)
        {
            try
            {
                txtAuthor.Text = string.Empty;
                txtTitle.Text = string.Empty;
                txtPublisher.Text = string.Empty;
                ddlCategory.SelectedIndex = 0;
                txtPrice.Text = string.Empty;
                txtISBN.Text = string.Empty;
                txtDescription.Text = string.Empty;
                lblAddBook.Visible = false;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }
        }

        /// <summary>
        /// Reset Category
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnResetCategory_Click(object sender, EventArgs e)
        {
            try
            {
                txtnwCategory.Text = string.Empty;
                lblAddCategory.Visible = false;                
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }

        }

        /// <summary>
        /// Reset Book Details while Updating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnResetUpdateBook_Click(object sender, EventArgs e)
        {
            try
            {
                txtAuthorUpdate.Text = string.Empty;
                txtTitleUpdate.Text = string.Empty;
                txtPublisherUpdate.Text = string.Empty;
                ddlCategoryUpdate.SelectedIndex = 0;
                txtPriceUpdate.Text = string.Empty;
                txtISBNUpdate.Text = string.Empty;
                txtDescriptionUpdate.Text = string.Empty;
                txtBookIdUpdate.Text = string.Empty;
                pnlGetBookDetails.Visible = false;
                lblStatusBookId.Visible = false;
                txtBookIdUpdate.Enabled = true;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }

        }

        /// <summary>
        /// Reset Book Details while Deleting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnResetDeleteBook_Click(object sender, EventArgs e)
        {
            try
            {
                txtBookIdDelete.Text = string.Empty;
                lblGetDetailsDelete.Visible = false;
                pnlDeleteBook.Visible = false;
                pnlCheckStatus.Visible = false;
                lblDeleteBook.Visible = false;
                lblStatus.Visible = true;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }
        }

        /// <summary>
        /// ADD CATEGORY
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                category.Category = txtnwCategory.Text;
                int result = IlibraryService.AddCategory(category);
                if (result==1)
                {
                    lblAddCategory.Text = "Category Added Successfully";
                    lblAddCategory.Visible = true;
                }
                else 
                    if(result==0)
                {
                    lblAddCategory.Text = "Category Already Exists";
                    lblAddCategory.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }
        }

        /// <summary>
        /// UPDATE BOOK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdateBook_Click(object sender, EventArgs e)
        {
            try
            {
                books.BookId = Convert.ToInt32(txtBookIdUpdate.Text);
                books.Title = txtTitleUpdate.Text;
                books.Description = txtDescriptionUpdate.Text;
                books.Category = ddlCategoryUpdate.SelectedItem.Text;
                books.Author = txtAuthorUpdate.Text;
                books.Publisher = txtPublisherUpdate.Text;
                books.Price = Convert.ToDecimal(txtPriceUpdate.Text);
                books.ISBNNumber = txtISBNUpdate.Text;
                books.AvailStatus = Convert.ToBoolean(rblStatus.SelectedIndex);
                int result = IlibraryService.UpdateBook(books);
                if (result == 1)
                {
                    lblUpdateBook.Text = "Book Updated successfully";
                    lblUpdateBook.Visible = true;

                }
                else
                {
                    lblUpdateBook.Text = "Some Error occured";
                    lblUpdateBook.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }
        }

        /// <summary>
        /// DELETE BOOK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDeleteBook_Click(object sender, EventArgs e)
        {
            try
            {
                int bookID = Convert.ToInt32(txtBookIdDelete.Text);
                int result=IlibraryService.DeleteBook(bookID);
                if (result == 1)
                {
                    lblDeleteBook.Text = "Book Deleted successfully";
                    lblDeleteBook.Visible = true;
                }
                else
                {
                    lblDeleteBook.Text = "Invalid BookId, Please enter valid Book Id";
                    lblDeleteBook.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }
        }

        /// <summary>
        /// VIEW ALL CATEGORIES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnViewAllCategories_Click(object sender, EventArgs e)
        {
            try
            {
                gvCategories.Visible = true;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }
        }

        /// <summary>
        /// GET DETAILS FOR UPDATING BOOK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGetDetailsUpdateBook_Click(object sender, EventArgs e)
        {
            try
            {
                pnlGetBookDetails.Visible = false;
                int bookId = Convert.ToInt32(txtBookIdUpdate.Text);
                int detail = IlibraryService.CheckBookAvailibility(bookId);
                if (detail ==1)
                {
                    var result = IlibraryService.GetBookDetails(Convert.ToInt32(txtBookIdUpdate.Text));
                    if (result != null)
                    {
                        txtTitleUpdate.Text = result.Title;
                        txtDescriptionUpdate.Text = result.Description;
                        ddlCategoryUpdate.SelectedItem.Text = result.Category;
                        txtAuthorUpdate.Text = result.Author;
                        txtPublisherUpdate.Text = result.Publisher;
                        txtPriceUpdate.Text = Convert.ToString(result.Price);
                        txtISBNUpdate.Text = result.ISBNNumber;
                        rblStatus.SelectedIndex = Convert.ToInt32(result.AvailStatus);
                        pnlGetBookDetails.Visible = true;
                        txtBookIdUpdate.Enabled = false;
                        lblStatusBookId.Visible = false;
                    }
                }
                else
                {
                    lblStatusBookId.Text = "Invalid BookId";
                    lblStatusBookId.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }
        }

        /// <summary>
        /// GET DETAILS FOR DELETING BOOK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGetDetailsDeleteBook_Click(object sender, EventArgs e)
        {
            try
            {
                int bookId = Convert.ToInt32(txtBookIdDelete.Text);
                int result = IlibraryService.CheckBookAvailibility(bookId);

                if (result == 1)
                {
                    pnlCheckStatus.Visible = true;
                    lblGetDetailsDelete.Text = "Available";
                    lblGetDetailsDelete.Visible = true;
                    lblStatus.Visible = false;
                }
                else
                {
                    lblGetDetailsDelete.Text = "Invalid BookId";
                    lblGetDetailsDelete.Visible = true;
                    //Response.Write("<script>alert('Invalid BookId, Please Refresh and Re-enter')</script>");
                    //Response.End();
                    pnlCheckStatus.Visible = false;
                    lblStatus.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }
        }

        /// <summary>
        /// Check Status for Deleting Book
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCheckStatus_Click(object sender, EventArgs e)
        {
            try
            {
                int bookId = Convert.ToInt32(txtBookIdDelete.Text);
                int result = IlibraryService.CheckBookAvlblty(bookId);
                if (result == 1)
                {
                    pnlDeleteBook.Visible = true;
                    lblStatus.Text = "Proceed to delete";
                    lblStatus.Visible = true;
                    
                }
                else
                {
                    lblStatus.Text = "Book is already issued, Please return it to delete";
                    lblStatus.Visible = true;
                    pnlDeleteBook.Visible = false;
                    lblGetDetailsDelete.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }
        }

        /// <summary>
        /// Categories Page Index Change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvCategories_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                var lstCategory = IlibraryService.GetAllCategories();
                gvCategories.DataSource = lstCategory;
                gvCategories.DataBind();
                gvCategories.PageIndex = e.NewPageIndex;
                gvCategories.DataSource = lstCategory;
                gvCategories.Page.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }
        }

    }
}