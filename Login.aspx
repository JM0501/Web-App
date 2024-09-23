<%@ Page Title="Login - OneTech" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PapeD_Web.Login" %>
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
                        <div class="contact_form_title">User Login</div>

                        <form id="contact_form" runat="server">
                            <div class="contact_form_inputs d-flex flex-md-row flex-column justify-content-between align-items-between">
                                <input type="email" id="email" class="contact_form_email input_field" placeholder="Your email" required="required" data-error="Email is required." runat="server">
                                
                            </div>
                            <div class="contact_form_inputs d-flex flex-md-row flex-column justify-content-between align-items-between">
                                <input type="password" id="password" class="contact_form_name input_field" placeholder="Your Password" required="required" data-error="password is required." runat="server"><br />
                                
                            </div>
                             <div class="clear">
                                    <asp:Label ID="error" runat="server" Text=""></asp:Label>
                                </div>

                            <div class="contact_form_button">
                                <asp:Button ID="btnLogin" runat="server" Text="Login" type="submit" class="button contact_submit_button" OnClick="btnLogin_Click" />
                            </div>
                        </form>
                        <br />
                    </div>
                </div>
            </div>
        </div>
        
    </div>

</asp:Content>
