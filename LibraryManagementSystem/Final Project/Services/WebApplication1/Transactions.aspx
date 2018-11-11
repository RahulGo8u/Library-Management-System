<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Transactions.aspx.cs" Inherits="WebApplication1.Transactions" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
<div style=" width:100%">

<%--Tab Container--%>
<ajax:tabcontainer ID="TabContainer1" runat="server">

<%--Issue Book--%>
<ajax:TabPanel ID="tbpnlissuebook" runat="server" >

<HeaderTemplate>
Issue Book
</HeaderTemplate>

<ContentTemplate>

<table align="center">

<tr>
<td align="right" colspan="2">
<b>Book Id</b>
</td>
<td>
<asp:TextBox ID="txtBookIdIssue" runat="server" placeholder="Book Id" ToolTip="Book Id"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" id="rfvtxtBookIdIssue" controltovalidate="txtBookIdIssue" ValidationGroup="issuereq" errormessage="Book Id is required!" Text="*" ForeColor="Red" />
<asp:RegularExpressionValidator ID="revtxtBookIdIssue" runat="server" 
ControlToValidate="txtBookIdIssue" 
ValidationExpression="^\d*$"
ValidationGroup="issuereq" ErrorMessage="Enter a valid Book Id" Text="*" />   
</td>
<td>
<asp:Button ID="btnCheckBookAvlblty" runat="server" ValidationGroup="issuereq" Text="Check Availability" onclick="btnCheckBookAvlblty_Click"/>
</td>    
<td>
<asp:ValidationSummary ID="ValidationSummary1"  ValidationGroup="issuereq" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false" HeaderText="You're missing a required field:" EnableClientScript="true"/>
</td>
</tr>
      <tr>
        <td></td>
        <td></td>
        <td><asp:Label ID="lblBookAvlblty" runat="server" ForeColor="red" BorderColor="Black" Font-Bold="true"></asp:Label></td>
          <td></td><td></td>
        </tr>

</table>
    
<table align="center">

     
<tr>
<td></td>
<td align="right" >
UserId:
</td>
<td>
<asp:TextBox ID="txtUserIdIssue" runat="server" placeholder="User Id" ToolTip="User Id"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" id="rfvtxtUserIdIssue" controltovalidate="txtUserIdIssue" ValidationGroup="chkusr" errormessage="User Id is required!" Text="*" ForeColor="Red" />
     <asp:RegularExpressionValidator ID="revtxtUserIdIssue" runat="server" 
       ControlToValidate="txtUserIdIssue" 
       ValidationExpression="^\d*$"
       ValidationGroup="chkusr" ErrorMessage="Enter a valid User Id" Text="*" />   
</td>
<td>
<asp:Button ID="chkUserIdIssue" runat="server" ValidationGroup="chkusr" Text="Check User" onclick="CheckMemberAvlblty_Click"/>
<asp:ValidationSummary ID="ValidationSummary3" ValidationGroup="chkusr" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false" HeaderText="You're missing a required field:" EnableClientScript="true"/>
</td>
<td></td>
</tr>

<tr>
<td></td><td></td>
<td><asp:Label ID="lblMemberAvlblty" runat="server" ForeColor="red" BorderColor="Black" Font-Bold="true"></asp:Label></td>
</tr>
<tr>


<tr>
<td></td>
<td align="right" >
Issue Date:
</td>
<td>
<asp:TextBox ID="txtIssueDate" runat="server" TextMode="Date" placeholder="Issue Date" ToolTip="Issue Date"></asp:TextBox>
</td>
</tr>

<tr>
<td></td>
<td align="right">
Due Date:
</td>
<td>
<asp:TextBox ID="txtDueDate" runat="server" TextMode="Date" placeholder="Due Date" ToolTip="Due Date"></asp:TextBox>
</td>
</tr>

<tr>
<td></td>
<td></td>
<td align="left" >
<asp:Button ID="btnIssueBook" runat="server" Text="Issue" OnClick="btnIssueBook_Click"/>
<asp:Button ID="btnResetIssueBook" runat="server" Text="Reset" OnClick="btnResetIssueBook_Click" />
</td>
</tr>

      <tr>
        <td></td>
        <td></td>
        <td><asp:Label ID="lblIssueBook" runat="server" ForeColor="red" BorderColor="Black" Font-Bold="true"></asp:Label></td>
        </tr>
<tr>
</table>

</ContentTemplate>
</ajax:TabPanel>

