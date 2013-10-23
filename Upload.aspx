<%@ Page Title="Upload" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Upload.aspx.cs" Inherits="About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="Styles/main1.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('#tbupload #<%= submit.ClientID%>').click(function () {//review form
                $('.error').remove();
                var i = 0;
                $('.required_field').each(function () {
                    if (errorText($(this)) == false) { i++; }
                });
                if (matchPatt($('#<%= isbn10.ClientID%>'), /^(\d{9})(\w{1})$/, "ISBN-10 must contains exactly 10 digits") == false) { i++; };
                if (matchPatt($('#<%= isbn13.ClientID%>'), /^(\d{3})(-{1})(\d{9})(\w{1})$/, "ISBN-13 must be exactly like xxx-xxxxxxxxxx") == false) { i++; };
                if (matchPatt($('#<%= year.ClientID%>'), /^(\d{4})$/, "Year must contain exactly 4 digits") == false) { i++; };
                if (matchPatt($('#<%= price.ClientID%>'), /^\d+\.?((\d{1})(\d{1})?)?$/, "Price must be in digits and have at most two decimal points") == false) { i++; };
                if (i != 0) { return false; }
            });
            $('#tbupload #<%= update.ClientID%>').click(function () {//review form
                $('.error').remove();
                 var i = 0;
                 $('.required_field').each(function () {
                     if (errorText($(this)) == false) { i++; }
                 });
                 if (matchPatt($('#<%= isbn13.ClientID%>'), /^(\d{3})(-{1})(\d{9})(\w{1})$/, "ISBN-13 must be exactly like xxx-xxxxxxxxxx") == false) { i++; };
                 if (matchPatt($('#<%= year.ClientID%>'), /^(\d{4})$/, "Year must contain exactly 4 digits") == false) { i++; };
                 if (matchPatt($('#<%= price.ClientID%>'), /^\d+\.?((\d{1})(\d{1})?)?$/, "Price must be in digits and have at most two decimal points") == false) { i++; };
                 if (i != 0) { return false; }
             });
            function errorText($value) { //check if empty input
                if ($.trim($value.val()) == '') {
                    if ($('.required_field span.error').length == 0) {
                        $value.prev().append('<span class="error" style="color:red">*This input can\'t be empty</span>');
                    }
                    return false;
                }
                else { return true; }
            }
            function matchPatt($value, patt, text) { //check input pattern
                if ($value.val() !== '') {
                    if (!$value.val().match(patt)) {
                        $value.prev().append('<span class="error" style="color:red">*' + text + '.</span>');
                        return false;
                    }
                    else { return true; }
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
    <div class="uploadcontent" id="tbupload">
    <h2>Upload your textbook ...</h2>
		        <p runat="server" id="ImgVisible">Image</p> <asp:FileUpload ID="picture" runat="server" />
		        <p>Title</p><asp:textbox runat="server"  maxlength='100' id="title" CssClass='required_field' />
		        <p runat="server" id="IsbnVisible">ISBN-10</p><asp:textbox runat="server"  maxlength='10' id='isbn10' CssClass='required_field' />
		        <p>ISBN-13</p><asp:textbox runat="server"  maxlength='14' id="isbn13"  />
		        <p>Price</p><asp:textbox runat="server"  maxlength='7' id="price" CssClass='required_field' />
		        <p>Author</p><asp:textbox runat="server"  id="author" maxlength='150' CssClass='required_field' />
		        <p>Year</p><asp:textbox runat="server"  maxlength='4' id="year" />
		        <p>Description</p><asp:textbox runat="server" TextMode="multiline"  rows='5' maxlength='200' id="desc" />
		        <p>Language</p><asp:textbox runat="server"  maxlength='30' id="language" />
		        <p>Publisher</p><asp:textbox runat="server"  maxlength='50' id="publisher" />
		        <p>Department</p><asp:DropDownList runat="Server" id='department'>
		        	<asp:ListItem Text="Arts & Photography" />
                    <asp:ListItem Text="Business & Investing" />
                    <asp:ListItem Text="Children's Books" />
                    <asp:ListItem Text="Computer & Technology" />
                    <asp:ListItem Text="Cookbooks & Foods" />
                    <asp:ListItem Text="Home" />
                    <asp:ListItem Text="Education" />
                    <asp:ListItem Text="Health, Fitness & Dieting" />
                    <asp:ListItem Text="History" />
                    <asp:ListItem Text="Entertainment" />
                    <asp:ListItem Text="Law" />
                    <asp:ListItem Text="Fiction" />
                    <asp:ListItem Text="Politics" />
                    <asp:ListItem Text="Science & Math" />
                    <asp:ListItem Text="Science Fiction & Fantasy" />
                    <asp:ListItem Text="Travel" />
					</asp:DropDownList>
			<div>
                <asp:button runat="server" text="Upload" id="submit" onclick="btnUpload_Click" />
                <asp:button runat="server" text="Update" id="update" onclick="btnUpdate" Visible="false" />
                <asp:button runat="server" text="Delete" id="delete" onclick="btnDelete" Visible="false" />
            </div>
	</div>

</asp:Content>
