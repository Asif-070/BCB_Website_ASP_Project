<%@ Page Title="" Language="C#" MasterPageFile="~/user.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="trial.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>User Profile</title>
    <style>
        /* Add your custom CSS styles here */
        .info{
            margin-left: 50px;
        }
        input {
            display: block;
            padding: 1em;
            border-radius: .4em;
            margin-bottom: .5em;
            width: 88.5%;
            border: 1px solid rgb(0 0 0 / 10%);
            font-size: 1.5em;
            background-color: #F0F2F5;
            margin-left:35px;
            margin-top:15px;
        }

            input[type="submit"] {
                background-color: grey;
                color: #ffffff;
                font-size: 1.25em;
                font-weight: 700;
                letter-spacing: 1px;
                margin-top: 20px;
                margin-right: 7%;
                padding: .7em 0;
                display: block;
                width: 30%;
                border: none;
                float: right;
            }
        input[type="submit"]:hover {
            background-color: #474343;
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
				<a href="ustick.aspx">TICKET</a>
				<a href="mainpage.aspx">LOG OUT</a>
			</nav>
		</div>
	</div>
	<div style="height:100px;"> </div>

    <h1>&nbsp&nbsp Welcome to User Home</h1>

    <div class="info">
        <h3>User Profile</h3>
        <p><strong>Name:</strong> <asp:Label ID="lblName" runat="server" ></asp:Label></p>
        <p><strong>Email:</strong> <asp:Label ID="lblEmail" runat="server" ></asp:Label></p>
        <p><strong>Phone No:</strong> <asp:Label ID="lblPhone" runat="server" ></asp:Label></p>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    </div>

    <div class="info">
        <h3>Change Password</h3>
        <asp:Label ID="lblMessage2" runat="server" ForeColor="Red"> </asp:Label>
            <p>
                <label for="txtCurrentPassword">Current Password:</label>
                <asp:TextBox ID="ogbox" runat="server" TextMode="Password"></asp:TextBox>
            </p>
            <p>
                <label for="txtNewPassword">New Password:</label>
                <asp:TextBox ID="passbox" runat="server" TextMode="Password"></asp:TextBox>
            </p>
            <p>
                <label for="txtConfirmPassword">Confirm New Password:</label>
                <asp:TextBox ID="passbox2" runat="server" TextMode="Password"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" />
            </p>
    </div>
</asp:Content>
