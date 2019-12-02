<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DocumentView.aspx.cs" Inherits="N01330009_Final_Assignment.DocumentView" %>

    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="container document-viewer">
                        <div class="document-header">

                            <h2 id="documentTitle" runat="server">
                            </h2>
                            <p id="createdOn" runat="server" class="page-date-created">
                            </p>

                        </div>
                        <div class="document-view-container" id="documentBody" runat="server">

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Content>