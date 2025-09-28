<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="fixture.aspx.cs" Inherits="trial.fixture" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/fixture.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rommain">
        <div class="rom">
            <asp:Image ID="Image1" runat="server" width="785px" AlternateText="No Fixture Currently Available"/>
        </div>

        <div class="rom2">
            <iframe src="https://www.facebook.com/plugins/page.php?href=https%3A%2F%2Fwww.facebook.com%2Fbcbtigercricket%2F&tabs=timeline&width=260&height=780&small_header=false&adapt_container_width=false&hide_cover=false&show_facepile=true&appId" width="260" height="780" style="border:none;overflow:hidden" scrolling="no" frameborder="0" allowfullscreen="true" allow="autoplay; clipboard-write; encrypted-media; picture-in-picture; web-share"></iframe>
        </div>
    </div>
</asp:Content>
