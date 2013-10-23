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
    public class ProductModification
    {
        public static string[] getBookValue(string isbn)
        {
            string[] values = new string[10];
            SqlConnection con = ConnectDB.getDBConnect();
            con.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM textbook where Isbn10=" + isbn, con);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    values[0] = reader["Title"].ToString();
                    values[1] = reader["Isbn10"].ToString();
                    values[2] = reader["Isbn13"].ToString();
                    values[3] = reader["Price"].ToString();
                    values[4] = reader["Author"].ToString();
                    values[5] = reader["Year"].ToString();
                    values[6] = reader["Description"].ToString();
                    values[7] = reader["Language"].ToString();
                    values[8] = reader["Publisher"].ToString();
                    values[9] = reader["Department"].ToString();
                }
            }
            con.Close();
            return values;
        }

        public static string[] getReviewValue(string id)
        {
            SqlConnection con = ConnectDB.getDBConnect();
            con.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM review where Id=@id ", con);
            command.Parameters.Add("@id", SqlDbType.BigInt).Value = id.Replace("\'", "");
            SqlDataReader reader = command.ExecuteReader();
            string[] values = new string[4];
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    values[0] = reader["Title"].ToString();
                    values[1] = reader["Name"].ToString() + "\'s Review";
                    values[2] = reader["Content"].ToString();
                    values[3] = reader["Rating"].ToString();
                }
            }
            con.Close();
            return values;
        }
    }
}