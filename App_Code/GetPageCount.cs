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

namespace Textbooks
{
    public class GetPageCount
    {
        private string bookcount;

        public GetPageCount(string bookcount)
        {
            this.bookcount = bookcount;
        }

        public string BookCount
        {
            get
            {
                return bookcount;
            }
        }
    }

    public class Pages
    {
        public static ArrayList PageCount()
        {
            ArrayList values = new ArrayList();
            SqlConnection con = ConnectDB.getDBConnect();
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from textbook", con);
            Int32 count = (Int32)cmd.ExecuteScalar();
            decimal value = count / 10;
            value = Math.Ceiling(value);
            for (int i = 0; i <= value; i++)
            {
                Int32 num1 = (((i + 1) - 1) * 10) + 1;
                Int32 num2 = (i + 1) * 10;
                values.Add(new GetPageCount("<a href='default.aspx?numpage=" + (num1 - 1) + "'>" + num1 + "-" + num2 + "</a>"));
            }
            con.Close();
            return values;
        }
    }
}