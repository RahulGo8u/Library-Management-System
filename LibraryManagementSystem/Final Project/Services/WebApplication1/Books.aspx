<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" EnableEventValidation="true" debug="true" Inherits="WebApplication1.Books" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<%--HEAD--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
<div style="width:100%; height:100%">

<%--Tab Container--%>
<ajax:tabcontainer ID="TabContainer1" runat="server">

<%--Add Book Panel--%>
<ajax:TabPanel ID="tbpnladdbook" runat="server" >
<HeaderTemplate>
Add New Book
</HeaderTemplate>
<ContentTemplate>
<asp:Panel ID="pnladdBooks" runat="server">
<table align="center">

<tr>
<td></td>
<td align="right" >
</td>
<td align="center">
<b>Add New Book</b>
</td>
</tr>

<tr>
<td></td>
<td align="right" >
Title:
</td>
<td>
<asp:TextBox ID="txtTitle" runat="server" placeholder="Title" ToolTip="Title"></asp:TextBox>  
<asp:RequiredFieldValidator runat="server" id="rfvTitle" controltovalidate="txtTitle"  ValidationGroup="addBooks" errormessage="Title is required!" Text="*" ForeColor="Red" />
<asp:RegularExpressionValidator ID="revtxtTitle" runat="server" 
ControlToValidate="txtTitle" 
ValidationGroup="addBooks"
ValidationExpression="^.{1,30}$"
ErrorMessage="Enter a valid Title" Text="*" />   
</td>
</tr>

<tr>
<td></td>
<td align="right" >
Description:
</td>
<td>
<asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" placeholder="Description" ToolTip="Description"></asp:TextBox>   
<asp:RequiredFieldValidator runat="server" id="rfvDescription" controltovalidate="txtDescription" ValidationGroup="addBooks" errormessage="Description is required!" Text="*" ForeColor="Red" />
<asp:RegularExpressionValidator ID="revtxtDescription" runat="server" 
ControlToValidate="txtDescription" 
ValidationGroup="addBooks" 
ValidationExpression="^.{1,60}$"
ErrorMessage="Enter a valid Description" Text="*" />   
</td>
</tr>

<tr>
<td></td>
<td align="right">
Category:
</td>
<td>
<asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" ></asp:DropDownList>
<asp:RequiredFieldValidator runat="server" id="rfvCategory" controltovalidate="ddlCategory" InitialValue="0" ValidationGroup="addBooks" errormessage="Please select category!" Text="*" ForeColor="Red" Display="Dynamic"/>    
    
</td>
</tr>

<tr>
<td></td>
<td align="right">
Author:
</td>
<td>
<asp:TextBox ID="txtAuthor" runat="server" placeholder="Author" ToolTip="Author"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" id="rfvtxtAuthor" controltovalidate="txtAuthor" 
ValidationGroup="addBooks"
errormessage="Author Name is required!" Text="*" ForeColor="Red" />
<asp:RegularExpressionValidator ID="revtxtAuthor" runat="server" 
ControlToValidate="txtAuthor" ValidationGroup="addBooks"
ValidationExpression="^[a-zA-Z'.\s]{1,30}"
ErrorMessage="Enter a valid Author name" Text="*" />   
</td>
</tr>

<tr>
<td></td>
<td align="right">
Publisher:
</td>
<td>
<asp:TextBox ID="txtPublisher" runat="server" placeholder="Publisher" ToolTip="Publisher"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" id="rfvtxtPublisher" controltovalidate="txtPublisher" 
ValidationGroup="addBooks"
errormessage="Publisher Name is required!" Text="*" ForeColor="Red" />
<asp:RegularExpressionValidator ID="revtxtPublisher" runat="server" 
ControlToValidate="txtPublisher" ValidationGroup="addBooks"
ValidationExpression="^[a-zA-Z'.\s]{1,30}"
ErrorMessage="Enter a valid Publisher name" Text="*" />   
</td>
</tr>

