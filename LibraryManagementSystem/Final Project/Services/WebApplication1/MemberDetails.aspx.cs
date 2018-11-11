using WCFService = WebApplication1.LibraryServiceClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class MemberDetails : System.Web.UI.Page
    {
        private WCFService.ILibraryService IlibraryService = new LibraryServiceClient.LibraryServiceClient();                
        private WCFService.Users users = new WCFService.Users();

        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
           // int userId = Convert.ToInt32(Session["UserID"]);

            if (!IsPostBack)
            {
                pnlUserDetailsUpdate.Visible = false;

                txtUserIdUpdate.Enabled = false;

                //int u = Convert.ToInt32(Session["UserId"]);
                txtUserIdUpdate.Text = Session["UserId"].ToString();
            }

        }

        /// <summary>
        /// UPDATE MEMBER DETAILS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                users.UserId = Convert.ToInt32(Session["UserID"]);
                users.FirstName = txtFirstNameUpdate.Text;
                users.LastName = txtLastNameUpdate.Text;
                users.EmailId = txtEmailUpdate.Text;
                users.MobileNo = txtMobileUpdate.Text;
                users.Password = txtPasswordUpdate.Text;
                users.RoleId = rblRoleidUpdate.SelectedIndex;
                users.DOB = Convert.ToDateTime(txtDOBUpdate.Text);
                int result = IlibraryService.UpdateMemberDetails(users);
                if (result == 1)
                {
                    lblUpdateMember.Text = "Member Updated successfully";

                }
                else
                {
                    lblUpdateMember.Text = "Some Error occured, Please enter correct details";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }

        }

        /// <summary>
        /// GET DETAILS TO UPDATE MEMBER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnGetUserDetails_Click(object sender, EventArgs e)
        {
            try
            {
                var result = IlibraryService.GetMemberDetails(Convert.ToInt32(txtUserIdUpdate.Text));
                if (result != null)
                {
                    txtFirstNameUpdate.Text = result.FirstName;
                    txtLastNameUpdate.Text = result.LastName;
                    txtEmailUpdate.Text = result.EmailId;
                    txtPasswordUpdate.Text = result.Password;
                    txtMobileUpdate.Text = result.MobileNo;
                    rblRoleidUpdate.SelectedIndex = Convert.ToInt32(result.RoleId);
                    txtDOBUpdate.Text = result.DOB.ToString("yyyy-MM-dd");
                    pnlUserDetailsUpdate.Visible = true;
                }
                else
                {
                    Response.Write("<script>alert('Please enter valid User Id')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }

        }

        /// <summary>
        /// RESET MEMBER DETAILS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnResetUpdateMember_Click(object sender, EventArgs e)
        {
            try
            {
                //txtUserIdUpdate.Text = string.Empty;
                txtFirstNameUpdate.Text = string.Empty;
                txtLastNameUpdate.Text = string.Empty;
                txtEmailUpdate.Text = string.Empty;
                txtMobileUpdate.Text = string.Empty;
                rblRoleidUpdate.SelectedIndex = -1;
                txtDOBUpdate.Text = string.Empty;
                txtPasswordUpdate.Text = string.Empty;
                pnlUserDetailsUpdate.Visible = false;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some error occured')</script>");
            }
        }

    }
}