<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="trial.news" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/news.css" rel="stylesheet" />
    <style>
        .text:hover{
            color: #02bd8b;
        }
        .pic a{
            text-decoration: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
		<h1 style="text-align: center;">Latest News</h1>
                
        <div class="flex-container">
            <% foreach (var article in NewsArticles) { %>
                <div class="pic">
                    <a href="NewsDetails.aspx?id=<%: article.Id %>">
                        <img src="<%: article.ImagePath %>" alt="news" style="width: 355px; height: 320px; filter: brightness(70%);"/>
                        <div class="text"><%: article.Title %></div>
                    </a>
                    
                </div>
            <% } %>
        </div>
                
    </div>


</asp:Content>
