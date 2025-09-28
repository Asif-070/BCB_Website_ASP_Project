<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="trial.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    <title>Registration page</title>
    <link href="CSS/buy_ticket.css" rel="stylesheet" />
</head>

<body>
    <div class="top">
        <div class="left_logo">
            <a href="mainpage.aspx"><img src="Images/Master/BCB-logo-Flip-360.gif" alt="logo"/></a>
        </div>
        <div class="right_option">
            <nav>
                <a href="Others/guidline.pdf">Guideline</a>
                <a href="login.aspx">Login</a>
            </nav>
        </div>
    </div>
    <div class="container">
        <div class="left">
            <div class="form">
                <h1>Register</h1>
                <form runat="server" id="regform">
                    <asp:TextBox ID="namebox" runat="server" placeholder="Name"></asp:TextBox>
                    <p class="sp">Insert your full name</p>
                    <asp:TextBox ID="phonebox" runat="server" placeholder="Phone no."></asp:TextBox>
                    <p class="sp">Insert your valid phone number</p>
                    <asp:TextBox ID="mailbox" runat="server" placeholder="E-mail"></asp:TextBox>
                    <p class="sp">Insert valid email address.</p>
                    <asp:TextBox ID="passbox" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                    <p class="sp">Use strong password.</p>
                    <asp:TextBox ID="passbox2" runat="server" TextMode="Password" placeholder="Confirm Password"></asp:TextBox>
                    <p class="sp">Insert password again.</p>
                    <asp:CheckBox ID="CheckBox" runat="server" Text="I have read and understand the Terms and Conditions, Return and Refund
                        Policies, and Privacy Policies of this agreement"/><br><br>
                    <asp:Label ID="lbl" runat="server" Text=""></asp:Label>
                    <asp:Button ID="btn" runat="server" Text="Register" OnClick="Button_Click"/>
                </form>
                <p>Already Registered? <a href="login.aspx" class="btn">SIGN IN</a></p>
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
