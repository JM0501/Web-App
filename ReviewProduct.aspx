<%@ Page Title="Review - OneTech" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReviewProduct.aspx.cs" Inherits="PapeD_Web.ReviewProduct" %>

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
                        <div class="contact_form_title">Review: "Product Name (display product name from DB)"</div>

                        <form runat="server" id="contact_form">
                            <div class="contact_form_text">
                                <asp:TextBox ID="txtMessage" runat="server" CssClass="text_field contact_form_message" TextMode="MultiLine" Rows="4" Placeholder="Message" required="required" data-error="Please, write us a message."></asp:TextBox>
                            </div>

                            <div class="contact_form_inputs d-flex flex-md-row flex-column justify-content-between align-items-between">
                                <asp:TextBox ID="txtStars" runat="server" CssClass="contact_form_name input_field" TextMode="Number" Placeholder="Stars" required="required" data-error="Stars are required."></asp:TextBox>
                            </div>

                            <div class="contact_form_button">
                                <asp:Button ID="btnSubmitReview" runat="server" CssClass="button contact_submit_button" Text="Submit Review" OnClick="btnSubmitReview_Click" />
                            </div>
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </form>

                    </div>
                </div>
            </div>
        </div>
        <div class="panel"></div>
    </div>
</asp:Content>
