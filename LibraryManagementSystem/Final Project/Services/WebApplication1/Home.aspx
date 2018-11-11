<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication1.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #logo {
            position: absolute;
            width: 300px;
            height: 200px;
            z-index: 15;
            top: 70%;
            left: 40%;
            margin: -100px 0 0 -150px;
        }
     .content
        {
         height: 40px;
    width: 500px;
    background: #000;
    font-size: 24px;
    font-style: oblique;
    color: #FFF;
    text-align: center;
    margin-top: 20px;
    margin-left: 215px;

        }

        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div > 
        <h1>Home</h1>
       
       </div>
<div>
<div>
        <div class="content">Welcome to Library</div><br/>
    <div class="content">The Library Management System[LMS]</div><br/>
    <div id="logo">
        <img src="Images/The%20Library%20Logo.jpg" width="600" height="200"/>
        </div>
       </div>
</div>
       
</asp:Content>
