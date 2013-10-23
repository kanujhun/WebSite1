<%@ Page Title="Textbook Information" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Book.aspx.cs" Inherits="Book" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link id="Link1" href="Styles/main2.css" rel="stylesheet" type="text/css"  media="screen" runat="server"  />
    <script type="text/javascript">
        $(document).ready(function () {
            $('#writereview #<%= submit.ClientID%>').click(function () {//review form
                $('.error').remove();
                var i = 0;
                $('.required_field').each(function () {
                    if (errorText($(this)) == false) { i++; }
                });
                if (i != 0) { return false; }
            });
            function errorText($value) { //check if empty input
                if ($.trim($value.val()) == '') {
                    if ($('.required_field span.error').length == 0) {
                        $value.parent().append('<span class="error" style="color:red">*This input can\'t be empty</span>');
                    }
                    return false;
                }
                else { return true; }
            }
        });
    </script>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:SqlDataSource runat="server" ID="sqldataContent" ConnectionString="<%$ConnectionStrings:dbconnection %>"
        SelectCommand="select * from textbook" >
    </asp:SqlDataSource>

    <asp:repeater id="Repeater" runat="server" DataSourceID="sqldataContent">
        <HeaderTemplate>
            <div class="bookcontent">
        </HeaderTemplate>
        <ItemTemplate>
            <div id="imageContent">
                <img src="<%# DataBinder.Eval(Container.DataItem, "ImagePath") %>" />
                <a href="Upload.aspx?update='<%# DataBinder.Eval(Container.DataItem, "Isbn10") %>'">Modify Product Information</a>
            </div>
            <div class="decsContent">
                <h2><%# DataBinder.Eval(Container.DataItem, "Title") %></h2>
                <p class="prc">Price: <%# DataBinder.Eval(Container.DataItem, "Price") %></p>
                <p>Year: <%# DataBinder.Eval(Container.DataItem, "Year") %></p>
                <p>by <%# DataBinder.Eval(Container.DataItem, "Author") %></p>
                <img src="<%# DataBinder.Eval(Container.DataItem, "Rating") %>" />
                <span>(<%# DataBinder.Eval(Container.DataItem, "ReviewCount") %>)</span>
                <p class="decs">
                    Product Description
                    <span>
                        <%# DataBinder.Eval(Container.DataItem, "Description") %>
                    </span>
                </p>
            </div>
            <div class="detailContent">
                <h2>Product Detail</h2>
                <p><span>ISBN-10:</span> <%# DataBinder.Eval(Container.DataItem, "Isbn10") %></p>
                <p><span>ISBN-13:</span><%# DataBinder.Eval(Container.DataItem, "Isbn13") %></p>
                <p><span>Department:</span><%# DataBinder.Eval(Container.DataItem, "Department") %></p>
                <p><span>Publisher:</span><%# DataBinder.Eval(Container.DataItem, "Publisher") %></p>
                <p><span>Language:</span><%# DataBinder.Eval(Container.DataItem, "Language") %></p>
            </div>
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:repeater>

    <asp:SqlDataSource runat="server" ID="sqldataReview" ConnectionString="<%$ConnectionStrings:dbconnection %>"
       SelectCommand="select * from review" >
    </asp:SqlDataSource>
    <asp:repeater id="reviewRepeater" runat="server" DataSourceID="sqldataReview">
        <HeaderTemplate>
            <div class="reviewContent">
                <h2>Reviews</h2>
        </HeaderTemplate>
        <ItemTemplate>
            <div id="reviews">
                <a href="ReviewModify.aspx?modify='<%# DataBinder.Eval(Container.DataItem, "Id") %>'&isbn='<%# DataBinder.Eval(Container.DataItem, "Isbn10") %>'">
                    <p class="title">
                        <%# DataBinder.Eval(Container.DataItem, "Title") %> 
                        <span> [<%# DataBinder.Eval(Container.DataItem, "Rating") %> Star(s)]</span>
                    </p>
                    <p>by <%# DataBinder.Eval(Container.DataItem, "Name") %> (<%# DataBinder.Eval(Container.DataItem, "Date") %>)</p>
                    <p class="comment"><%# DataBinder.Eval(Container.DataItem, "Content") %></p>
                </a>
            </div>
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:repeater>

    <div id="writereview" class="writeComment">
			<h1>Create your own review</h1>
            <form action="Book.aspx" method="post" id="review">
				<fieldset><label>Set your pen name:</label><input type="text" runat="server" name="name" id="name" class="required_field" maxlength="50" size="50"/></fieldset>
				<fieldset><label>How do you rate this textbook? (1-5)</label>
				<asp:DropDownList runat="server" id="rate">
					<asp:ListItem text="5" />
					<asp:ListItem text="4" />
					<asp:ListItem text="3" />
					<asp:ListItem text="2" />
					<asp:ListItem text="1" />
				</asp:DropDownList></fieldset>
				<fieldset><label>Please enter a title of your review:</label><input runat="server" type="text" name="titlereview" id="titlereview" class="required_field" maxlength="100" size="50"/></fieldset>
				<fieldset><label>Write your review (500 words):</label><asp:TextBox runat="server" id="reviewtext" CssClass="required_field" TextMode="multiline" maxlength="500"/></fieldset>
				<asp:button runat="server" text="Upload" id="submit" onclick="WriteReview_Click" />
            </form>
    </div>

</asp:Content>