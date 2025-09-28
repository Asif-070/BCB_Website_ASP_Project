using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace trial
{
    public partial class match : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Populate the dropdown list with matches from the database
                PopulateMatchesDropDown();
            }
        }

        protected void ddlMatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected match ID from the dropdown list
            string selectedMatchId = ddlMatches.SelectedValue;

            // Fetch match details from the database based on the selected ID
            Match match = GetMatchDetails(selectedMatchId);

            // Update the labels and images with the fetched match details
            UpdateMatchDetails(match);
        }

        private void PopulateMatchesDropDown()
        {
            ddlMatches.Items.Add(new ListItem("None", ""));
            // Connect to the database and fetch matches in descending order by ID
            string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            string query = "SELECT id, name FROM match ORDER BY id DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string matchId = reader["id"].ToString();
                            string matchName = reader["name"].ToString();

                            // Add the match ID and name to the dropdown list
                            ddlMatches.Items.Add(new ListItem(matchName, matchId));
                        }
                    }
                }
            }
        }

        private Match GetMatchDetails(string matchId)
        {
            // Connect to the database and fetch match details based on the match ID
            string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            string query = "SELECT * FROM match WHERE id = @matchId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@matchId", matchId);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string fullPath = reader["imgteam"].ToString();
                            string imagePath = fullPath.Replace("E:\\projects\\Web\\Project\\BCB Information Website\\trial\\", "");
                            string fullPath2 = reader["imgsc1"].ToString();
                            string imagePath2 = fullPath2.Replace("E:\\projects\\Web\\Project\\BCB Information Website\\trial\\", "");
                            string fullPath3 = reader["imgsc2"].ToString();
                            string imagePath3 = fullPath3.Replace("E:\\projects\\Web\\Project\\BCB Information Website\\trial\\", "");
                            // Read match details from the database
                            Match match = new Match
                            {
                                Name = reader["name"].ToString(),
                                Team1 = reader["team1"].ToString(),
                                Team2 = reader["team2"].ToString(),
                                Score1 = reader["score1"].ToString(),
                                Score2 = reader["score2"].ToString(),
                                Stadium = reader["stadium"].ToString(),
                                Verdict = reader["verdict"].ToString(),
                                Org = reader["org"].ToString(),
                                Report = reader["report"].ToString(),
                                ImgTeam = imagePath,
                                ImgScore1 = imagePath2,
                                ImgScore2 = imagePath3
                            };

                            return match;
                        }
                    }
                }
            }

            return null;
        }

        private void UpdateMatchDetails(Match match)
        {
            // Update the labels and images with the provided match details
            lblName.Text = match.Name;
            lblTeam1.Text = match.Team1;
            lblTeam2.Text = match.Team2;
            lblScore1.Text = match.Score1;
            lblScore2.Text = match.Score2;
            lblStadium.Text = match.Stadium;
            lblVerdict.Text = match.Verdict;
            lblOrg.Text = match.Org;
            lblReport.Text = match.Report;
            imgTeam.ImageUrl = match.ImgTeam;
            imgScore1.ImageUrl = match.ImgScore1;
            imgScore2.ImageUrl = match.ImgScore2;
        }
    }

    public class Match
    {
        public string Name { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public string Score1 { get; set; }
        public string Score2 { get; set; }
        public string Stadium { get; set; }
        public string Verdict { get; set; }
        public string Org { get; set; }
        public string Report { get; set; }
        public string ImgTeam { get; set; }
        public string ImgScore1 { get; set; }
        public string ImgScore2 { get; set; }
    }
}