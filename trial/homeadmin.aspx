<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homeadmin.aspx.cs" Inherits="trial.homeadmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Home</title>
    <link href="CSS/homeadmin.css" rel="stylesheet" />
</head>
<body>
    <div class="top">
        <div class="left_logo"><img src="Images/Master/BCB-logo-Flip-360.gif" alt="logo"/>
        </div>
        <div class="right_option">
            <nav>
                <a href="#">Main</a>
                <a href="#">News</a>
                <a href="#">Gallery</a>
                <a href="#">Users</a>
                <a href="#">Tickets</a>
            </nav>
        </div>
    </div>
    
    <div class="container">
        <div class="form">
            <form runat="server" id="logform">
                <h1>Slider: </h1>
                <asp:FileUpload ID="slider1" runat="server" />
                <asp:FileUpload ID="slider2" runat="server" />
                <asp:FileUpload ID="slider3" runat="server" />
                <asp:Button ID="btnslider" runat="server" Text="SUBMIT" />
                <br>
                <h1>Fixture: </h1>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Button ID="btnfix" runat="server" Text="SUBMIT" />
                <br>
                <h1>Video: </h1>
                <asp:FileUpload ID="FileUpload2" runat="server" />
                <asp:FileUpload ID="FileUpload3" runat="server" />
                <asp:FileUpload ID="FileUpload4" runat="server" />
                <asp:Button ID="Button1" runat="server" Text="SUBMIT" />
                <br>
            </form>
        </div>
    </div>


    </body>
</html>
