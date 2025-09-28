<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Constitution.aspx.cs" Inherits="trial.Constitution" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="text-align: center;margin-top: 100px;">CONSTITUTION <br><br></h1>

    <embed style="padding-left:5%"
		src="Others/Constitution.pdf"
		type="application/pdf"
		width="90%"
		height= 1000px
	/>

	<hr style ="border: none;">

</asp:Content>
