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
    public class CheckTables
    {
        public static void CheckBookTable()
        {
            SqlConnection con = ConnectDB.getDBConnect();
            con.Open();

            Int32 count = 0;
            SqlCommand cmd = new SqlCommand("select count(*) from textbook;", con);
            try
            {
                count = (Int32)cmd.ExecuteScalar();
            }
            catch
            {
                SqlCommand cmd1 = new SqlCommand(@"CREATE TABLE [dbo].[textbook] ( 
                                [ImageId]     BIGINT         IDENTITY (1, 1) NOT NULL,
                                [Title]       VARCHAR (50)   NOT NULL,
                                [Isbn10]      VARCHAR (10)   NOT NULL,
                                [Isbn13]      VARCHAR (14)   NULL,
                                [Price]       DECIMAL (6, 2) NULL,
                                [Author]      VARCHAR (50)   NULL,
                                [Year]        VARCHAR (4)    NULL,
                                [Rating]      VARCHAR (50)   NULL,
                                [Description] VARCHAR (200)  NULL,
                                [Language]    VARCHAR (30)   NULL,
                                [Department]  VARCHAR (50)   NULL,
                                [Publisher]   VARCHAR (50)   NULL,
                                [ImagePath]   NVARCHAR (MAX) NULL,
                                [Rate]        DECIMAL (2, 1) NULL,
                                [ReviewCount] INT            NULL,
                                PRIMARY KEY CLUSTERED ([ImageId] ASC))", con);
                cmd1.Connection = con;
                cmd1.ExecuteNonQuery();
            }
            CheckReviewTable(con);
        }

        public static void CheckReviewTable(SqlConnection con)
        {
            Int32 count = 0;
            SqlCommand cmd = new SqlCommand("select count(*) from review;", con);
            try
            {
                count = (Int32)cmd.ExecuteScalar();
            }
            catch
            {
                SqlCommand cmd2 = new SqlCommand(@"CREATE TABLE [dbo].[review] (
                                [Id]      BIGINT        IDENTITY (1, 1) NOT NULL,
                                [Name]    VARCHAR (50)  NULL,
                                [Title]   VARCHAR (100) NULL,
                                [Content] VARCHAR (MAX) NULL,
                                [Rating]  INT           NULL,
                                [Date]    DATETIME      NULL,
                                [Isbn10]  VARCHAR (12)  NULL,
                                PRIMARY KEY CLUSTERED ([Id] ASC))", con);
                cmd2.Connection = con;
                cmd2.ExecuteNonQuery();
            }
            con.Close();
        }
    }
}