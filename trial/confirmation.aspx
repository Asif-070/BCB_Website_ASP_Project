<%@ Page Title="" Language="C#" MasterPageFile="~/user.Master" AutoEventWireup="true" CodeBehind="confirmation.aspx.cs" Inherits="trial.confirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        input {
            display: block;
            padding: 1em;
            border-radius: .4em;
            margin-bottom: .5em;
            width: 88.5%;
            border: 1px solid rgb(0 0 0 / 10%);
            font-size: 1.5em;
            background-color: #F0F2F5;
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
    <asp:Label ID="Label1" runat="server" Text="You are buying a ticket for " style="text-align:center; display:block; font-size: 2em; font-weight: bold; margin-top:30px;"></asp:Label>

    <h3 style="text-align:center;">Select Payment Method for the transaction</h3>
    <div style="margin-left:3%;">
        <asp:DropDownList ID="DropDownList1" runat="server" Height="30px" Width="92.5%"></asp:DropDownList>
        <br /><br />
        <asp:TextBox ID="TextBox1" runat="server" placeholder="Transaction ID"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Confirm" OnClick="Button1_Click" OnClientClick="return confirm('Are you sure you want to confirm the transaction?');"/>
        <asp:Label ID="lbl" runat="server" Text=""></asp:Label>
        <asp:Button ID="Button2" runat="server" Text="Print" OnClick="Button2_Click" />
    </div>
</asp:Content>
