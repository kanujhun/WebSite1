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

namespace Textbooks
{
    public class SearchEngine
    {
        public static string searchEngine(string norm, string title, string author, string isbn)
        {
            string SelectCommand = null;
            if (norm != null)
            {
                SelectCommand = "SELECT * FROM textbook WHERE Title LIKE '" + norm + "%' or Title LIKE '%" + norm + "%' ";
            }
            else if (title != null && author != null && isbn != null)
            {
                title = title.Replace("'", "");
                author = author.Replace("'", "");
                isbn = isbn.Replace("'", "");
                SelectCommand = "SELECT * FROM textbook WHERE (Title LIKE '" + title + "%' or Title LIKE '%" + title + "%') and (Author LIKE '" + author + "%' or Author LIKE '%" + author + "%') and (Isbn10 LIKE '" + isbn + "%' or Isbn10 LIKE '%" + isbn + "%') ";
            }
            else if (title == null && author != null && isbn != null)
            {
                author = author.Replace("'", "");
                isbn = isbn.Replace("'", "");
                SelectCommand = "SELECT * FROM textbook WHERE (Author LIKE '" + author + "%' or Author LIKE '%" + author + "%') and (Isbn10 LIKE '" + isbn + "%' or Isbn10 LIKE '%" + isbn + "%') ";
            }
            else if (title != null && author == null && isbn != null)
            {
                title = title.Replace("'", "");
                isbn = isbn.Replace("'", "");
                SelectCommand = "SELECT * FROM textbook WHERE (Title LIKE '" + title + "%' or Title LIKE '%" + title + "%') and (Isbn10 LIKE '" + isbn + "%' or Isbn10 LIKE '%" + isbn + "%') ";
            }
            else if (title != null && author != null && isbn == null)
            {
                title = title.Replace("'", "");
                author = author.Replace("'", "");
                SelectCommand = "SELECT * FROM textbook WHERE (Title LIKE '" + title + "%' or Title LIKE '%" + title + "%') and (Author LIKE '" + author + "%' or Author LIKE '%" + author + "%') ";
            }
            else if (title == null && author == null && isbn != null)
            {
                isbn = isbn.Replace("'", "");
                SelectCommand = "SELECT * FROM textbook WHERE Isbn10 LIKE '" + isbn + "%' or Isbn10 LIKE '%" + isbn + "%' ";
            }
            else if (title == null && author != null && isbn == null)
            {
                author = author.Replace("'", "");
                SelectCommand = "SELECT * FROM textbook WHERE Author LIKE '" + author + "%' or Author LIKE '%" + author + "%' ";
            }
            else if (title != null && author == null && isbn == null)
            {
                title = title.Replace("'", "");
                SelectCommand = "SELECT * FROM textbook WHERE Title LIKE '" + title + "%' or Title LIKE '%" + title + "%' ";
            }
            return SelectCommand;
        }
    }
}