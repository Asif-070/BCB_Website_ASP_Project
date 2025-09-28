<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewsDetails.aspx.cs" Inherits="trial.NewsDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/fixture.css" rel="stylesheet" />
    <style>
        .rom {
        margin: 20px;
        }

        .rom label {
            font-weight: bold;
            font-size: 20px;
        }

        .rom img {
            margin-top: 20px;
            margin-bottom: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rommain">
        <div class="rom">
            <asp:Label ID="lblTitle" runat="server" Font-Size="XX-Large" Font-Bold="True" Text="Label"></asp:Label><br />
            <asp:Image ID="imgNews" runat="server" width="785px" AlternateText="No Image Currently Available"/><br />
            <asp:Label ID="lblDetails" runat="server" Text="Label"></asp:Label>
        </div>

        <div class="rom2">
            <iframe src="https://www.facebook.com/plugins/page.php?href=https%3A%2F%2Fwww.facebook.com%2Fbcbtigercricket%2F&tabs=timeline&width=260&height=780&small_header=false&adapt_container_width=false&hide_cover=false&show_facepile=true&appId" width="260" height="780" style="border:none;overflow:hidden" scrolling="no" frameborder="0" allowfullscreen="true" allow="autoplay; clipboard-write; encrypted-media; picture-in-picture; web-share"></iframe>
        </div>
    </div>
</asp:Content>
