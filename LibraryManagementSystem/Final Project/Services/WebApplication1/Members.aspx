<%@ Page Title="" Language="C#"  MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Members.aspx.cs" Inherits="WebApplication1.Members" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<%--Head--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<%--CSS--%>
 <style type="text/css">
.member .ajax__tab_header
{
background:url(Images/tab.png) ;
cursor:pointer;
}
.member .ajax__tab_hover .ajax__tab_outer, .member .ajax__tab_active .ajax__tab_outer
{
background: url(Images/tab.png) no-repeat left top;
}
.member .ajax__tab_hover .ajax__tab_inner, .member .ajax__tab_active .ajax__tab_inner
{
background: url(Images/tab.png) no-repeat right top;
}
.active .ajax__tab_header
{
font-size: 13px;
font-weight: bold;

font-family: sans-serif;
}
.active .ajax__tab_active .ajax__tab_outer, .active .ajax__tab_header .ajax__tab_outer, .active .ajax__tab_hover .ajax__tab_outer
{
height: 46px;
}
.active .ajax__tab_active .ajax__tab_inner, .active .ajax__tab_header .ajax__tab_inner, .active .ajax__tab_hover .ajax__tab_inner
{
height: 46px;
margin-left: 16px; /* offset the width of the left image */
}
.active .ajax__tab_active .ajax__tab_tab, .active .ajax__tab_hover .ajax__tab_tab, .active .ajax__tab_header .ajax__tab_tab
{
margin: 16px 16px 0px 0px;
color: #ffffff;
}
.active .ajax__tab_hover .ajax__tab_tab, .active .ajax__tab_active .ajax__tab_tab
{
color: #00ff21;
}
.active .ajax__tab_body
{
font-family: Arial;
font-size: 10pt;
border-top: 0;
border:1px solid #999999;
padding: 8px;
background-color: #ffffff;
}
</style>

</asp:Content>

<%--Content Place Holder--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div style=" width:100%">
<ajax:TabContainer ID="TabContainer1" runat="server" CssClass="active member" >

<%--New Member Tab Panel--%>    
<ajax:TabPanel ID="tbpnluser" runat="server" >
<HeaderTemplate>
Add New Member
</HeaderTemplate>
<ContentTemplate>

<asp:Panel ID="pnlAddMember" runat="server">
<table align="center">

<tr>
<td></td>
<td align="right" >
</td>
<td align="center">
<b>Add Member</b>
</td>
</tr>


<tr>
<td></td>
<td align="right">
FirstName:
</td>
<td>
<asp:TextBox ID="txtfname" runat="server" placeholder="First Name" ToolTip="First Name"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" id="reqfName" controltovalidate="txtfname" 
ValidationGroup="addMember"
errormessage="First Name is required!" Text="*" ForeColor="Red" />
<asp:RegularExpressionValidator ID="regfName" runat="server" 
ControlToValidate="txtfname" ValidationGroup="addMember"
ValidationExpression="^[a-zA-Z'.\s]{1,50}"
ErrorMessage="Enter a valid First name" Text="*" />   
</td>
</tr>

<tr>
<td></td>
<td align="right">
LastName:
</td>
<td>
<asp:TextBox ID="txtlname" runat="server" placeholder="Last Name" ToolTip="Last Name"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" id="reqlName" controltovalidate="txtlname"
ValidationGroup="addMember"
errormessage="Last Name is required!" Text="*" ForeColor="Red" />
<asp:RegularExpressionValidator ID="reglName" runat="server" 
ControlToValidate="txtlname" 
ValidationGroup="addMember"
ValidationExpression="^[a-zA-Z'.\s]{1,50}"
ErrorMessage="Enter a valid Last name" Text="*" />   
</td>
</tr>

<tr>
<td></td>
<td align="right">
Email:
</td>
<td>
<asp:TextBox ID="txtEmail" runat="server" placeholder="Email id" ToolTip="Email ID"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" id="reqEmail" controltovalidate="txtEmail" ValidationGroup="addMember" errormessage="Email is required!" Text="*" ForeColor="Red" />
<asp:RegularExpressionValidator ID="revEmail" runat="server" ValidationGroup="addMember"
ControlToValidate="txtEmail" ErrorMessage="Enter a valid Email" 
ValidationExpression="^[^@]+@[^@]+\.[^@]+$" Text="*" />
</td>
</tr>

