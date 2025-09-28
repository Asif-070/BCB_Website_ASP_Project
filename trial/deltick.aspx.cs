using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace trial
{
    public partial class deltick : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //create new sqlconnection and connection to database by using connection string from web.config file  
                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                SqlDataAdapter sda = new SqlDataAdapter("SELECT [id], [name], [team], [datetime], [count] FROM ticket ORDER BY [id] DESC", con);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);

                CoursesGridView.DataSource = dtbl;
                CoursesGridView.DataBind();

                // Close the connection
                con.Close();
            }
            catch (Exception ex)
            {
                // Error message in alerts
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = this.TextBox1.Text.Trim();
            if (string.IsNullOrEmpty(id))
            {
                Response.Write("<script>alert('Enter an id');</script>");
            }
            else
            {
                try
                {
                    // Create a new SqlConnection and connect to the database using the connection string from the web.config file
                    SqlConnection con = new SqlConnection(strcon);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    // Create a SqlCommand to execute the DELETE statement
                    SqlCommand cmd = new SqlCommand("DELETE FROM ticket WHERE ID=@Id", con);
                    cmd.Parameters.AddWithValue("@Id", id);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Close the connection
                    con.Close();

                    if (rowsAffected > 0)
                    {
                        // Display a success message
                        Response.Write("<script>alert('Row deleted successfully');</script>");

                        // Refresh the GridView or perform any other necessary action
                        // ...
                    }
                    else
                    {
                        // Display a message if no rows were affected
                        Response.Write("<script>alert('No rows deleted');</script>");
                    }
                    Response.Redirect(Request.RawUrl);
                }
                catch (Exception ex)
                {
                    // Display an error message if an exception occurs
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string id = TextBox1.Text.Trim();

            if (!string.IsNullOrEmpty(id))
            {
                // Redirect to uptick.aspx with the ID in the URL
                Response.Redirect("uptick.aspx?id=" + id);
            }
        }
    }
}