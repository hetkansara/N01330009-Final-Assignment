<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DocumentDelete.aspx.cs" Inherits="N01330009_Final_Assignment.DocumentDelete" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h3>
                    <asp:LinkButton OnClick="Go_Back" class="back-btn" title="Back" runat="server"> 
                        <i class="fas fa-arrow-left"></i>
                    </asp:LinkButton>
                    Are you sure you want to delete document - <span id="documentTitle" runat="server"></span>?</h3>
            </div>
            <div class="col-md-12">
                <asp:Button OnClick="Delete_Document" title="Confirm Delete Document" runat="server" Text="Yes" />
                <asp:Button OnClick="Go_Back" title="Cancel" runat="server" Text="No" />
            </div>
        </div>
    </div>
</asp:Content>
