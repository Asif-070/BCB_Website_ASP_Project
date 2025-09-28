<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="deltick.aspx.cs" Inherits="trial.deltick" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
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
            margin-left:10%;
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

        .delete-button {
            background-color: #f44336;
            color: white;
            border: none;
            padding: 6px 12px;
            cursor: pointer;
        }

        .delete-button:hover {
            background-color: #d32f2f;
        }

        input {
            display: block;
            padding: .5em;
            border-radius: .4em;
            margin-bottom: .5em;
            width: 60%;
            border: 1px solid rgb(0 0 0 / 10%);
            font-size: 1.5em;
            background-color: #F0F2F5;
            margin-left: 3%;
            float: left;
        }

        input[type="submit"] {
            background-color: grey;
            color: #ffffff;
            font-size: 1.25em;
            font-weight: 700;
            letter-spacing: 1px;
            margin-right: 7%;
            margin-left: -70px;
            padding: .7em 0;
            display: block;
            width: 12%;
            border: none;
            float: right;
        }

        input[type="submit"]:hover {
            background-color: #474343;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1 class="text-center" style="margin-left: 50px;">All Ticket: </h1>

        <div class="row">
            <p>
                <asp:Textbox ID="TextBox1" runat="server" placeholder="id"></asp:Textbox>
                <asp:Button ID="Button1" runat="server" Text="Delete" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" />
            </p>
            <div class="col-md-8 mx-auto">
                <asp:GridView ID="CoursesGridView" CssClass="table" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" />
                        <asp:BoundField DataField="Name" HeaderText="NAME" />
                        <asp:BoundField DataField="Team" HeaderText="TEAM" />
                        <asp:BoundField DataField="Datetime" HeaderText="DATETIME" />
                        <asp:BoundField DataField="Count" HeaderText="TICKET LEFT" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
