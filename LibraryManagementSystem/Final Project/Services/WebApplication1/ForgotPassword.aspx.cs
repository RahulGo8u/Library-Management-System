using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCFService = WebApplication1.LibraryServiceClient;

namespace WebApplication1
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        private WCFService.ILibraryService IlibraryService = new LibraryServiceClient.LibraryServiceClient();
        private WCFService.Books books = new WCFService.Books();
        private WCFService.Categories category = new WCFService.Categories();
        private WCFService.Transaction transaction = new WCFService.Transaction();
        private WCFService.Users user = new WCFService.Users();

        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Get Credentials
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGetCredentials_Click(object sender, EventArgs e)
        {

            var result = IlibraryService.GetAuthenticationDetails(txtEmailId.Text);         
            if (result.UserId != 0)
            {
            int userId = result.UserId;
            string password = result.Password;
                MailMessage loginInfo = new MailMessage();
                loginInfo.To.Add(txtEmailId.Text.ToString());
                loginInfo.From = new MailAddress("rahulanand.infosys@gmail.com");
                loginInfo.Subject = "Forgot Password Information";
                loginInfo.Body = "UserId: " + userId + "<br /><br />Password: " + password + "<br /><br />";
                loginInfo.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("rahulanand.infosys@gmail.com", "HACK@1903");
                smtp.Send(loginInfo);
                Response.Write("<script>alert('Password is sent to you email id')</script>");
            }
            else
            {
                    Response.Write("<script>alert('Email Id is not Registered')</script>");
            }

        }
    }
}
