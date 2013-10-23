<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="Styles/main1.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 class="header" id="head" runat="server"> </h2>

    <asp:SqlDataSource runat="server" ID="sqldataImages" ConnectionString="<%$ConnectionStrings:dbconnection %>"
        SelectCommand="select * from textbook order by year desc, title" >
    </asp:SqlDataSource>

    <asp:repeater id="Repeater1" runat="server" DataSourceID="sqldataImages">
        <HeaderTemplate>
            <div class="maincontent">
        </HeaderTemplate>
        <ItemTemplate>
            <div class="item">
                <a href="Book.aspx?isbn10='<%# DataBinder.Eval(Container.DataItem, "Isbn10") %>'">
                    <img src= '<%# DataBinder.Eval(Container.DataItem, "ImagePath") %>' />
                    <p><%# DataBinder.Eval(Container.DataItem, "Title") %></p>
                </a>
                <p>by <%# DataBinder.Eval(Container.DataItem, "Author") %></p>
                <div class="imgrating">
                    <img src="<%# DataBinder.Eval(Container.DataItem, "Rating") %>" />
                    <span>(<%# DataBinder.Eval(Container.DataItem, "ReviewCount") %>)</span>
                </div>
                <p>$<%# DataBinder.Eval(Container.DataItem, "Price") %></p>
            </div>
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>


    </asp:repeater>
     <asp:repeater id="Repeater2" runat="server" >
        <HeaderTemplate>
            <div class="footer">
        </HeaderTemplate>
        <ItemTemplate>
                <div>
                     <%# DataBinder.Eval(Container.DataItem, "BookCount") %>
                </div>
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:repeater>

</asp:Content>
