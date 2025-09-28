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
    public partial class photoDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    string articleId = Request.QueryString["id"];
                    Article article = FetchNewsArticle(articleId);

                    if (article != null)
                    {
                        lblTitle.Text = article.Title;
                        imgNews.ImageUrl = article.ImagePath;
                    }
                    else
                    {
                        lblTitle.Text = "Article not found";
                    }
                }
                else
                {
                    lblTitle.Text = "Invalid article ID";
                }
            }
        }

        Article FetchNewsArticle(string articleId)
        {
            Article article = null;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT title, img FROM gallery WHERE id = @ArticleID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ArticleID", articleId);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string title = reader["title"].ToString();
                        string fullPath = reader["img"].ToString();
                        string imagePath = fullPath.Replace("E:\\projects\\Web\\Project\\BCB Information Website\\trial\\", "");

                        article = new Article
                        {
                            Title = title,
                            ImagePath = imagePath
                        };
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception or display an error message
            }

            return article;
        }
    }
}