<tr>
<td></td>
<td align="right" >
Mobile No:
</td>
<td>
<asp:TextBox ID="txtphone" runat="server" placeholder="Mobile No" ToolTip="Mobile No"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" id="reqPhone" ValidationGroup="addMember" controltovalidate="txtphone" errormessage="Mob No is required!" Text="*" ForeColor="Red" />
<asp:RegularExpressionValidator ID="revphone" runat="server" ValidationGroup="addMember"
ControlToValidate="txtphone" ErrorMessage="Enter a valid 10 digit Mobile No" 
ValidationExpression="[0-9]{10}" Text="*" ></asp:RegularExpressionValidator>
</td>
</tr>

<tr>
<td></td>
<td align="right" >
Role:
</td>
<td>
<asp:RadioButtonList ID="rblRole" runat="server">
<asp:ListItem>Member</asp:ListItem>
<asp:ListItem>Librarian</asp:ListItem>
</asp:RadioButtonList>
<asp:RequiredFieldValidator runat="server" id="reqRole" ValidationGroup="addMember" controltovalidate="rblRole" errormessage="Role is required!" Text="*" ForeColor="Red" />
</td>
</tr>

<tr>
<td></td>
<td align="right" >
DOB:
</td>
<td align="left">
<asp:TextBox ID="txtDOB" runat="server" TextMode="Date" placeholder="Date of Birth" ToolTip="Date of Birth"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" id="reqDOB" ValidationGroup="addMember" controltovalidate="txtDOB" errormessage="Date of Birth is required!" Text="*" ForeColor="Red" />
<asp:RangeValidator id="birthDateRangeTest" runat="server" ValidationGroup="addMember"
Type="Date" ControlToValidate="txtDOB" 
MinimumValue="1/1/1950" 
MaximumValue="12/31/1995"
ErrorMessage="Please enter a valid date after 1950 and before 1995!!" Text="*"/>
</td>
</tr>

<tr>
<td></td>
<td></td>
<td align="left" ><asp:Button ID="btnSubmit" runat="server" ValidationGroup="addMember" Text="Save" OnClick="btnSubmit_Click"/>

    <asp:Button ID="btnResetAddMember" runat="server" Text="Reset"  OnClick="btnResetAddMember_Click"/>
</td>
</tr>
    <tr>
        <td></td>
        <td></td>
        <td><asp:Label ID="lblAddMember" runat="server" ForeColor="red" BorderColor="Black" Font-Bold="true"></asp:Label></td>
        </tr>
<tr>
<asp:ValidationSummary ID="ValidationSummary1"  ValidationGroup="addMember" runat="server" ForeColor="Red" ShowMessageBox="True" ShowSummary="False" HeaderText="You're missing a required field:"/>
</tr>

</table>
</asp:Panel>
</ContentTemplate>
</ajax:TabPanel>

<%--Update Member Tab Panel--%>    
<ajax:TabPanel ID="tbpnlupdatemember" runat="server" > 
<HeaderTemplate>
Update Member
</HeaderTemplate>
<ContentTemplate>
<table align="center">
   
<tr>
<td align="right" colspan="2">
<b>UserId</b>
</td>
<td>
<asp:TextBox ID="txtUserIdUpdate" runat="server" placeholder="User Id" ToolTip="User Id"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" id="rfvtxtUserIdUpdate" controltovalidate="txtUserIdUpdate"
ValidationGroup="updateMember" errormessage="UserId is required!" Text="*" ForeColor="Red" />
        <asp:RegularExpressionValidator ID="revtxtUserIdUpdate" runat="server" 
       ControlToValidate="txtUserIdUpdate" 
       ValidationExpression="^\d*$"
       ValidationGroup="updateMember" ErrorMessage="Enter a valid User Id" Text="*" />   

</td><td>
<asp:Button ID="btnCheckUserId" runat="server" Text="Check User Id" OnClick="btnCheckUserId_Click" ValidationGroup="updateMember"/>
</td>
<td><asp:Label ID="lblCheckUserId" runat="server" ForeColor="red" BorderColor="Black" Font-Bold="true"></asp:Label></td>
 </tr>

<tr>
<asp:ValidationSummary ID="ValidationSummary4"  ValidationGroup="updateMember" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false" HeaderText="You're missing a required field:" EnableClientScript="true"/>
</tr>
</table>
<asp:Panel ID="pnlUserDetailsUpdate" runat="server">

<table align="center">

