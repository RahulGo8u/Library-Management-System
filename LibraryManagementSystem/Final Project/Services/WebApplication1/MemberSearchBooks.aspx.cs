using WCFService = WebApplication1.LibraryServiceClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class MemberSearchBooks : System.Web.UI.Page
    {
        private WCFService.ILibraryService IlibraryService = new LibraryServiceClient.LibraryServiceClient();
        
        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Search Books
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearchBooks_Click1(object sender, EventArgs e)
        {
            try
            {
                var result = IlibraryService.SearchBooks(rblsearchfilter.SelectedItem.Text, txtSearchBooks.Text);
                gvBookDetails.DataSource = result;
                gvBookDetails.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }

        }
    }

}
