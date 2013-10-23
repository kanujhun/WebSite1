using System;
using System.Collections.Generic;
using System.Linq;
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

public partial class ReviewModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["modify"] != null)
        {
            string id = Request.QueryString["modify"].ToString();
            string isbn = Request.QueryString["isbn"].ToString();
            if (!IsPostBack)
            {
                string[] values = new string[4];
                values = ProductModification.getReviewValue(id);
                title.Value = values[0];
                name.InnerText = values[1];
                review.Text = values[2];
                rate.SelectedItem.Text = values[3];
            }
        }
    }

    protected void EditReview_Click(object sender, EventArgs e)
    {
        string id = Request.QueryString["modify"].ToString();
        string isbn = Request.QueryString["isbn"].ToString();
        object[] values = new object[] { title.Value.Trim(), review.Text.Trim(), rate.SelectedItem.Text, id.Replace("\'", "") };
        Review.UpdateReview(values);
        Rating.UpdateRating(isbn);

        Response.Redirect("Book.aspx?isbn10=" + isbn);
    }

    protected void DeleteReview(object sender, EventArgs e)
    {
        string id = Request.QueryString["modify"].ToString();
        string isbn = Request.QueryString["isbn"].ToString();
        Review.DeleteReview(id);
        Rating.UpdateRating(isbn);
        Response.Redirect("Book.aspx?isbn10=" + isbn);
    }
}