<%@ Page Title="Search Results" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link id="Link1" href="Styles/SearchStyle.css" rel="stylesheet" type="text/css"  media="screen" runat="server"  />
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 id="headSearch" class="header" runat="server"> </h2>

    <asp:SqlDataSource runat="server" ID="sqlSearchResult" ConnectionString="<%$ConnectionStrings:dbconnection %>"
        SelectCommand="select * from textbook" >
    </asp:SqlDataSource>

    <asp:repeater id="Repeater1" runat="server" DataSourceID="sqlSearchResult">
        <HeaderTemplate>
            <div class="results">
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

</asp:Content>