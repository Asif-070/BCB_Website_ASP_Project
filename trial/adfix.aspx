<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="adfix.aspx.cs" Inherits="trial.adfix" %>
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
        .image-container {
            margin-left:10%;
            width: 80%;
            border: 1px solid #ccc;
        }
        .image-container img{
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="addnews">
        <h1>&nbsp;&nbsp;&nbsp;&nbsp; Add new fixture:</h1>
        <asp:FileUpload ID="imageUpload" runat="server" />
        <p class="stublbl"><asp:Label ID="warn" runat="server" Text=" "></asp:Label></p>
        <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click"/>
    </div>
    <hr />
    <h1>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Current fixture:</h1>
    <div class="image-container">
        <asp:Image ID="Image1" runat="server"/>
    </div>

    <br />
    <br />
    <br />
</asp:Content>
