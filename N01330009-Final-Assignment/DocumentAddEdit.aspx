<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="DocumentAddEdit.aspx.cs" Inherits="N01330009_Final_Assignment.DocumentAddEdit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="form-row">
            <div class="col-md-12">
                <h2>
                    <a href="DocumentList.aspx" id="backButton" runat="server" class="back-btn" title="Back">
                        <i class="fas fa-arrow-left"></i>
                    </a>
                    <span runat="server" id="pageTypeTitle"></span><span id="pageType" runat="server"></span>Document</h2>
            </div>
        </div>
        <div class="form-row">
            <div class="col-md-12">
                <label for="pagetitle">Page Title</label>
                <asp:TextBox ID="pageTitle" class="form-control" runat="server" aria-describedby="pagetitle" placeholder="Enter Page Title"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="pagetitle" ErrorMessage="enter enrollment date"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-12">
                <label for="pagetitle">Page Content</label>
                <asp:TextBox class="content" ID="pageContent" TextMode="multiline" Columns="50" Rows="5" runat="server" />
            </div>
        </div>
        <div class="form-row">
            <div class="col-md-12">
                <asp:Button OnClick="Add_Edit_Document" runat="server" Text="Submit" class="btn btn-primary submit-btn" />
            </div>
        </div>
        <div id="output" runat="server">
        </div>
    </div>
</asp:Content>
