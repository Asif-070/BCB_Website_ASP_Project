using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace trial
{
    public partial class confirmation : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.Items.Insert(0, new ListItem("Rocket", "3"));
                DropDownList1.Items.Insert(0, new ListItem("Nogod", "2"));
                DropDownList1.Items.Insert(0, new ListItem("Bikash", "1"));
                DropDownList1.Items.Insert(0, new ListItem("None", "0"));
                Button2.Enabled = false;

                if (Request.QueryString["id"] != null)
                {
                    string count = "";
                    string tickid = Request.QueryString["id"];
                    string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string query = "SELECT * FROM ticket where id = " + tickid;
                        SqlCommand cmd = new SqlCommand(query, con);
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            count = reader["count"].ToString();
                        }
                    }
                    if (count.Equals("0"))
                    {
                        Button1.Enabled = false;
                    }
                }

                if (Request.QueryString["id"] != null)
                {
                    string tickid = Request.QueryString["id"];
                    string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string query = "SELECT * FROM ticket where id = " + tickid;
                        SqlCommand cmd = new SqlCommand(query, con);
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string name = reader["name"].ToString();
                            Label1.Text += name;
                        }
                    }
                }
            }
        }
        public string x = "";
        protected void Button1_Click(object sender, EventArgs e)
        {
            string drop = DropDownList1.SelectedItem.Value;
            string txid = TextBox1.Text.Trim();

            if (drop.Equals("0"))
            {
                lbl.Text = "Please select a method";
                lbl.ForeColor = Color.Red;
            }
            else if (string.IsNullOrEmpty(txid))
            {
                lbl.Text = "Please add the transaction id";
                lbl.ForeColor = Color.Red;
            }
            else
            {
                string name = "";
                string team = "";
                string venue = "";
                string datetime = "";
                string count = "";
                if (Request.QueryString["id"] != null)
                {
                    string tickid = Request.QueryString["id"];
                    string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string query = "SELECT * FROM ticket WHERE id = @tickid";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@tickid", tickid);
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            name = reader["name"].ToString();
                            team = reader["team"].ToString();
                            venue = reader["venue"].ToString();
                            datetime = reader["datetime"].ToString();
                            count = reader["count"].ToString();
                        }
                    }
                    // Decrement the count by 1
                    int countValue;
                    if (int.TryParse(count, out countValue))
                    {
                        countValue--;
                        count = countValue.ToString();

                        // Update the count in the database
                        string updateQuery = "UPDATE ticket SET count = @count WHERE id = @tickid";
                        using (SqlConnection updateCon = new SqlConnection(connectionString))
                        {
                            SqlCommand updateCmd = new SqlCommand(updateQuery, updateCon);
                            updateCmd.Parameters.AddWithValue("@count", count);
                            updateCmd.Parameters.AddWithValue("@tickid", tickid);
                            updateCon.Open();
                            updateCmd.ExecuteNonQuery();
                        }

                        // Increment the count by 1 in the users table for the user in session
                        string userEmail = Session["email"].ToString();
                        string userUpdateQuery = "UPDATE users SET count = CAST(count AS INT) + 1 WHERE email = @userEmail";
                        using (SqlConnection userUpdateCon = new SqlConnection(connectionString))
                        {
                            SqlCommand userUpdateCmd = new SqlCommand(userUpdateQuery, userUpdateCon);
                            userUpdateCmd.Parameters.AddWithValue("@userEmail", userEmail);
                            userUpdateCon.Open();
                            userUpdateCmd.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    lbl.Text = "Invalid ticket ID";
                }

                string smail = Session["email"].ToString();
                string sname = Session["name"].ToString();
                string sph = Session["phone"].ToString();
                // Print the method and transaction ID
                string printContent = "******************************************<br />";
                printContent += "Name: " + sname + "<br />";
                printContent += "Email: " + smail + "<br />";
                printContent += "Phone No: " + sph + "<br />";
                printContent += "" + name + "<br />";
                printContent += "" + team + "<br />";
                printContent += "Venue: " + venue + "<br />";
                printContent += "" + datetime + "<br />";
                printContent += "General Admission" + "<br />";
                printContent += "Payment Method: " + drop + "<br />";
                printContent += "Transaction ID: " + txid + "<br />";
                printContent += "******************************************";
                //lbl.Text = printContent;
                // Register the script to print the content
                string script = "<script type='text/javascript'>"
                    + "function printContent() {"
                    + "var w = window.open();"
                    + "w.document.write('" + printContent + "');"
                    + "w.document.close();"
                    + "w.print();"
                    + "w.close();"
                    + "}"
                    + "</script>";

                Session["print"] = printContent;
                ClientScript.RegisterStartupScript(this.GetType(), "PrintScript", script);

                // Call the printContent() JavaScript function to trigger the print dialog
                ClientScript.RegisterStartupScript(this.GetType(), "PrintFunction", "printContent();", true);

                Button1.Enabled = false;
                Button2.Enabled = true;
            }
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            // Register the script to print the content from the session
            string script = "<script type='text/javascript'>"
                + "function printContent() {"
                + "var w = window.open();"
                + "w.document.write('" + Session["print"].ToString() + "');"
                + "w.document.close();"
                + "w.print();"
                + "w.close();"
                + "}"
                + "</script>";

            ClientScript.RegisterStartupScript(this.GetType(), "PrintScript", script);

            // Call the printContent() JavaScript function to trigger the print dialog
            ClientScript.RegisterStartupScript(this.GetType(), "PrintFunction", "printContent();", true);

        }
    }
}