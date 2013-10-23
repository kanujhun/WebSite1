using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;
using Textbooks;


public partial class Book : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string isbn = Request.QueryString["isbn10"].ToString();
        sqldataContent.SelectCommand = "select * from textbook where Isbn10=" + isbn;
        sqldataReview.SelectCommand = "select * from review where Isbn10 =" + isbn ;
    }

    protected void WriteReview_Click(object sender, EventArgs e)
    {
        string isbn = Request.QueryString["isbn10"].ToString();
        object[] values = new object[6] { titlereview.Value.Trim(), name.Value.Trim(), reviewtext.Text.Trim(), rate.SelectedItem.Text, DateTime.Now, isbn.Replace("\'", "") };
        Review.InsertReview(values);
        Rating.UpdateRating(isbn);
        
        Response.Redirect("Book.aspx?isbn10="+isbn);
    }

}