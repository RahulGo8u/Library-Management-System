<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SearchBooks.aspx.cs" Inherits="WebApplication1.SearchBooks" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h1>
        Select one Criteria
    </h1>
    <div class="searchfilter" style="width:auto;">
    <div class="options" style="width:200px ; float:left">
        <asp:RadioButtonList ID="rblsearchfilter" runat="server" Font-Bold="true" TextAlign="Right">

            <asp:ListItem Selected="True">Title</asp:ListItem>
            <asp:ListItem>Description</asp:ListItem>
            <asp:ListItem>Category</asp:ListItem>
            <asp:ListItem>Author</asp:ListItem>
            <asp:ListItem>Publisher</asp:ListItem>
            <asp:ListItem>ISBN No</asp:ListItem>
        </asp:RadioButtonList>

    </div>
        <div class="search" style="width:500px; float:left">
            <asp:TextBox ID="txtSearchBooks" runat="server" Width="300" placeholdder="Search All"></asp:TextBox>
            &nbsp &nbsp &nbsp &nbsp
            <asp:Button ID="btnSearchBooks" runat="server" Text="Search" Font-Bold="true" BorderStyle="Groove" OnClick="btnSearchBooks_Click1"/>
        </div>
        <br/><br/><br/><br/>
        <div class="bookdetails" style="width:500px; float:left">
            
            <asp:GridView ID="gvBookDetails" runat="server" CellPadding="4" ForeColor="#333333" AllowPaging="True" EmptyDataText="<b>No Records Found, Please refine your search</b>" AutoGenerateColumns="False">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Author" HeaderText="Author" />
                    <asp:BoundField DataField="Category" HeaderText="Category" />
                    <asp:BoundField DataField="Publisher" HeaderText="Publisher" />
                    <asp:BoundField DataField="ISBNNumber" HeaderText="ISBN No" />
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
            </div>
        </div>
</asp:Content>
