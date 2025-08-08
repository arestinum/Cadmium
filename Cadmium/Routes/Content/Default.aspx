<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Cadmium.Routes.Content.Default" MasterPageFile="~/Routes/Content/DefaultContentLayout.Master" Title="Home page" %>

<asp:Content ContentPlaceHolderID="MainContent" ID="MainContent" runat="server">
        <div class="py-6 px-8">
                <p class="m-0">This is the default page</p>
                <% foreach (var i in System.IO.Directory.GetDirectories(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Routes"))) { %>
                        <%= i %>
                <% } %>
        </div>
</asp:Content>
