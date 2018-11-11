<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="MemberTransactions.aspx.cs" Inherits="WebApplication1.MemberTransactions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div style="width: 100%; height: 400px; overflow: scroll">    

<table align="center">

<tr>
<td>
<asp:Button ID="btnVwTransaction" runat="server" style="padding-left:0px" Text="View All Transactions"  onclick="btnViewSelfTransactions_Click" BackColor="Yellow" Width="150" Font-Bold="true"/>
</td>
<td align="right" >
</td>
</tr>

<tr>
<td align="right" colspan="2"></td>
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

</div>

</asp:Content>