<tr>
<td></td>
<td align="right" >
Price:
</td>
<td>
<asp:TextBox ID="txtPrice" runat="server" placeholder="Price" ToolTip="Price"></asp:TextBox>    
<asp:RequiredFieldValidator runat="server" id="rfvPrice" controltovalidate="txtPrice" 
ValidationGroup="addBooks"
errormessage="Price is required!" Text="*" ForeColor="Red" />
<asp:RegularExpressionValidator ID="revPrice" runat="server" 
ControlToValidate="txtPrice" ValidationGroup="addBooks"
ValidationExpression="^(?!\.?$)\d{0,8}(\.\d{0,2})?$"
ErrorMessage="Enter a valid Price" Text="*" />   
</td>
</tr>

<tr>
<td></td>
<td align="right" >
ISBN No:
</td>
<td align="left">
<asp:TextBox ID="txtISBN" runat="server" placeholder="ISBN No" ToolTip="ISBN No"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" id="rfvISBNAdd" controltovalidate="txtISBN" 
ValidationGroup="addBooks"
errormessage="ISBN is required!" Text="*" ForeColor="Red" />
</td>
</tr>
    
<tr>
<td></td>
<td></td>
<td align="left" ><asp:Button ID="btnSubmitBook" runat="server" ValidationGroup="addBooks" Text="Save" onclick="btnSubmitBook_Click"/>
<%--<input type="reset" value="Reset" />--%>
<asp:Button ID="btnResetBook" runat="server" Text="Reset" onclick="btnResetBook_Click" />
</td>
</tr>

<tr>
<td></td><td></td>
<td><asp:Label ID="lblAddBook" runat="server" ForeColor="red" BorderColor="Black" Font-Bold="true"></asp:Label></td>
</tr>
<tr>

<tr>
<asp:ValidationSummary ID="ValidationSummary1"  ValidationGroup="addBooks" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false" HeaderText="You're missing a required field:" EnableClientScript="true"/>
</tr>

</table>
</asp:Panel>
</ContentTemplate>
</ajax:TabPanel>


<%--Add Category Panel--%>
<ajax:TabPanel ID="tbpnlctgry" runat="server"  >
<HeaderTemplate>
Add New Category
</HeaderTemplate>
<ContentTemplate>
<div style="width: 100%; height: 400px; overflow: scroll">
<asp:Panel ID="pnlctgry" runat="server">
    
<table align="center">
<tr>
<td>
<asp:Button ID="btnVwctgry" runat="server" style="padding-left:0px" Text="View All Categories" onclick="btnViewAllCategories_Click" BackColor="Yellow" Width="150" Font-Bold="true"/>
</td>
<td align="right" >
</td>
</tr>

<tr>
<td align="left"></td>
<td></td>
</tr>
        <asp:GridView ID="gvCategories" runat="server" BackColor="White" BorderColor="#CC9966" 
        AlternatingRowStyle-BackColor="WhiteSmoke" AutoGenerateColumns="False" AllowPaging="True"
        BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Both" EmptyDataText = "No Records Found" 
         PageSize = "5" onpageindexchanging="gvCategories_PageIndexChanging">
        <Columns>
                    <asp:BoundField DataField="Category" HeaderText="Category" />                  
        </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099"></FooterStyle>

        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC"></HeaderStyle>

        <PagerStyle HorizontalAlign="Center" BackColor="#FFFFCC" ForeColor="#330099"></PagerStyle>

        <RowStyle BackColor="White" ForeColor="#330099"></RowStyle>

        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399"></SelectedRowStyle>

        <SortedAscendingCellStyle BackColor="#FEFCEB"></SortedAscendingCellStyle>

        <SortedAscendingHeaderStyle BackColor="#AF0101"></SortedAscendingHeaderStyle>

        <SortedDescendingCellStyle BackColor="#F6F0C0"></SortedDescendingCellStyle>

        <SortedDescendingHeaderStyle BackColor="#7E0000"></SortedDescendingHeaderStyle>
    </asp:GridView>
    <br/><br/><br/>
    
