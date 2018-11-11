<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="WebApplication1.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>
    Password Recovery
</title>
    <%--CSS--%>
<style type="text/css">
body {background-color: #f4f4f4;color: #5a5656;font-family: 'Open Sans', Arial, Helvetica, sans-serif;font-size: 16px;line-height: 1.5em;}
a { text-decoration: none; }
h1 { font-size: 1em; }
h1, p {margin-bottom: 10px;}
strong {font-weight: bold;}
.uppercase { text-transform: uppercase; }

/* ---------- Forgot Password ---------- */
#forgotpassword {margin: 50px auto;width: 300px;}
form fieldset input[type="text"]{
background-color: #e5e5e5;border: none; border-radius: 3px; -moz-border-radius: 3px; -webkit-border-radius: 3px; color: #5a5656; font-family: 'Open Sans', Arial, Helvetica, sans-serif;
font-size: 14px; height: 50px; outline: none; padding: 0px 10px; width: 280px; -webkit-appearance:none;}
form fieldset input[type="submit"] {
background-color: #008dde; border: none; border-radius: 3px; -moz-border-radius: 3px; -webkit-border-radius: 3px; color: #f4f4f4; cursor: pointer; font-family: 'Open Sans', Arial, Helvetica, sans-serif;
height: 50px; text-transform: uppercase; width: 300px; -webkit-appearance:none;}
form fieldset a { color: #5a5656; font-size: 10px;}
</style>

</head>
<%--Forgot Password--%>
<body>

<div id="forgotpassword">
<h1>Please enter your Email to receive your credentials</h1>
<form runat="server">
<fieldset>
<p><asp:TextBox ID="txtEmailId" runat="server" ToolTip="Email Id" TextMode="Email" Height="66px" Width="293px" placeholder="Email Id"></asp:TextBox></p>
<asp:RequiredFieldValidator runat="server" id="rfvtxtEmailId" controltovalidate="txtEmailId" errormessage="Email Id is required!" Text="*" ValidationGroup="email" ForeColor="Red" />
<p><asp:Button ID="btnGetCredentials" runat="server" Text="Get Credentials" OnClick="btnGetCredentials_Click" ToolTip="Get Credentials" ValidationGroup="email"/></p>
<p><a href="Login.aspx"><b>Back to Login Page</b></a></p>
</fieldset>
</form>
</div> 
<!-- End Forgot Password -->

</body>
</html>
