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

public partial class About : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["update"] != null)
            {
                string isbn = Request.QueryString["update"].ToString();
                string[] values = new string[10];
                values = ProductModification.getBookValue(isbn);
                title.Text = values[0];
                isbn10.Text = values[1];
                isbn13.Text = values[2];
                price.Text = values[3];
                author.Text = values[4];
                year.Text = values[5];
                desc.Text = values[6];
                language.Text = values[7];
                publisher.Text = values[8];
                department.SelectedItem.Text = values[9];
                
                ImgVisible.Visible = false;
                IsbnVisible.Visible = false;
                picture.Visible = false;
                isbn10.Visible = false;
                submit.Visible = false;
                update.Visible = true;
                delete.Visible = true;
            }
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        //Get Filename from fileupload control
        string filename = Path.GetFileName(picture.PostedFile.FileName);
        if (picture.HasFile)
        {
            //Save images into Images folder
            picture.SaveAs(Server.MapPath("img/" + filename));
        }
        object[] values = new object[14] { "img/" + filename, title.Text.Trim(), isbn10.Text.Trim(), isbn13.Text.Trim(), price.Text.Trim(), author.Text.Trim(), year.Text.Trim(), "img/1.png", desc.Text.Trim(), language.Text.Trim(), publisher.Text.Trim(), department.SelectedItem.Text, 0, 0 };
        Product.InsertBook(values);
        
        Response.Redirect("Default.aspx");
    }

    protected void btnUpdate(object sender, EventArgs e)
    {
        string isbn = "'"+isbn10.Text+"'";
        object[] values = new object[9] { title.Text.Trim(), isbn13.Text.Trim(), price.Text.Trim(), author.Text.Trim(), year.Text.Trim(), desc.Text.Trim(), language.Text.Trim(), publisher.Text.Trim(), department.SelectedItem.Text };
        Product.UpdateBook(values, isbn);
        
        Response.Redirect("Book.aspx?isbn10=" + isbn);
    }

    protected void btnDelete(object sender, EventArgs e)
    {
        Product.DeleteBook(isbn10.Text);
        Response.Redirect("Default.aspx");
    }
}
