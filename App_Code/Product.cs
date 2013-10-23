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
    public class Product
    {
        public static void InsertBook(object[] values)
        {
            SqlConnection con = ConnectDB.getDBConnect();
            con.Open();

            SqlCommand cmd = new SqlCommand(@"INSERT INTO textbook (ImagePath,Title,Isbn10,Isbn13,
                                Price,Author,Year,Rating,Description,Language,Publisher,Department,Rate,
                                ReviewCount) VALUES (@imagePath,@title,@isbn10,@isbn13,@price,@author,@year,@rating,
                                @desc,@lang,@pub,@dep,@rate,@count)", con);
            cmd.Parameters.Add("@ImagePath", SqlDbType.NVarChar).Value = values[0];
            cmd.Parameters.Add("@title", SqlDbType.VarChar, 50).Value = values[1];
            cmd.Parameters.Add("@isbn10", SqlDbType.VarChar, 10).Value = values[2];
            cmd.Parameters.Add("@isbn13", SqlDbType.VarChar, 14).Value = values[3];
            cmd.Parameters.Add("@price", SqlDbType.Decimal, 6).Value = values[4];
            cmd.Parameters.Add("@author", SqlDbType.VarChar, 50).Value = values[5];
            cmd.Parameters.Add("@year", SqlDbType.VarChar, 4).Value = values[6];
            cmd.Parameters.Add("@rating", SqlDbType.VarChar, 50).Value = values[7];
            cmd.Parameters.Add("@desc", SqlDbType.VarChar, 200).Value = values[8];
            cmd.Parameters.Add("@lang", SqlDbType.VarChar, 30).Value = values[9];
            cmd.Parameters.Add("@pub", SqlDbType.VarChar, 50).Value = values[10];
            cmd.Parameters.Add("@dep", SqlDbType.VarChar, 50).Value = values[11];
            cmd.Parameters.Add("@rate", SqlDbType.Decimal, 2).Value = values[12];
            cmd.Parameters.Add("@count", SqlDbType.Int).Value = values[13];
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            con.Close();
        }

        public static void UpdateBook(object[] values, string isbn)
        {
            SqlConnection con = ConnectDB.getDBConnect();
            con.Open();

            SqlCommand cmd = new SqlCommand(@"update [textbook] set [Title] = @title, [Isbn13] = @isbn13, 
                                [Price] = @price, [Author] = @author, [Year] = @year, [Description] = @desc, [Language] = @lang, 
                                [Publisher] = @pub, [Department] = @dep where [Isbn10] =" + isbn, con);
            cmd.Parameters.Add("@title", SqlDbType.VarChar, 50).Value = values[0];
            cmd.Parameters.Add("@isbn13", SqlDbType.VarChar, 14).Value = values[1];
            cmd.Parameters.Add("@price", SqlDbType.Decimal, 6).Value = values[2];
            cmd.Parameters.Add("@author", SqlDbType.VarChar, 50).Value = values[3];
            cmd.Parameters.Add("@year", SqlDbType.VarChar, 4).Value = values[4];
            cmd.Parameters.Add("@desc", SqlDbType.VarChar, 200).Value = values[5];
            cmd.Parameters.Add("@lang", SqlDbType.VarChar, 30).Value = values[6];
            cmd.Parameters.Add("@pub", SqlDbType.VarChar, 50).Value = values[7];
            cmd.Parameters.Add("@dep", SqlDbType.VarChar, 50).Value = values[8];
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            con.Close();
        }

        public static void DeleteBook(string isbn)
        {
            string isbn10 = "'" + isbn + "'";
            SqlConnection con = ConnectDB.getDBConnect();
            con.Open();

            SqlCommand cmd = new SqlCommand("delete from textbook where [Isbn10] =" + isbn10, con);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            SqlCommand command = new SqlCommand("delete from review where [Isbn10] =" + isbn10, con);
            command.Connection = con;
            command.ExecuteNonQuery();

            con.Close();
        }
    }
}