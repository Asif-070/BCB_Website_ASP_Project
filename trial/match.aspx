<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="match.aspx.cs" Inherits="trial.match" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/match.css" rel="stylesheet" />
    <style>
        .all{
            margin-left: 30px;
        }
        .mid_option{
            margin-right: 250px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class ="all">
            <h2>Select a Match:</h2>
            <asp:DropDownList ID="ddlMatches" runat="server" AutoPostBack="True" Height="30px" Width="95%" BackColor="#d1c5c2" ForeColor="#7d6754" OnSelectedIndexChanged="ddlMatches_SelectedIndexChanged">
            </asp:DropDownList>

            <h2>Match Information:</h2>
            <div class ="infor">
                <asp:Label ID="lblName" runat="server" Text="Match Name"></asp:Label><br />
                <asp:Label ID="lblTeam1" runat="server" Text="Team1"></asp:Label> vs <asp:Label ID="lblTeam2" runat="server" Text="Team 2"></asp:Label><br />
                <asp:Label ID="lblScore1" runat="server" Text="Score 1"></asp:Label> - <asp:Label ID="lblScore2" runat="server" Text="Score 2"></asp:Label><br />
                <asp:Label ID="lblStadium" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="lblVerdict" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="lblOrg" runat="server" Text=""></asp:Label><br />
                <h2>Report:</h2>
                <asp:Label ID="lblReport" runat="server" Text=""></asp:Label><br />
                <h2>Team:</h2>
                <asp:Image ID="imgTeam" runat="server" AlternateText="" Width="75%" /><br />
                <h2>Score Board:</h2>
                <div style="display: flex;">
                    <asp:Image ID="imgScore1" runat="server" AlternateText="" Width="45%" /><br />
                    <asp:Image ID="imgScore2" runat="server" AlternateText="" Width="45%" /><br />
                </div>
                <br />
                <br />
            </div>
        </div>



</asp:Content>