<tr>
<td align="right" colspan="2" >
</td>
<td>
<b>User Details</b>
</td>
</tr>

<tr>
<td align="right" colspan="2">
FirstName:
</td>
<td>
<asp:TextBox ID="txtFirstNameUpdate" runat="server" placeholder="First Name" ToolTip="First Name"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" id="rfvFirstNameUpdate" controltovalidate="txtFirstNameUpdate"
ValidationGroup="updateMember" errormessage="First Name is required!" Text="*" ForeColor="Red" />
<asp:RegularExpressionValidator ID="revFirstNameUpdate" runat="server" 
ControlToValidate="txtFirstNameUpdate"  ValidationGroup="updateMember"
ValidationExpression="^[a-zA-Z'.\s]{1,50}"
ErrorMessage="Enter a valid First name" Text="*" />   
</td>
</tr>

<tr>
<td align="right" colspan="2">
LastName:
</td>
<td>
<asp:TextBox ID="txtLastNameUpdate" runat="server" placeholder="Last Name" ToolTip="Last Name"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" id="rfvLastNameUpdate"
ValidationGroup="updateMember" controltovalidate="txtLastNameUpdate" errormessage="Last Name is required!" Text="*" ForeColor="Red" />
<asp:RegularExpressionValidator ID="revLastNameUpdate" runat="server" 
ControlToValidate="txtLastNameUpdate"  ValidationGroup="updateMember"
ValidationExpression="^[a-zA-Z'.\s]{1,50}"
ErrorMessage="Enter a valid Last name" Text="*" />   
</td>
</tr>

<tr>
<td align="right" colspan="2">
Email:
</td>
<td>
<asp:TextBox ID="txtEmailUpdate" runat="server" placeholder="Email Id" ToolTip="Email Id"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" id="rfvEmailUpdate"  ValidationGroup="updateMember" controltovalidate="txtEmailUpdate" errormessage="Email is required!" Text="*" ForeColor="Red" />
<asp:RegularExpressionValidator ID="revEmailUpdate" runat="server"  ValidationGroup="updateMember"
ControlToValidate="txtEmailUpdate" ErrorMessage="Enter a valid Email" 
ValidationExpression="^[^@]+@[^@]+\.[^@]+$" Text="*" />
</td>
</tr>

<tr>
<td align="right" colspan="2">
Password:
</td>
<td>
<asp:TextBox ID="txtPasswordUpdate" runat="server" placeholder="Password" ToolTip="Password"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" id="rfvtxtPasswordUpdate"  ValidationGroup="updateMember" controltovalidate="txtPasswordUpdate" errormessage="Password is required!" Text="*" ForeColor="Red" />
<asp:RegularExpressionValidator ID="revtxtPasswordUpdate" runat="server"  ValidationGroup="updateMember"
ControlToValidate="txtPasswordUpdate" ErrorMessage="Password should be between 8 and 32 characters" 
ValidationExpression="^.{8,32}$" Text="*" />
</td>
</tr>


<tr>
<td align="right" colspan="2" >
Mobile No:</td>
<td>
<asp:TextBox ID="txtMobileUpdate" runat="server" placeholder="Mobile No" ToolTip="Mobile No"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" id="rfvMobileUpdate"  ValidationGroup="updateMember" controltovalidate="txtMobileUpdate" errormessage="Mob No is required!" Text="*" ForeColor="Red" />
<asp:RegularExpressionValidator ID="revMobileUpdate" runat="server"  ValidationGroup="updateMember"
ControlToValidate="txtMobileUpdate" ErrorMessage="Enter a valid 10 digit Mobile No" 
ValidationExpression="[0-9]{10}" Text="*" ></asp:RegularExpressionValidator>
</td>
</tr>

<tr>
<td align="right" colspan="2" >
Role:
</td>
<td>
<asp:RadioButtonList ID="rblRoleidUpdate" runat="server">
<asp:ListItem>Member</asp:ListItem>
<asp:ListItem>Librarian</asp:ListItem>
</asp:RadioButtonList>
<asp:RequiredFieldValidator runat="server" id="rfvRoleUpdate"  ValidationGroup="updateMember" controltovalidate="rblRoleidUpdate" errormessage="Role is required!" Text="*" ForeColor="Red" />
</td>
</tr>

