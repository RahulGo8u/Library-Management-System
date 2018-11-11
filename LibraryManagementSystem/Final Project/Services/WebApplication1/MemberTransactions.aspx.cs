using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCFService = WebApplication1.LibraryServiceClient;

namespace WebApplication1
{
    public partial class MemberTransactions : System.Web.UI.Page
    {
        private WCFService.ILibraryService IlibraryService = new LibraryServiceClient.LibraryServiceClient();                
        private WCFService.Transaction transaction = new WCFService.Transaction();

        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                var lstTransaction = IlibraryService.GetSelfTransaction(userId);
                gvAllTransactions.DataSource = lstTransaction;
                gvAllTransactions.DataBind();
                gvAllTransactions.Visible = false;
            }
        }

        /// <summary>
        /// Page index change of Self Transaction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvAllTransactions_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                var lstTransaction = IlibraryService.GetSelfTransaction(userId);
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


        /// <summary>
        /// VIEW SELF Transactions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnViewSelfTransactions_Click(object sender, EventArgs e)
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

    }
}
