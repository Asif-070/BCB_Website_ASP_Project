using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

namespace trial
{
    public partial class mainpage : System.Web.UI.Page
    {
        public List<Article> NewsArticles { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            // Specify the location of the photo to be displayed
            string photoPath = Server.MapPath("~/storage/fix/fix.jpg");

            // Check if the photo exists
            if (File.Exists(photoPath))
            {
                // Set the Image control's ImageUrl to the photo path
                Image1.ImageUrl = "~/storage/fix/fix.jpg";

                // Show the Image control
                Image1.Visible = true;
            }

            if (!IsPostBack)
            {
                NewsArticles = FetchNewsArticles();
            }
        }

        List<Article> FetchNewsArticles()
        {
            List<Article> articles = new List<Article>();

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT id, img, title FROM news ORDER BY id DESC";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string id = reader["id"].ToString();
                        string fullPath = reader["img"].ToString();
                        string imagePath = fullPath.Replace("E:\\projects\\Web\\Project\\BCB Information Website\\trial\\", "");
                        string title = reader["title"].ToString();

                        Article article = new Article
                        {
                            Id = id,
                            ImagePath = imagePath,
                            Title = title
                        };

                        articles.Add(article);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception or display an error message
            }

            return articles;
        }
    }
}