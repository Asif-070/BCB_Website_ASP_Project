<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="trial.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    <title>Login</title>
    <link href="CSS/login.css" rel="stylesheet" />
</head>

<body>
    <div class="top">
        <div class="left_logo">
            <a href="mainpage.aspx"><img src="Images/Master/BCB-logo-Flip-360.gif" alt="logo"/></a>
        </div>
        <div class="right_option">
            <nav>
                <a href="Others/guidline.pdf">Guideline</a>
                <a href="register.aspx">Register</a>
            </nav>
        </div>
    </div>
    <div class="container">
        <div class="left">
            <div class="form">
                <h1>Login</h1>
                <form runat="server" id="logform">
                    <asp:TextBox ID="mailtext" runat="server" placeholder="E-mail"></asp:TextBox>
                    <asp:TextBox ID="passtext" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox><br>
                    <asp:Label ID="lbl" runat="server" Text=" "></asp:Label>
                    <asp:Button ID="Button1" runat="server" Text="LOG IN" OnClick="Button1_Click" />
                </form>
                <p style="float: left;">Not yet registered? <a href="register.aspx" class="btn">REGISTER NOW!</a></p>
            </div>
        </div>
        <div class="right">
            <img src="Images/reg.png" width="330px"/>
        </div>
    </div>

    <div class="bottom">
        <p style="font-family: 'Segoe UI';">
            &copy; 2023 All Rights Reserved by BCB.
        </p>
    </div>
</body>

</html>
