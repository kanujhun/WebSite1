using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void department(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        Session["Department"] = btn.Text;
        Session["title"] = null;
        Response.Redirect("Default.aspx");
    }
    protected void getTitle(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        Session["title"] = btn.Text;
        Session["Department"] = null;
        Response.Redirect("Default.aspx");
    }
    public void HeaderLocation(object sender, EventArgs e)
    {
        Session["title"] = null;
        Session["Department"] = null;
        Response.Redirect("Default.aspx");
    }

    protected void normSearch(object sender, EventArgs e)
    {
        Response.Redirect("Search.aspx?norm="+search.Text.ToString());
    }

    protected void advSearch(object sender, EventArgs e)
    {
        Response.Redirect("Search.aspx?title=" + title.Text.ToString() + "&author=" + author.Text.ToString() + "&isbn=" + isbn.Text.ToString());
    }
}
