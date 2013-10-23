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
    public class ConnectDB
    {
        public static SqlConnection getDBConnect()
        {
            //ConnectionStrings
            string ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ToString();

            SqlConnection con = new SqlConnection(ConnectionString);
            return con;
        }
    }
}