<tr>
<td align="right">
Add New Category:
</td>
<td>
<asp:TextBox ID="txtnwCategory" runat="server" placeholder="Category" ToolTip="Category"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" id="rfvtxtnwCategory" controltovalidate="txtnwCategory" ValidationGroup="addCategory" errormessage="Category is required!" Text="*" ForeColor="Red" />    
<asp:RegularExpressionValidator ID="revtxtnwCategory" runat="server" 
ControlToValidate="txtnwCategory" ValidationGroup="addCategory"
ValidationExpression="^[a-zA-Z'.\s]{1,30}"
ErrorMessage="Enter a valid Category name" Text="*" />   
</td>
</tr>

<tr>
<td></td>
<td align="right">
    <asp:Button ID="btnAddCtgry" runat="server" Text="Add" ValidationGroup="addCategory" OnClick="btnAddCategory_Click"/>
<asp:Button ID="btnResetCategory" runat="server" Text="Reset" OnClick="btnResetCategory_Click"/>

</td>

</tr>

<tr>
<td></td><td></td>
<td><asp:Label ID="lblAddCategory" runat="server" ForeColor="red" BorderColor="Black" Font-Bold="true"></asp:Label></td>
</tr>

<tr>
<tr>
<asp:ValidationSummary ID="ValidationSummary5"  ValidationGroup="addCategory" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false" HeaderText="You're missing a required field:" EnableClientScript="true"/>
</tr>
<br/>
</table>
</asp:Panel>
</div>
</ContentTemplate>
</ajax:TabPanel>


<%--Update Book Panel--%>
<ajax:TabPanel ID="tbpnlupdatebook" runat="server" >
<HeaderTemplate>
Update Book
</HeaderTemplate>

<ContentTemplate>
    
<table align="center">
   
<tr>
<td align="right" colspan="2">
<b>Book Id</b>
</td>
<td>
<asp:TextBox ID="txtBookIdUpdate" runat="server" placeholder="Book Id" ToolTip="Book Id"></asp:TextBox>  
<asp:RequiredFieldValidator runat="server" id="rfvtxtBookIdUpdate" controltovalidate="txtBookIdUpdate" errormessage="BookId is required!" Text="*" ValidationGroup="getbook" ForeColor="Red" />
<asp:RegularExpressionValidator ID="revtxtBookIdUpdate" runat="server" 
ControlToValidate="txtBookIdUpdate" 
ValidationExpression="^\d*$"
ValidationGroup="getbook" ErrorMessage="Enter a valid Book Id" Text="*" />   
</td>
<td><asp:Button ID="btnGetDetailsUpdateBook" runat="server" Text="Get Details" OnClick="btnGetDetailsUpdateBook_Click" ValidationGroup="getbook" /></td>
<td><asp:Label ID="lblStatusBookId" runat="server" ForeColor="red" BorderColor="Black" Font-Bold="true"></asp:Label></td>
<asp:ValidationSummary ID="ValidationSummary4"  ValidationGroup="getbook" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false" HeaderText="You're missing a required field:" EnableClientScript="true"/>
</tr>

</table>
<asp:Panel ID="pnlGetBookDetails" runat="server">
<table align="center">

<tr>
<td align="right" colspan="2" >
</td>
<td>
<b>Book Details</b>
</td>
</tr>

<tr>
<td align="right" colspan="2">
Title:
</td>
<td>
<asp:TextBox ID="txtTitleUpdate" runat="server" placeholder="Title" ToolTip="Title"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" id="rfvFirstNameUpdate" controltovalidate="txtTitleUpdate" ValidationGroup="updatebook" errormessage="Title is required!" Text="*" ForeColor="Red" />
<asp:RegularExpressionValidator ID="revTitleUpdate" runat="server" 
ControlToValidate="txtTitleUpdate" 
ValidationExpression="^.{1,30}$"
ValidationGroup="updatebook" ErrorMessage="Enter a valid Title" Text="*" />   
</td>
</tr>

