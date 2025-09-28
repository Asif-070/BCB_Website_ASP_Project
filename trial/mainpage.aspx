<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="mainpage.aspx.cs" Inherits="trial.mainpage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="CSS/home.css" rel="stylesheet" />
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <style>
        .text:hover{
            color: #02bd8b;
        }
        .pic a{
            text-decoration: none;
        }
        .fix {
            display: flex;
            justify-content: center;
            align-items: center;
            margin-bottom: 50px;
        }
        .flex-container {
            background-image: url('../images/newsbg.jpg');
            display: flex;
            flex-wrap: wrap;
            flex-direction: row;
            justify-content: center;
            margin-top: 30px;
            padding-top: 30px;
            padding-bottom: 30px;
            /*margin-right: 2.5%;*/
        }
        .pic{
            width: 355px;
            margin-right: 25px;
            margin-bottom: -30px;
        }
        .text{
            position: relative;
            bottom: 80px;
            left: 15px;
            color: #ffffff;
            font-family: "Agency FB", sans-serif;
            font-size: 180%;
            text-shadow: 2px 2px 8px rgb(70, 70, 70);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="carouselExampleCaptions" class="carousel slide" data-bs-ride="carousel" style="margin-top:-18px; margin-left:5%; width:90%;">
        <div class="carousel-indicators">
            <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
            <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="1" aria-label="Slide 2"></button>
            <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="2" aria-label="Slide 3"></button>
        </div>
        <div class="carousel-inner" style="height:520px;">
            <div class="carousel-item active"> 
                <a href="news.aspx"><img src="Images/home/s1.jpeg" class="d-block w-100" style="filter: brightness(50%);" /></a>
                <div class="carousel-caption d-none d-md-block">
                    <h5>Look for Latest News</h5>
                    <p style="height:150px;">Get ready to dive into the latest and greatest news!</p>
                </div>
            </div>
            <div class="carousel-item">
                <a href="match.aspx">
                    <img src="Images/home/s2.jpeg" class="d-block w-100" style="filter: brightness(50%);" /></a>
                    <div class="carousel-caption d-none d-md-block">
                        <h5>See Details of All Matches</h5>
                        <p style="height:150px;">Discover Comprehensive Match Details: Delve into the Fascinating Insights of Each Game!</p>
                    </div>
            </div>
            <div class="carousel-item">
                <a href="login.aspx">
                    <img src="Images/home/s3.jpg" class="d-block w-100" style="filter: brightness(50%);" /></a>
                    <div class="carousel-caption d-none d-md-block">
                        <h5>Buy Tickets for Upcoming Match</h5>
                        <p style="height:150px;">Secure Your Seat: Purchase Tickets for the Highly Anticipated Upcoming Match!</p>
                    </div>
            </div>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>

    <h1 style="font-family: 'Agency FB'; text-align: center; font-size: 300%; margin-top: 30px; margin-bottom: 40px;">Current Fixture</h1>
    
    <div class="fix">
		<asp:Image ID="Image1" runat="server" width="785px" AlternateText="No Fixture Currently Available"/>
    </div>

    <h1 style="font-family: 'Agency FB'; text-align: center; font-size: 300%; margin-bottom: 70px;">Latest News</h1>
    <div class="flex-container">
        <% foreach (var article in NewsArticles.Take(3)) { %>
            <div class="pic">
                <a href="NewsDetails.aspx?id=<%: article.Id %>">
                    <img src="<%: article.ImagePath %>" alt="news" style="width: 355px; height: 320px;"/>
                </a>
                <div class="text"><%: article.Title %></div>
            </div>
        <% } %>
    </div>


    <div class="video-container">
		<h1 style="font-family: 'Agency FB'; text-align: center; font-size: 300%; margin-bottom: 70px;">Featured Videos</h1>
		<iframe width="930" height="520" src="https://www.youtube.com/embed?listType=playlist&list=UU0gsMYK1dqQ5KqOQfavVNkg"></iframe>
		<div class="video-row">
			<iframe src="https://www.youtube.com/embed?listType=playlist&list=UU0gsMYK1dqQ5KqOQfavVNkg&index=2"></iframe>
			<iframe src="https://www.youtube.com/embed?listType=playlist&list=UU0gsMYK1dqQ5KqOQfavVNkg&index=3"></iframe>
			<iframe src="https://www.youtube.com/embed?listType=playlist&list=UU0gsMYK1dqQ5KqOQfavVNkg&index=4"></iframe>
		</div>
	</div>

    <div style="margin-top: 50px; margin-bottom: 100px;">
        <h1 style="font-family: 'Agency FB'; text-align: center; font-size: 300%; margin-bottom: 70px;">Sponsers</h1>
		<p style="text-align: center;">
			<img src="front_page/Daraz_logo_color-1-1.png">
			&nbsp&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 
			<img src="front_page/BAN-TECH-Logo-2-300x162-1.png">
		</p>
		<p style="text-align: center;">
			<img src="front_page/Aamra-1.png">
			&nbsp 
			<img src="front_page/HungryNaki-1.png">
			<img src="front_page/pan-pacific-logo-png-transparent-1.png">
		</p>
		
	</div>


    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>

</asp:Content>
