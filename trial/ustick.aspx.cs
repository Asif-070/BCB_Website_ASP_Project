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
    public partial class ustick : System.Web.UI.Page
    {
        public List<Tick> NewsArticles { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //string smail = Session["email"].ToString() + Session["name"].ToString() + Session["phone"].ToString();
            //lblMessage.Text = smail;
            if (!IsPostBack)
            {
                NewsArticles = FetchNewsArticles();
            }
        }

        List<Tick> FetchNewsArticles()
        {
            List<Tick> articles = new List<Tick>();

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM ticket";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string id = reader["id"].ToString();
                        string name = reader["name"].ToString();
                        string team = reader["team"].ToString();
                        string venue = reader["venue"].ToString();
                        string datetime = reader["datetime"].ToString();
                        string count = reader["count"].ToString();

                        if (count.Equals('0'))
                        {
                            count = "Sold Out";
                        }

                        Tick tick = new Tick
                        {
                            Id = id,
                            Name = name,
                            Team = team,
                            Venue = venue,
                            Datetime = datetime,
                            Count = count
                        };

                        articles.Add(tick);
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
    public class Tick
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public string Venue { get; set; }
        public string Datetime { get; set; }
        public string Count { get; set; }
    }
}