<tr>
<td align="right" colspan="2">
Description:
</td>
<td>
<asp:TextBox ID="txtDescriptionUpdate" runat="server" TextMode="MultiLine" placeholder="Description" ToolTip="Description"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" id="rfvDescriptionUpdate" controltovalidate="txtDescriptionUpdate" ValidationGroup="updatebook" errormessage="Description is required!" Text="*" ForeColor="Red" />
<asp:RegularExpressionValidator ID="revDescriptionUpdate" runat="server" 
ControlToValidate="txtDescriptionUpdate" 
ValidationGroup="updatebook" ValidationExpression="^.{1,60}$"
ErrorMessage="Enter a valid Description" Text="*" />   
</td>
</tr>

<tr>
<td align="right" colspan="2">
Category:
</td>
<td>
<asp:DropDownList ID="ddlCategoryUpdate" runat="server" AutoPostBack="true"></asp:DropDownList>
<asp:RequiredFieldValidator runat="server" id="rfvCategoryUpdate" controltovalidate="ddlCategoryUpdate" InitialValue="0" ValidationGroup="updatebook" errormessage="Please select category!" Text="*" ForeColor="Red" Display="Dynamic"/>    
    
</td>
</tr>

<tr>
<td align="right" colspan="2" >
Author:</td>
<td>
<asp:TextBox ID="txtAuthorUpdate" runat="server" placeholder="Author" ToolTip="Author"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" id="rfvAuthor" controltovalidate="txtAuthorUpdate" ValidationGroup="updatebook" errormessage="Author is required!" Text="*" ForeColor="Red" />
<asp:RegularExpressionValidator ID="revAuthorUpdate" runat="server" 
ControlToValidate="txtAuthorUpdate" 
ValidationExpression="^[a-zA-Z'.\s]{1,30}"
ValidationGroup="updatebook" ErrorMessage="Enter a valid Author" Text="*" />   
</td>
</tr>

<tr>
<td align="right" colspan="2" >
Publisher:
</td>
<td>
<asp:TextBox ID="txtPublisherUpdate" runat="server" placeholder="Publisher" ToolTip="Publisher"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" id="rfvPublisherUpdate" controltovalidate="txtPublisherUpdate" ValidationGroup="updatebook" errormessage="Publisher is required!" Text="*" ForeColor="Red" />
<asp:RegularExpressionValidator ID="revPublisherUpdate" runat="server" 
 ControlToValidate="txtPublisherUpdate" 
ValidationExpression="^[a-zA-Z'.\s]{1,30}"
ValidationGroup="updatebook" ErrorMessage="Enter a valid Publisher" Text="*" />  
</td>
</tr>

<tr>
<td align="right"  colspan="2" >
Price:
</td>
<td align="left">
<asp:TextBox ID="txtPriceUpdate" runat="server" placeholder="Price" ToolTip="Price"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" id="rfvPriceUpdate" controltovalidate="txtPriceUpdate" ValidationGroup="updatebook" errormessage="Price is required!" Text="*" ForeColor="Red" />
<asp:RegularExpressionValidator ID="revPriceUpdate" runat="server" 
       ControlToValidate="txtPriceUpdate" 
       ValidationExpression="^(?!\.?$)\d{0,8}(\.\d{0,2})?$"
       ValidationGroup="updatebook" ErrorMessage="Enter a valid Price" Text="*" /> 
</td>
</tr>

<tr>
<td align="right" colspan="2">
ISBN No:
</td>
<td>
<asp:TextBox ID="txtISBNUpdate" runat="server" placeholder="ISBN No" ToolTip="ISBN No"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" id="rfvISBN" controltovalidate="txtISBNUpdate" ValidationGroup="updatebook" errormessage="ISBN No is required!" Text="*" ForeColor="Red" />
</td>
</tr>

