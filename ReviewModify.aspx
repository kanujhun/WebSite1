<%@ Page Title="Textbook Information" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ReviewModify.aspx.cs" Inherits="ReviewModify" %>

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
            $('#<%= delete.ClientID%>').on('click', function () {
                return confirm('Are you sure?');
            });
        });
    </script>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="writereview" class="writeComment">
			<h1 id="name" runat="server" style="text-transform:uppercase;">Modify the review</h1>
                <div>
				<fieldset><label>Rating:</label>
				<asp:DropDownList runat="server" id="rate">
                    <asp:ListItem text="5" />
					<asp:ListItem text="5" />
					<asp:ListItem text="4" />
					<asp:ListItem text="3" />
					<asp:ListItem text="2" />
					<asp:ListItem text="1" />
				</asp:DropDownList></fieldset>
				<fieldset><label>The title of your review:</label><input runat="server" type="text" name="title" id="title" class="required_field" maxlength="100" size="50"/></fieldset>
				<fieldset><label>The review Content:</label><asp:TextBox runat="server" id="review" TextMode="multiline" CssClass="required_field" maxlength="500"/></fieldset>
				<asp:button runat="server" text="Modify" id="submit" onclick="EditReview_Click" />
                <asp:button runat="server" text="Delete" id="delete" onclick="DeleteReview" />
                </div>
    </div>

</asp:Content>