<tr>
<td align="right"  colspan="2" >
DOB:
</td>
<td align="left">
<asp:TextBox ID="txtDOBUpdate" runat="server" TextMode="Date" placeholder="Date of Birth" ToolTip="Date of Birth"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" id="rfvDateUpdate"  ValidationGroup="updateMember" controltovalidate="txtDOBUpdate" errormessage="Date of Birth is required!" Text="*" ForeColor="Red" />
<asp:RangeValidator id="RangeValidator1" runat="server"  ValidationGroup="updateMember"
Type="Date" ControlToValidate="txtDOBUpdate" 
MinimumValue="1/1/1950" 
MaximumValue="12/31/1995"
ErrorMessage="Please enter a valid date after 1950 and before 1995!!" Text="*"/>
</td>
</tr>

<tr>
<td></td>
<td></td>
<td align="left" ><asp:Button ID="btnUpdate" runat="server"  ValidationGroup="updateMember" Text="Update" OnClick="btnUpdate_Click"/>
    <asp:Button ID="btnResetUpdateMember" runat="server" Text="Reset"  OnClick="btnResetUpdateMember_Click" />
</td>
</tr>
      <tr>
        <td></td>
        <td></td>
        <td><asp:Label ID="lblUpdateMember" runat="server" ForeColor="red" BorderColor="Black" Font-Bold="true"></asp:Label></td>
        </tr>
<tr>
<tr>
<asp:ValidationSummary ID="ValidationSummary2"  ValidationGroup="updateMember" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false" HeaderText="You're missing a required field:" EnableClientScript="true"/>
</tr>

</table>
</asp:Panel>
</ContentTemplate>
</ajax:TabPanel>

<%--Delete Member Tab Panel--%>    
<ajax:TabPanel ID="tbpnldeletemember" runat="server" >
<HeaderTemplate>
Delete Member
</HeaderTemplate>
<ContentTemplate>
<asp:Panel ID="Panel2" runat="server">
<table align="center">

<tr>
<td align="right" colspan="2">
<b>UserId</b>
</td>
<td>
<asp:TextBox ID="txtUserIdDelete" runat="server" placeholder="User Id" ToolTip="User Id"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" id="rfvtxtUserIdDelete" controltovalidate="txtUserIdDelete"
ValidationGroup="deleteMember" errormessage="User Id is required!" Text="*" ForeColor="Red" />
     <asp:RegularExpressionValidator ID="revdeleteMember" runat="server" 
       ControlToValidate="txtUserIdDelete" 
       ValidationExpression="^\d*$"
       ValidationGroup="deleteMember" ErrorMessage="Enter a valid User Id" Text="*" />   
</td>    
        <td>  <asp:Button ID="btnGetDetailsDeleteUser" ValidationGroup="deleteMember" runat="server" Text="Check"  OnClick="btnGetDetailsDeleteUser_Click" /></td>
        <td><asp:Label ID="lblGetDetailsDelete" runat="server" ForeColor="red" BorderColor="Black" Font-Bold="true"></asp:Label></td>
</tr>    

 <asp:Panel ID="pnlCheckStatus" runat="server">
<tr>
<td></td><td></td>
<td></td>
<td align="left" ><asp:Button ID="btnCheckStatus" runat="server" Text="Status" ValidationGroup="deleteMember" OnClick="btnCheckStatus_Click"/>
    <td><asp:Label ID="lblStatus" runat="server" ForeColor="red" BorderColor="Black" Font-Bold="true"></asp:Label></td>     
</tr>
    </asp:Panel>


<asp:Panel ID="pnlDeleteUser" runat="server">
<tr>
<td></td>
<td></td>
<td align="left" ><asp:Button ID="btnDeleteMember" runat="server" ValidationGroup="deleteMember" Text="Delete" OnClick="btnDeleteMember_Click"/>
    <asp:Button ID="btnResetDeleteMember" runat="server" Text="Reset"  OnClick="btnResetDeleteMember_Click" />
</td>
</tr>
    </asp:Panel>
      <tr>
        <td></td>
        <td></td>
        <td><asp:Label ID="lblDeleteMember" runat="server" ForeColor="red" BorderColor="Black" Font-Bold="true"></asp:Label></td>
        </tr>
<tr>

<tr>
<asp:ValidationSummary ID="ValidationSummary3"  ValidationGroup="deleteMember" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false" HeaderText="You're missing a required field:" EnableClientScript="true"/>
</tr>

</table>
</asp:Panel>
</ContentTemplate>
</ajax:TabPanel>

</ajax:TabContainer>
</div>
</asp:Content>