<tr>
<td></td>
<td align="right" >
Status:
</td>
<td>
<asp:RadioButtonList ID="rblStatus" runat="server" Enabled="false">
<asp:ListItem>Issued</asp:ListItem>
<asp:ListItem>Available</asp:ListItem>
</asp:RadioButtonList>
<asp:RequiredFieldValidator runat="server" id="reqStatus" ValidationGroup="updatebook" controltovalidate="rblStatus" errormessage="Status is required!" Text="*" ForeColor="Red" />
</td>
</tr>

<tr>
<td></td>
<td></td>
<td align="left" >
<asp:Button ID="btnUpdateBook" ValidationGroup="updatebook" runat="server" Text="Update" OnClick="btnUpdateBook_Click"/>
<asp:Button ID="btnResetUpdateBook" runat="server" Text="Reset"  OnClick="btnResetUpdateBook_Click" />

</td>
</tr>

<tr>
<td></td><td></td>
<td><asp:Label ID="lblUpdateBook" runat="server" ForeColor="red" BorderColor="Black" Font-Bold="true"></asp:Label></td>
</tr>

<tr>
<asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false" ValidationGroup="updatebook" HeaderText="You're missing a required field:" EnableClientScript="true"/>
</tr>

</table>    
</asp:Panel>
</ContentTemplate>
</ajax:TabPanel>

<%--Delete Book Panel--%>
<ajax:TabPanel ID="tbpnldeletebook" runat="server" >
<HeaderTemplate>
Delete Book
</HeaderTemplate>
<ContentTemplate>
<table align="center">

<tr>
<td align="right" colspan="2">
<b>Book Id</b>
</td>
<td>
<asp:TextBox ID="txtBookIdDelete" runat="server" placeholder="Book Id" ToolTip="Book Id"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" id="rfvtxtBookIdDelete" controltovalidate="txtBookIdDelete" errormessage="BookId is required!" Text="*" ValidationGroup="deletebook" ForeColor="Red" />
    <asp:RegularExpressionValidator ID="revtxtBookIdDelete" runat="server" 
       ControlToValidate="txtBookIdDelete" 
       ValidationExpression="^\d*$"
       ValidationGroup="deletebook" ErrorMessage="Enter a valid Book Id" Text="*" />   
</td>
<td>  <asp:Button ID="btnGetDetailsDeleteBook" ValidationGroup="deletebook" runat="server" Text="Check"  OnClick="btnGetDetailsDeleteBook_Click" /></td>
<td><asp:Label ID="lblGetDetailsDelete" runat="server" ForeColor="red" BorderColor="Black" Font-Bold="true"></asp:Label></td>     
</tr>

<asp:Panel ID="pnlCheckStatus" runat="server">
<tr>
<td></td><td></td>
<td></td>
<td align="left" ><asp:Button ID="btnCheckStatus" runat="server" Text="Status" ValidationGroup="deletebook" OnClick="btnCheckStatus_Click"/>
    <td><asp:Label ID="lblStatus" runat="server" ForeColor="red" BorderColor="Black" Font-Bold="true"></asp:Label></td>     
</tr>
    </asp:Panel>

<asp:Panel ID="pnlDeleteBook" runat="server">
<tr>
<td></td>
<td></td>
<td align="left" ><asp:Button ID="btnDeleteBook" runat="server" Text="Delete" ValidationGroup="deletebook" OnClick="btnDeleteBook_Click"/>
<asp:Button ID="btnResetDeleteBook" runat="server" Text="Reset"  OnClick="btnResetDeleteBook_Click" />
</td>
</tr>
</asp:Panel>
   
<tr>
<td></td><td></td>
<td><asp:Label ID="lblDeleteBook" runat="server" ForeColor="red" BorderColor="Black" Font-Bold="true"></asp:Label></td>
</tr>

<tr>
<asp:ValidationSummary ID="ValidationSummary3"  ValidationGroup="deletebook" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false" HeaderText="You're missing a required field:" EnableClientScript="true"/>
</tr>

</table>
</ContentTemplate>
</ajax:TabPanel>

</ajax:tabcontainer>
</asp:Content>
