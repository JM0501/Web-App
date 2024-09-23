<%@ Page Title="Register - OneTech" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserRrgister.aspx.cs" Inherits="PapeD_Web.UserRrgister" %>
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
                        <div class="contact_form_title">User Registration</div>

                        <form id="contact_form" runat="server">
                        <div class="contact_form_inputs d-flex flex-md-row flex-column justify-content-between align-items-between">
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="contact_form_name input_field" placeholder="Your Name" required="required" data-error="Name is required."></asp:TextBox>
                        </div>
                        <div class="contact_form_inputs d-flex flex-md-row flex-column justify-content-between align-items-between">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="contact_form_email input_field" placeholder="Your email" required="required" data-error="Email is required." TextMode="Email"></asp:TextBox>
                        </div>
                        <div class="contact_form_inputs d-flex flex-md-row flex-column justify-content-between align-items-between">
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="contact_form_password input_field" placeholder="Your Password" required="required" data-error="Password is required." TextMode="Password"></asp:TextBox>
                        </div>
                       <div id="userTypeContainer" runat="server" style="display: none;">
                        <div class="contact_form_inputs d-flex flex-md-row flex-column justify-content-between align-items-between">
                            <asp:TextBox ID="txtUserType" runat="server" CssClass="contact_form_name input_field" placeholder="UserType"></asp:TextBox>
                        </div>
                       </div>
                        <div class="contact_form_button">
                            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="button contact_submit_button" OnClick="btnRegister_Click" />
                        </div>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                    </form>

                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
