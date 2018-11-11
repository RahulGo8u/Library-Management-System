using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCFService = WebApplication1.LibraryServiceClient;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
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
        /// Login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(txtUserId.Text);
            string password = txtPassword.Text;
            var result = IlibraryService.Login(userId, password);
            if (result.UserId != 0)
            {
                Session["UserId"] = result.UserId;
                Session["FirstName"] = result.FirstName;
                Session["RoleId"] = result.RoleId;
                if (result.RoleId==1)
                {
                    Response.Redirect("/Home.aspx");
                }
                else
                {
                    Response.Redirect("/MemberHome.aspx");
                }

            }
            else
                lblLogin.Text="*UserId or Password do not match";
        }

    }
}