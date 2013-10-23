using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Textbooks;

public partial class Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        headSearch.InnerText = "Seach Results >>>";
        string norm=null, title=null, author=null, isbn=null;
        if (Request.QueryString["norm"] != null)
        {
            norm = Request.QueryString["norm"];
        }
        else
        {
            title = Request.QueryString["title"];
            author = Request.QueryString["author"];
            isbn = Request.QueryString["isbn"];
            
        }
        string sql= SearchEngine.searchEngine(norm, title, author, isbn);
        sqlSearchResult.SelectCommand = sql;
    }
}