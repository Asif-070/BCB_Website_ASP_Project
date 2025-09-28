<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="opportunity.aspx.cs" Inherits="trial.opportunity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/opportunity.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
		<h1 style="margin-top: 100px; margin-bottom: 35; text-align: center;">Expression of Interest</h1>
        <div class="bttn">
            <asp:Button runat="server" Text="All" OnClick="Unnamed1_Click" />
            <asp:Button runat="server" Text="Commercial" OnClick="com_Click" />
            <asp:Button runat="server" Text="Carrier" OnClick="Unnamed3_Click" />
        </div>

        <div class="flex-container">
            <div class="pic" runat="server">
                <p>
                    <img src="Images/EoI/1753825238285177.png" /><br>
                <div class="text"><a href="Others/opp/1.pdf">Job Vacancy : Curator</a></div>
                </p>
            </div>
            <div class="spc"></div>
            <div class="pic" runat="server">
                <p>
                <img src="Images/EoI/1753825238285177.png"><br>
                <div class="text"><a href="Others/opp/2.pdf">Job Vacancy : Trainee Curator</a></div>
                </p>
            </div>
            <div class="spc"></div>
            <div class="pic" runat="server">
                <p>
                <img src="Images/EoI/1753825238285177.png"><br>
                <div class="text"><a href="Others/opp/3.pdf">Position Open - National Team Assistant Coach</a></div>
                </p>
            </div>

            <div class="pic pic2" runat="server">
                <p>
                    <img src="Images/EoI/EOI.png" /><br>
                <div class="text"><a href="Others/opp/4.pdf">EOI Document for Official Partnership Rights (Minenar Water & Beverage Partner) for BPL T20</a></div>
                </p>
            </div>
            <div class="spc"></div>
            <div class="pic pic2" runat="server">
                <p>
                <img src="Images/EoI/1753825238285177.png"><br>
                <div class="text"><a href="Others/opp/4.pdf">Notice on Gazipur Land Purchase</a></div>
                </p>
            </div>
            <div class="spc"></div>
            <div class="pic pic2" runat="server">
                <p>
                <img src="Images/EoI/EOI.png"><br>
                <div class="text"><a href="Others/opp/4.pdf">Expression of Interest (EOI)_OFFICIAL PARTNERSHIP RIGHTS-BPL T20 Three Edition 2022</a></div>
                </p>
            </div>

            <div class="pic pic2" runat="server">
                <p>
                    <img src="Images/EoI/EOI-02.png" /><br>
                <div class="text"><a href="Others/opp/4.pdf">Expression of Interest (EOI)_Official Drinks and Beverage Partner of BCB upto 30 Nov 2024</a></div>
                </p>
            </div>
            <div class="spc"></div>
            <div class="pic pic2" runat="server">
                <p>
                <img src="Images/EoI/EOI.png"><br>
                <div class="text"><a href="Others/opp/4.pdf">EOI Document for Official Drinks & Beverage Rights</a></div>
                </p>
            </div>
            <div class="spc"></div>
            <div class="pic pic2" runat="server">
                <p>
                <img src="Images/EoI/bPL-2020-sponsorship.png"><br>
                <div class="text"><a href="Others/opp/4.pdf">Invitation to Bid AD for Media Rights of Bangladesh Premier League (BPL) T20 for three editions</a></div>
                </p>
            </div>
            
            <div class="pic pic2" runat="server">
                <p>
                <img src="Images/EoI/Team-sponsor.png"><br>
                <div class="text"><a href="Others/opp/5.jpg" target="_blank">National Team Sponsorship</a></div>
                </p>
            </div>
            <div class="spc"></div>
            <div class="pic pic2" runat="server">
                <p>
                <img src="Images/EoI/Sponsorship-right.png"><br>
                <div class="text"><a href="Others/opp/6.pdf">Sponsorship Rights</a></div>
                </p>
            </div>
         
        </div>
    </div>

    <hr style ="border: none;">

</asp:Content>
