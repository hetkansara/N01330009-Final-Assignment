<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DocumentList.aspx.cs" Inherits="N01330009_Final_Assignment.DocumentList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="form-row search-container">
            <div class="col-md-11">
                <label for="searchText">Search</label>
                <asp:TextBox runat="server" ID="searchText" class="form-control" aria-describedby="searchText" placeholder="Search documents..."></asp:TextBox>
            </div>
            <div class="col-md-1 search-container">
                <asp:Button runat="server" Text="Search" class="btn btn-primary search-btn" />
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-2">
            <div class="add-btn-container">
                <asp:LinkButton OnClick="Add_Document" ID="addButton" runat="server" class="add-btn" title="Add Document">
                    <i class="fas fa-plus"></i>
                </asp:LinkButton>
            </div>
        </div>
        <div id="document_list" runat="server">
        </div>
        <div id="NoResultMsg" class="col-md-10 no-data-found" runat="server"></div>
    </div>

</asp:Content>
