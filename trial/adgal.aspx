<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="adgal.aspx.cs" Inherits="trial.adgal" %>
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
        container {
            margin-left: 20px;
        }

        .table-container {
            max-width: 800px;
            margin: 10px auto;
        }

        table {
            width: 80%;
            border-collapse: collapse;
            border: 1px solid #ccc;
            margin-left:7%;
        }

        th, td {
            padding: 8px;
            text-align: left;
        }

        th {
            background-color: #f2f2f2;
        }

        tr:nth-child(even) {
            background-color: #f2f2f2;
        }
        

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="addnews">
        <h1>&nbsp;&nbsp;&nbsp;&nbsp; Add to Gallery:</h1>
        <asp:Textbox ID="TextBox1" runat="server" placeholder="Title"  Width="1050px"></asp:Textbox>
        <asp:FileUpload ID="imageUpload" runat="server" />
        <p class="stublbl"><asp:Label ID="warn" runat="server" Text=" "></asp:Label></p>
        <asp:Button ID="Button1" runat="server" Text="Add" OnClick="add_Click"/>

    </div>
    <hr />

    <div class="row">
            <p style ="margin-left:20px">
                <asp:Textbox ID="TextBox2" runat="server" placeholder="id" Width="1050px"></asp:Textbox>
                <asp:Button ID="Button2" runat="server" Text="Delete" OnClick="Button2_Click" />
                <br /><br />
            </p>
            <div class="col-md-8 mx-auto">
                <asp:GridView ID="CoursesGridView" CssClass="table" runat="server" AutoGenerateColumns="false" >
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" />
                        <asp:BoundField DataField="Title" HeaderText="TITLE" />
                    </Columns>
                </asp:GridView>
            </div>
        <br /><br /><br /><br />
        </div>
</asp:Content>
