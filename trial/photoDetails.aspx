<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="photoDetails.aspx.cs" Inherits="trial.photoDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/fixture.css" rel="stylesheet" />
    <style>
        .roma {
            margin-top:100px;
            margin-left:5%;
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
        <div class="roma">
            <asp:Label ID="lblTitle" runat="server" Font-Size="XX-Large" Font-Bold="True" Text="Label"></asp:Label><br /><br /><br />
            <asp:Image ID="imgNews" runat="server" width="90%" AlternateText="No Image Currently Available"/><br />
        </div>
    </div>
</asp:Content>