<%--Return Book--%>
<ajax:TabPanel ID="tbpnlreturnbook" runat="server" >
<HeaderTemplate>
Return Book
</HeaderTemplate>
<ContentTemplate>

<table align="center">
   
<tr>
<td align="right" colspan="2">
<b>Book Id</b>
</td>
<td>
<asp:TextBox ID="txtBookIdReturn" runat="server" placeholder="Book Id" ToolTip="Book Id"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" id="rfvtxtBookIdReturn" controltovalidate="txtBookIdReturn" ValidationGroup="chkbookrtrn" errormessage="Book Id is required!" Text="*" ForeColor="Red" />
</td>
<td>
<asp:Button ID="btnGetDetailsReturnBook" runat="server" ValidationGroup="chkbookrtrn" Text="Get Details" onclick="btnGetDetailsReturnBook_Click"/>
<asp:ValidationSummary ID="ValidationSummary4"  ValidationGroup="chkbookrtrn" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false" HeaderText="You're missing a required field:" EnableClientScript="true"/>
</td>
    
<td>
    <asp:Label ID="lblGetReturnDetails" runat="server" ForeColor="red" BorderColor="Black" Font-Bold="true"></asp:Label>
</td>
</tr>

</table>


<table align="center">
<tr>
<td align="right" colspan="2" >
</td>
<td>
<b>Transaction Details</b>
</td>
</tr>

<tr>
<td align="right" colspan="3">
<asp:GridView ID="gvTransactionReturn" runat="server"></asp:GridView>
</td>
</tr>

<tr>
<td align="right" colspan="2">
Return Date:
</td>
<td>
<asp:TextBox ID="txtReturnDate" runat="server" TextMode="Date" placeholder="Return Date" ToolTip="Return Date"></asp:TextBox>
</td>
</tr>

<tr>
<td></td>
<td></td>
<td align="left" >
<asp:Button ID="btnReturnBook" runat="server" Text="Return" OnClick="btnReturnBook_Click"/>
<asp:Button ID="btnResetReturnBook" runat="server" Text="Reset" OnClick="btnResetReturnBook_Click" />

</td>
</tr>
      <tr>
        <td></td>
        <td></td>
        <td><asp:Label ID="lblReturnBook" runat="server" ForeColor="red" BorderColor="Black" Font-Bold="true"></asp:Label></td>
        </tr>
<tr>
<tr>
<asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false" HeaderText="You're missing a required field:" EnableClientScript="true"/>
</tr>

</table>
</ContentTemplate>
</ajax:TabPanel>

<%--View All Transactions--%>
<ajax:TabPanel ID="tbpnlviewalltransactions" runat="server" >
<HeaderTemplate>
View All Transactions
</HeaderTemplate>
<ContentTemplate>
<div style="width: 100%; height: 400px; overflow: scroll">
<asp:Panel ID="pnlTransaction" runat="server">
<table align="center">

<tr>
<td>
<asp:Button ID="btnVwTransaction" runat="server" style="padding-left:0px" Text="View All Transactions" onclick="btnViewAllTransactions_Click" BackColor="Yellow" Width="150" Font-Bold="true"/>
</td>
<td align="right" >
</td>
</tr>
<tr>
<td align="right" colspan="2">
</td>
<td>
<asp:GridView ID="gvAllTransactions" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both" AllowPaging="True" AutoGenerateColumns="False" 
                EmptyDataText="No Records Found" PageSize = "10" onpageindexchanging="gvAllTransactions_PageIndexChanging">
                          <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                          <EditRowStyle BackColor="#999999" />
                    <Columns>
                    <asp:BoundField DataField="TransactionId" HeaderText="TransactionId" />
                    <asp:BoundField DataField="UserId" HeaderText="UserId" />
                    <asp:BoundField DataField="BookId" HeaderText="BookId" />
                    <asp:BoundField DataField="IssueDate" HeaderText="IssueDate" />
                    <asp:BoundField DataField="DueDate" HeaderText="DueDate" />
                    <asp:BoundField DataField="ReturnDate" HeaderText="ReturnDate" />
                    </Columns>            
                          <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                          <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                          <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                          <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                          <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                          <SortedAscendingCellStyle BackColor="#E9E7E2" />
                          <SortedAscendingHeaderStyle BackColor="#506C8C" />
                          <SortedDescendingCellStyle BackColor="#FFFDF8" />
                          <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
</asp:GridView>
</td>
<td></td>
</tr>
</table>
</asp:Panel>
</div>

</ContentTemplate>
</ajax:TabPanel>
</ajax:tabcontainer>
</asp:Content>
