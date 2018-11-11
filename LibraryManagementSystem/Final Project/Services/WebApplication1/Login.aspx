<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<%--Title--%>
<title>Login</title>
<%--CSS--%>
<style type="text/css">
body {background-color: #f4f4f4; color: #5a5656; font-family: 'Open Sans', Arial, Helvetica, sans-serif; font-size: 16px; line-height: 1.5em;}
a { text-decoration: none; }
h1 { font-size: 1em; }
h1, p {margin-bottom: 10px;}
strong {font-weight: bold;}
.uppercase { text-transform: uppercase; }

/*LOGIN*/
#login {margin: 50px auto; width: 300px;}
form fieldset input[type="text"], input[type="password"] 
{background-color: #e5e5e5; border: none; border-radius: 3px; -moz-border-radius: 3px; -webkit-border-radius: 3px; color: #5a5656; font-family: 'Open Sans', Arial, Helvetica, sans-serif;
font-size: 14px; height: 50px; outline: none; padding: 0px 10px; width: 280px; -webkit-appearance:none;}
form fieldset input[type="submit"] 
{background-color: #008dde; border: none; border-radius: 3px; -moz-border-radius: 3px; -webkit-border-radius: 3px; color: #f4f4f4; cursor: pointer; 
font-family: 'Open Sans', Arial, Helvetica, sans-serif; height: 50px; text-transform: uppercase; width: 300px; -webkit-appearance:none;}
form fieldset a {color: #5a5656;font-size: 10px;}
</style>
</head>

<%--BODY--%>
<body>
<%--Login--%>
<div id="login">
    <h1><strong>Welcome.</strong> Login to Library</h1>
<form runat="server">
<fieldset>

<p><asp:TextBox ID="txtUserId" runat="server" ToolTip="User Id" placeholder="User Id"></asp:TextBox></p>
<asp:RequiredFieldValidator runat="server" id="rfvtxtUserId" controltovalidate="txtUserId" errormessage="UserId is required!" Text="*" ValidationGroup="login" ForeColor="Red" />
<asp:RegularExpressionValidator ID="revtxtUserId" runat="server" 
ControlToValidate="txtUserId" 
ValidationExpression="^\d*$"
ValidationGroup="login" ErrorMessage="Enter a valid User Id" Text="*" />   

<p><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ToolTip="Password" placeholder="Password"></asp:TextBox></p>
<asp:RequiredFieldValidator runat="server" id="rfvtxtPassword" controltovalidate="txtPassword" errormessage="Password is required!" Text="*" ValidationGroup="login" ForeColor="Red" />
<asp:RegularExpressionValidator ID="revtxtPassword" runat="server" 
ControlToValidate="txtPassword" 
ValidationExpression="^.{8,32}$"
ValidationGroup="login" ErrorMessage="Password should be between 8 and 32 characters" Text="*" />   
<p><a href="ForgotPassword.aspx">Forgot Password?</a></p>
<p>

<asp:Button ID="btnLogin" runat="server" Text="Login" onclick="btnLogIn_Click" ValidationGroup="login" ToolTip="Login"/></p>
<p><asp:Label ID="lblLogin" runat="server" ForeColor="red" BorderColor="Black" Font-Bold="true"></asp:Label></p>

<asp:ValidationSummary ID="ValidationSummary1"  ValidationGroup="login" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false" HeaderText="You're missing a required field:" EnableClientScript="true"/>
</fieldset>
</form>
</div> 
<!-- END LOGIN -->
</body>
</html>
