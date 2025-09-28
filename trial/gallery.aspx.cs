using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace trial
{
    public partial class gallery : System.Web.UI.Page
    {
        public List<Article> NewsArticles { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
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
                    string query = "SELECT id, img, title FROM gallery ORDER BY id DESC";
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