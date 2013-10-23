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
    public class Rating
    {
        public static float getBookRating(string isbn)
        {
            SqlConnection con = ConnectDB.getDBConnect();
            con.Open();
            SqlCommand command1 = new SqlCommand("SELECT Rating FROM review where Isbn10=@isbn", con);
            command1.Parameters.Add("@isbn", SqlDbType.VarChar, 10).Value = isbn.Replace("\'", "");
            SqlDataReader reader = command1.ExecuteReader();
            command1.Parameters.Clear();
            int sum = 0;
            int i = 0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    sum += Convert.ToInt32(reader["Rating"]);
                    i++;
                }
            }
            else { i = 1; }
            float rating = (float)sum / (float)i;
            con.Close();
            return rating;
        }

        public static void UpdateRating(string isbn)
        {
            float rating = getBookRating(isbn);
            string starPath = "img/1.png";
            if (rating <= 5 && rating >= 4.6) { starPath = "img/5.png"; }
            else if (rating <= 4.5 && rating >= 4.1) { starPath = "img/4.5.png"; }
            else if (rating <= 4 && rating >= 3.6) { starPath = "img/4.png"; }
            else if (rating <= 3.5 && rating >= 3.1) { starPath = "img/3.5.png"; }
            else if (rating <= 3 && rating >= 2.6) { starPath = "img/3.png"; }
            else if (rating <= 2.5 && rating >= 2.1) { starPath = "img/2.5.png"; }
            else if (rating <= 2 && rating >= 1.6) { starPath = "img/2.png"; }
            else if (rating == 0) { starPath = ""; }
            SqlConnection con = ConnectDB.getDBConnect();
            con.Open();
            SqlCommand cmd1 = new SqlCommand("update textbook set Rating=@sum, Rate=@sumrate where Isbn10=@isbn", con);
            cmd1.Parameters.Add("@sum", SqlDbType.VarChar, 50).Value = starPath;
            cmd1.Parameters.Add("@sumrate", SqlDbType.Decimal, 2).Value = rating;
            cmd1.Parameters.Add("@isbn", SqlDbType.VarChar, 10).Value = isbn.Replace("\'", "");
            cmd1.Connection = con;
            cmd1.ExecuteNonQuery();
            cmd1.Parameters.Clear();

            UpdateReviewCount(isbn, con);
        }

        public static void UpdateReviewCount(string isbn, SqlConnection con)
        {
            Int32 count = 0;
            SqlCommand command = new SqlCommand("SELECT count(*) FROM review where Isbn10=@isbn ", con);
            command.Parameters.Add("@isbn", SqlDbType.VarChar, 10).Value = isbn.Replace("\'", "");
            count = (Int32)command.ExecuteScalar();
            command.Parameters.Clear();

            SqlCommand cmd = new SqlCommand("update textbook set ReviewCount=@count where Isbn10=@isbn ", con);
            cmd.Parameters.Add("@count", SqlDbType.Int).Value = count;
            cmd.Parameters.Add("@isbn", SqlDbType.VarChar, 10).Value = isbn.Replace("\'", "");
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.Close();
        }
    }
}