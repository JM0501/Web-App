<%@ Page Title="Cart - OneTech" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="PapeD_Web.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Your Cart</h2>
       <!-- Literal to store Cart items -->
    <asp:Literal ID="cartLiteral" runat="server"></asp:Literal>
</asp:Content>

