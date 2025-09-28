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
    public partial class admatch : System.Web.UI.Page
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
            string score1 = TextBox4.Text.Trim();
            string score2 = TextBox5.Text.Trim();
            string stadium = TextBox6.Text.Trim();
            string verdict = TextBox7.Text.Trim();
            string org = TextBox8.Text.Trim();
            string report = TextArea1.Value.Trim();

            string fileName1 = teamUpload.FileName;
            string fileExtension1 = Path.GetExtension(fileName1);
            string fileName2 = FileUpload1.FileName;
            string fileExtension2 = Path.GetExtension(fileName2);
            string fileName3 = FileUpload2.FileName;
            string fileExtension3 = Path.GetExtension(fileName3);
            string pk = GeneratePrimaryKey();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(team1) || string.IsNullOrEmpty(team2) || string.IsNullOrEmpty(score1) || string.IsNullOrEmpty(score2) || string.IsNullOrEmpty(stadium) || string.IsNullOrEmpty(verdict) || string.IsNullOrEmpty(org) || string.IsNullOrEmpty(report))
            {
                warn.Text = "Please fill up all necessary information";
                warn.ForeColor = Color.Red;
            }
            else if ((fileExtension1.ToLower() == ".jpg" || fileExtension1.ToLower() == ".jpeg" || fileExtension1.ToLower() == ".png") && (fileExtension3.ToLower() == ".jpg" || fileExtension3.ToLower() == ".jpeg" || fileExtension3.ToLower() == ".png") && (fileExtension2.ToLower() == ".jpg" || fileExtension2.ToLower() == ".jpeg" || fileExtension2.ToLower() == ".png"))
            {
                try
                {
                    // Save the uploaded images to the appropriate folder
                    string filePath1 = Path.Combine(Server.MapPath("~/storage/match/"), $"{pk}(1){fileExtension1}");
                    teamUpload.SaveAs(filePath1);

                    string filePath2 = Path.Combine(Server.MapPath("~/storage/match/"), $"{pk}(2){fileExtension2}");
                    FileUpload1.SaveAs(filePath2);

                    string filePath3 = Path.Combine(Server.MapPath("~/storage/match/"), $"{pk}(3){fileExtension3}");
                    FileUpload2.SaveAs(filePath3);

                    // Insert the data into the database
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        con.Open();

                        string query = "INSERT INTO [match] (id, name, team1, team2, score1, score2, stadium, verdict, org, report, imgteam, imgsc1, imgsc2) VALUES (@id, @name, @team1, @team2, @score1, @score2, @stadium, @verdict, @org, @report, @imgteam, @imgsc1, @imgsc2)";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@id", GeneratePrimaryKey());
                            cmd.Parameters.AddWithValue("@name", name);
                            cmd.Parameters.AddWithValue("@team1", team1);
                            cmd.Parameters.AddWithValue("@team2", team2);
                            cmd.Parameters.AddWithValue("@score1", score1);
                            cmd.Parameters.AddWithValue("@score2", score2);
                            cmd.Parameters.AddWithValue("@stadium", stadium);
                            cmd.Parameters.AddWithValue("@verdict", verdict);
                            cmd.Parameters.AddWithValue("@org", org);
                            cmd.Parameters.AddWithValue("@report", report);
                            cmd.Parameters.AddWithValue("@imgteam", filePath1);
                            cmd.Parameters.AddWithValue("@imgsc1", filePath2);
                            cmd.Parameters.AddWithValue("@imgsc2", filePath3);

                            cmd.ExecuteNonQuery();
                        }

                        con.Close();
                    }

                    warn.Text = "New match has been added";
                    warn.ForeColor = Color.Black;
                }
                catch (Exception ex)
                {
                    warn.Text = "An error occurred: " + ex.Message;
                    warn.ForeColor = Color.Red;
                }
            }
            else
            {
                // Display an error message if the uploaded file is not an image
                warn.Text = "Please upload valid image files!";
                warn.ForeColor = Color.Red;
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