using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace trial
{
    public partial class uptick : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the ID query string parameter exists
                if (Request.QueryString["id"] != null)
                {
                    string id = Request.QueryString["id"];

                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();

                    SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM ticket where id =" + id, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        TextBox1.Text = dt.Rows[0]["name"].ToString();
                        TextBox2.Text = dt.Rows[0]["team"].ToString();
                        TextBox3.Text = dt.Rows[0]["venue"].ToString();
                        TextBox4.Text = dt.Rows[0]["datetime"].ToString();
                        TextBox5.Text = dt.Rows[0]["count"].ToString();
                    }
                    else
                    {
                        lblMessage.Text = "Profile not found";
                    }
                }
            }
        }

        protected void add_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

            if (!string.IsNullOrEmpty(id))
            {
                string name = TextBox1.Text.Trim();
                string team = TextBox2.Text.Trim();
                string venue = TextBox3.Text.Trim();
                string datetime = TextBox4.Text.Trim();
                string count = TextBox5.Text.Trim();

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(team) || string.IsNullOrEmpty(count) || string.IsNullOrEmpty(venue) || string.IsNullOrEmpty(datetime))
                {
                    lblMessage.Text = "Please fill up all necessary information";
                    lblMessage.ForeColor = Color.Red;
                }
                else
                {
                    try
                    {
                        using (SqlConnection con = new SqlConnection(strcon))
                        {
                            con.Open();

                            string query = "UPDATE ticket SET name = @name, team = @team, venue = @venue, datetime = @datetime, count = @count where id = " + id;

                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@name", name);
                                cmd.Parameters.AddWithValue("@team", team);
                                cmd.Parameters.AddWithValue("@venue", venue);
                                cmd.Parameters.AddWithValue("@datetime", datetime);
                                cmd.Parameters.AddWithValue("@count", count);

                                cmd.ExecuteNonQuery();
                            }

                            con.Close();
                        }

                        lblMessage.Text = "Ticket updated successfully";
                        lblMessage.ForeColor = Color.Black;

                        Response.Redirect("deltick.aspx");
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = "An error occurred: " + ex.Message;
                        lblMessage.ForeColor = Color.Red;
                    }
                }
            }
        }
    }
}