<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="adtick.aspx.cs" Inherits="trial.adtick" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .addnews {
            margin-left: 20px;
        }
            .addnews label {
                margin-left: 40px;
                font-size: large;
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
            margin-left: 3%;
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
        .stublbl{
            margin-left:8.5%;
            font-size: large;
        }
        input[type="submit"]:hover {
            background-color: #474343;
        }
        textarea {
              width: 89%;
              height: 150px;
              padding: 1em;
              border-radius: 4px;
              background-color: #f8f8f8;
              margin-left: 3%;
              resize: none;
              font-size: 1.3em;
              font-family:Arial;
              margin-bottom:.5em;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="addmatch">
        <h1>&nbsp;&nbsp;&nbsp;&nbsp; Add Ticket:</h1>
        <asp:TextBox ID="TextBox1" runat="server" placeholder="Match Name"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" placeholder="Team 1"></asp:TextBox>
        <asp:TextBox ID="TextBox3" runat="server" placeholder="Team 2"></asp:TextBox>
        <asp:TextBox ID="TextBox4" runat="server" placeholder="Venue"></asp:TextBox>
        <asp:TextBox ID="TextBox5" runat="server" placeholder="Date"></asp:TextBox>
        <asp:TextBox ID="TextBox6" runat="server" placeholder="Time"></asp:TextBox>
        <asp:TextBox ID="TextBox7" runat="server" placeholder="No. of tickets"></asp:TextBox>

        <p class="stublbl"><asp:Label ID="warn" runat="server" Text=" "></asp:Label></p>
        <asp:Button ID="Button1" runat="server" Text="Add" OnClick="add_Click"/>

    </div>

</asp:Content>
