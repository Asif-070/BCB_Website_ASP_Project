<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="gallery.aspx.cs" Inherits="trial.gallery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/gallery.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
		<h1 style="text-align: center;">Photo Gallery</h1>

        <div class="flex-container" style="margin-bottom:20px;">
            <% foreach (var article in NewsArticles) { %>
                <div class="pic">
                    <a href="photoDetails.aspx?id=<%: article.Id %>">
                        <img src="<%: article.ImagePath %>" alt="news" style="width: 355px; height: 320px;"/>
                    </a>
                    <div class="text"><%: article.Title %></div>
                </div>
            <% } %>
        </div>
        
    </div>

</asp:Content>
