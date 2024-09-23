<%@ Page Title="AddProduct - OneTech" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="PapeD_Web.AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="description" content="OneTech shop project">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" type="text/css" href="styles/bootstrap4/bootstrap.min.css">
    <link href="plugins/fontawesome-free-5.0.1/css/fontawesome-all.css" rel="stylesheet" type="text/css">
    <link rel="stylesheet" type="text/css" href="styles/contact_styles.css">
    <link rel="stylesheet" type="text/css" href="styles/contact_responsive.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Contact Form -->

    <div class="contact_form">
        <div class="container">
            <div class="row">
                <div class="col-lg-10 offset-lg-1">
                    <div class="contact_form_container">
                        <div class="contact_form_title">Add Product</div>

                        <form id="contact_form" runat="server">
                            <div class="contact_form_inputs d-flex flex-md-row flex-column justify-content-between align-items-between">
                                <asp:TextBox ID="txtName" runat="server" CssClass="contact_form_name input_field" Placeholder="Product Name"></asp:TextBox>
                            </div>

                            <div class="contact_form_inputs d-flex flex-md-row flex-column justify-content-between align-items-between">
                                <asp:TextBox ID="txtPrice" runat="server" CssClass="contact_form_price input_field" Placeholder="Product Price" TextMode="Number"></asp:TextBox>
                            </div>

                            <div class="contact_form_inputs d-flex flex-md-row flex-column justify-content-between align-items-between">
                                <asp:TextBox ID="txtQuantity" runat="server" CssClass="contact_form_quantity input_field" Placeholder="Number of Products" TextMode="Number"></asp:TextBox>
                            </div>

                            <div class="contact_form_inputs d-flex flex-md-row flex-column justify-content-between align-items-between">
                                <asp:TextBox ID="txtDesc" runat="server" CssClass="contact_form_description input_field"
                                    Placeholder="Product Description" TextMode="MultiLine" Rows="5" Columns="30"
                                    Style="width: 100%; height: 150px; resize: none;"></asp:TextBox>
                            </div>

                             <div class="contact_form_inputs d-flex flex-md-row flex-column justify-content-between align-items-between">
                                <asp:TextBox ID="txtCategory" runat="server" CssClass="contact_form_img input_field" Placeholder="Product Category"></asp:TextBox>
                            </div>

                             <div class="contact_form_inputs d-flex flex-md-row flex-column justify-content-between align-items-between">
                                <asp:TextBox ID="txtType" runat="server" CssClass="contact_form_img input_field" Placeholder="Product Status"></asp:TextBox>
                            </div>

                            <div class="contact_form_inputs d-flex flex-md-row flex-column justify-content-between align-items-between">
                                <asp:TextBox ID="txtImg" runat="server" CssClass="contact_form_img input_field" Placeholder="Product Image Link"></asp:TextBox>
                            </div>

                            <div class="contact_form_button">
                                <asp:Button ID="btnAdd" runat="server" Text="Add Product" CssClass="button contact_submit_button" OnClick="btnAdd_Click" />
                            </div>
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </form>

                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
