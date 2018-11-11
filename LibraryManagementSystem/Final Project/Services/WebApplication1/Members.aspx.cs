using WCFService = WebApplication1.LibraryServiceClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace WebApplication1
{
    public partial class Members : System.Web.UI.Page
    {
        private WCFService.ILibraryService IlibraryService = new LibraryServiceClient.LibraryServiceClient();                
        private WCFService.Users users = new WCFService.Users();
        
        /// <summary>
        /// PAGE LOAD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUserDetailsUpdate.Visible = false;
                pnlDeleteUser.Visible = false;
                lblDeleteMember.Visible = false;                
                lblGetDetailsDelete.Visible = false;
                lblCheckUserId.Visible = false;
                lblAddMember.Visible = false;
                lblGetDetailsDelete.Visible = false;
                pnlCheckStatus.Visible = false;
                lblStatus.Visible = true;
            }
        }

        /// <summary>
        /// ADD MEMBER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                users.FirstName = txtfname.Text;
                users.LastName = txtlname.Text;
                users.EmailId = txtEmail.Text;
                users.MobileNo = txtphone.Text;
                users.RoleId = rblRole.SelectedIndex;
                users.DOB = Convert.ToDateTime(txtDOB.Text);
                int result = IlibraryService.AddMember(users);
                if (result == 1)
                {
                    lblAddMember.Text = "Member Added successfully";
                    lblAddMember.Visible = true;
                }
                else
                {
                    lblAddMember.Text = "Some Error occured, Please enter correct details";
                    lblAddMember.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
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
                users.UserId = Convert.ToInt32(txtUserIdUpdate.Text);
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
        /// DELETE MEMBER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDeleteMember_Click(object sender, EventArgs e)
        {
            try
            {
                int userId = Convert.ToInt32(txtUserIdDelete.Text);
                int result = IlibraryService.DeleteMember(userId);
                if (result == 1)
                {
                    lblDeleteMember.Text = "User Deleted successfully";
                    lblDeleteMember.Visible = true;
                    lblGetDetailsDelete.Visible = true;
                }
                else if(result==0)
                {
                    lblDeleteMember.Text = "User has not returned book, Please return it to delete";
                
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }

        }

        /// <summary>
        /// Check User id to update user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCheckUserId_Click(object sender, EventArgs e)
        {
            try
            {
                int userId = Convert.ToInt32(txtUserIdUpdate.Text);
                int result = IlibraryService.CheckMemberAvlblty(userId);
                if (result == 1)
                {

                    var details = IlibraryService.GetMemberDetails(Convert.ToInt32(txtUserIdUpdate.Text));
                    if (details != null)
                    {
                        txtFirstNameUpdate.Text = details.FirstName;
                        txtLastNameUpdate.Text = details.LastName;
                        txtEmailUpdate.Text = details.EmailId;
                        txtPasswordUpdate.Text = details.Password;
                        txtMobileUpdate.Text = details.MobileNo;
                        rblRoleidUpdate.SelectedIndex = Convert.ToInt32(details.RoleId);
                        txtDOBUpdate.Text = details.DOB.ToString("yyyy-MM-dd");
                        lblCheckUserId.Visible = false;
                        pnlUserDetailsUpdate.Visible = true;
                        txtUserIdUpdate.Enabled = false;
                    }
                }
                else
                {
                    lblCheckUserId.Text="Invalid User Id";
                    lblCheckUserId.Visible = true;
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured, Please enter correct User ID')</script>");
            }
        }

        /// <summary>
        /// GET DETAILS TO UPDATE MEMBER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnGetDetailsUpdateMember_Click(object sender, EventArgs e)
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
                    lblGetDetailsDelete.Text = "Proceed to Delete";
                    lblGetDetailsDelete.Visible = true;
                }
                else
                {
                    lblGetDetailsDelete.Text="Please enter valid User Id";
                    lblGetDetailsDelete.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }

        }

        /// <summary>
        /// GET DETAILS TO DELETE MEMBER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnGetDetailsDeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                var result = IlibraryService.GetMemberDetails(Convert.ToInt32(txtUserIdDelete.Text));
                if (result.UserId != 0)
                {
                    lblGetDetailsDelete.Text = "User Available";
                    lblGetDetailsDelete.Visible = true;
                    lblStatus.Visible = false;
                    pnlCheckStatus.Visible = true;
                }
                else
                {
                    lblGetDetailsDelete.Text = "Invalid User Id";
                    lblGetDetailsDelete.Visible = true;
                    pnlDeleteUser.Visible = false;
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
        /// RESET FOR ADDING MEMBERS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnResetAddMember_Click(object sender, EventArgs e)
        {
            try
            {
                txtfname.Text = string.Empty;
                txtlname.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtphone.Text = string.Empty;
                rblRole.SelectedIndex = -1;
                txtDOB.Text = string.Empty;
                lblAddMember.Visible = false;
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Some error occured')</script>");
            }
        }

    

        /// <summary>
        /// RESET FOR UPDATING MEMBER DETAILS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnResetUpdateMember_Click(object sender, EventArgs e)
        {
            try
            {
                txtUserIdUpdate.Text = string.Empty;
                txtFirstNameUpdate.Text = string.Empty;
                txtLastNameUpdate.Text = string.Empty;
                txtEmailUpdate.Text = string.Empty;
                txtMobileUpdate.Text = string.Empty;
                rblRoleidUpdate.SelectedIndex = -1;
                txtDOBUpdate.Text = string.Empty;
                txtPasswordUpdate.Text = string.Empty;
                pnlUserDetailsUpdate.Visible = false;
                lblCheckUserId.Visible = false;
                txtUserIdUpdate.Enabled = true;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some error occured')</script>");
            }
        }

        /// <summary>
        /// RESET FOR DELETING MEMBER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnResetDeleteMember_Click(object sender, EventArgs e)
        {
            try
            {
                txtUserIdDelete.Text = string.Empty;
                lblDeleteMember.Visible = false;
                pnlDeleteUser.Visible = false;
                lblStatus.Visible = false;
                pnlCheckStatus.Visible = false;
                lblGetDetailsDelete.Visible = false;
                lblGetDetailsDelete.Visible = false;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }
        }

        /// <summary>
        /// Check Status for Deleting User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCheckStatus_Click(object sender, EventArgs e)
        {
            try
            {
                int userId = Convert.ToInt32(txtUserIdDelete.Text);
                int result = IlibraryService.CheckMemberAvailability(userId);
                if (result == 1)
                {
                    pnlDeleteUser.Visible = true;
                    lblStatus.Text = "Proceed to delete";
                    lblStatus.Visible = true;
                    pnlDeleteUser.Visible = true;
                }
                else
                {
                    lblStatus.Text = "User has pending issued books, Please return it to delete";
                    lblStatus.Visible = true;                    
                    lblGetDetailsDelete.Visible = false;
                    pnlDeleteUser.Visible = false;
                }
                
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Some Error occured')</script>");
            }
        }

    }
}