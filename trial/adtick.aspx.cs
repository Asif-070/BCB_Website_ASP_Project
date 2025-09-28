using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace trial
{
    public partial class adtick : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void add_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text.Trim();
            string team1 = TextBox2.Text.Trim();
            string team2 = TextBox3.Text.Trim();
            string venue = TextBox4.Text.Trim();
            string date = TextBox5.Text.Trim();
            string time = TextBox6.Text.Trim();
            int count;
            int.TryParse(TextBox7.Text, out count);
            string pk = GeneratePrimaryKey();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(team1) || string.IsNullOrEmpty(team2) || string.IsNullOrEmpty(venue) || string.IsNullOrEmpty(date) || string.IsNullOrEmpty(time))
            {
                warn.Text = "Please fill up all necessary information";
                warn.ForeColor = Color.Red;
            }
            else
            {
                string team = team1 + " vs " + team2;
                string datetime = date + " " + time;
                try
                {
                    // Insert the data into the database
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        con.Open();

                        string query = "INSERT INTO ticket (id, name, team, venue, datetime, count) VALUES (@id, @name, @team, @venue, @datetime, @count)";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@id", GeneratePrimaryKey());
                            cmd.Parameters.AddWithValue("@name", name);
                            cmd.Parameters.AddWithValue("@team", team);
                            cmd.Parameters.AddWithValue("@venue", venue);
                            cmd.Parameters.AddWithValue("@datetime", datetime);
                            cmd.Parameters.AddWithValue("@count", count);

                            cmd.ExecuteNonQuery();
                        }

                        con.Close();
                    }

                    warn.Text = "New ticket has been added";
                    warn.ForeColor = Color.Black;
                }
                catch (Exception ex)
                {
                    warn.Text = "An error occurred: " + ex.Message;
                    warn.ForeColor = Color.Red;
                }
            }
        }

        string GeneratePrimaryKey()
        {
            // Get the current date and time
            DateTime now = DateTime.Now;

            // Create a formatted string using the current date and time
            string primaryKey = now.ToString("yyyyMMddHHmmss");

            return primaryKey;
        }
        }
    }