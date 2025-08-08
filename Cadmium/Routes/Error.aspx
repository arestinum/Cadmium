<%@ Page Title="" Language="C#" MasterPageFile="~/Routes/GlobalLayout.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Cadmium.Routes.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="flex flex-col gap-8 w-screen h-screen items-center justify-center">
                <h1 class="m-0">Error 404</h1>
                <p class="m-0">What you're looking for is not found, this is potentially to the page being removed or it simply doesn't exist.</p>
        </div>
</asp:Content>
