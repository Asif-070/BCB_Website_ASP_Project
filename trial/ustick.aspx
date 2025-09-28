<%@ Page Title="" Language="C#" MasterPageFile="~/user.Master" AutoEventWireup="true" CodeBehind="ustick.aspx.cs" Inherits="trial.ustick" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .con1{
            margin-left:70px;
        }
        .pic{
            background-color: cornsilk;
            padding: 20px;
            width:90%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class = "header">
		<div class = "left_logo">
			<img src="Images/Master/BCB-logo-Flip-360.gif" alt ="logo"/>
		</div>
		<div class = "right_option">
			<nav>
				<a href="#">TICKET</a>
				<a href="javascript:history.back()">PROFILE</a>
                <a href="mainpage.aspx">LOG OUT</a>
			</nav>
		</div>
	</div>
	<div style="height:100px;"> </div>

    <div class ="con1">
        <h2>Match Tickets</h2>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        <div class="flex-container">
            <% foreach (var tick in NewsArticles) { %>
                <div class="pic">
                    <div class="text" style="font-size:larger"><%: tick.Name %></div><br />
                    <div class="text"><%: tick.Team %>  &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp  Venue:     <%: tick.Venue %></div><br />
                    <div class="text">General Admission &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp <%: tick.Datetime %></div><br />
                    <div class="text">Remaining Ticket: <%: tick.Count %></div><br />

                    <a href="confirmation.aspx?id=<%: tick.Id %>">
                        <img src="Images/altbtn.png" alt="news" style="width: 176px; height: 58px;"/>
                    </a>
                </div>

                <br /><br />
            <% } %>
        </div>
    </div>

</asp:Content>
