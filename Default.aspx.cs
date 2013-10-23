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
using System.Collections;
using Textbooks;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckTables.CheckBookTable();

        ArrayList values = Pages.PageCount();
        Repeater2.DataSource = values;
        Repeater2.DataBind();

        Int32 page = 0;
        if (Request.QueryString["numpage"] != null)
        {
            page = Int32.Parse(Request.QueryString["numpage"]);
        }

        if (Session["Department"] != null)
        {
            String depart = Session["Department"].ToString().Replace("'","''");
            head.InnerText = "Hot Deal in \"" + Session["Department"] + "\" >>>";
            sqldataImages.SelectCommand = "select * from textbook where Department= '"+depart+"' order by Year desc, Title OFFSET "+page+" ROWS FETCH NEXT "+(page+10)+" ROWS ONLY";
        }
        else if (Session["title"] != null)
        {
            head.InnerText = "Today's Deal >>>";
            sqldataImages.SelectCommand = "select * from textbook order by Rate desc, Title OFFSET " + page + " ROWS FETCH NEXT " + (page + 10) + " ROWS ONLY";
        }
        else
        {
            head.InnerText = "New Released Books >>>";
            sqldataImages.SelectCommand = "select * from textbook order by Year desc, Title OFFSET " + page + " ROWS FETCH NEXT " + (page + 10) + " ROWS ONLY";
        }
    }

}


