<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Cadmium.Default" %>
<%@ Import Namespace="System.Text.Json" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        JsonSerializerOptions options = new JsonSerializerOptions 
        { 
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        Response.ContentType = "application/json";
        Response.Write(JsonSerializer.Serialize(Application["Application::RouteTrees"], options));
    }
</script>