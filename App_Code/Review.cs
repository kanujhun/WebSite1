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
    public class Review
    {
        public static void InsertReview(object[] values)
        {
            SqlConnection con = ConnectDB.getDBConnect();
            con.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO review (Title,Name,Rating,Content,Date,Isbn10) 
                                        VALUES (@title,@Name,@rating,@content,@date,@isbn10)", con);
            cmd.Parameters.Add("@title", SqlDbType.VarChar, 100).Value = values[0];
            cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = values[1];
            cmd.Parameters.Add("@content", SqlDbType.VarChar, 500).Value = values[2];
            cmd.Parameters.Add("@rating", SqlDbType.Int).Value = values[3];
            cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = values[4];
            cmd.Parameters.Add("@isbn10", SqlDbType.VarChar, 10).Value = values[5];
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.Close();
        }

        public static void UpdateReview(object[] values)
        {
            SqlConnection con = ConnectDB.getDBConnect();
            con.Open();
            SqlCommand cmd = new SqlCommand(@"update [review] set [Title] = @title, [Content] = @content, [Rating] = @rating 
                                                where [Id] =@id", con);
            cmd.Parameters.Add("@title", SqlDbType.VarChar, 100).Value = values[0];
            cmd.Parameters.Add("@content", SqlDbType.VarChar, 500).Value = values[1];
            cmd.Parameters.Add("@rating", SqlDbType.Int).Value = values[2];
            cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = values[3];
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.Close();
        }

        public static void DeleteReview(string id)
        {
            SqlConnection con = ConnectDB.getDBConnect();
            con.Open();

            SqlCommand cmd = new SqlCommand("delete from review where Id =@id", con);
            cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id.Replace("\'", "");
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.Close();
        }
    }
}