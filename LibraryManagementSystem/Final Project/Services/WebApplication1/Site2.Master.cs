using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Site2 : System.Web.UI.MasterPage
    {
        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            string currenttime = DateTime.Now.ToLongTimeString();
            lblcurrenttime.Text = currenttime;
            int userd = Convert.ToInt32(Session["UserId"]);
            if (Session["FirstName"] != null)
            {
                lblCurrentUser.Text = Session["FirstName"].ToString();
            }
            int x = Convert.ToInt32(Session["RoleId"]);
            if (x == 1)
            {

                lblRole.Text = "Librarian";
            }
            else
                if (x == 0)
                {
                    lblRole.Text = "Member";
                }
        }
    }
}