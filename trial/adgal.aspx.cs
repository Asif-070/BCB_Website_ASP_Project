using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace trial
{
    public partial class adgal : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //create new sqlconnection and connection to database by using connection string from web.config file  
                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                SqlDataAdapter sda = new SqlDataAdapter("SELECT [id], [title] FROM gallery ORDER BY [id] DESC", con);
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

        protected void add_Click(object sender, EventArgs e)
        {
            string title = this.TextBox1.Text.Trim();
            string fileName = imageUpload.FileName;
            string fileExtension = System.IO.Path.GetExtension(fileName);
            string pk = GeneratePrimaryKey();

            if (string.IsNullOrEmpty(title))
            {
                warn.Text = "Please add title";
                warn.ForeColor = Color.Red;
            }
            else if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".jpeg" || fileExtension.ToLower() == ".png")
            {

                // Save the uploaded image to a folder with the ID as the file name
                string filePath = Server.MapPath("~/storage/gallery/" + pk + fileExtension);
                imageUpload.SaveAs(filePath);

                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO gallery (id,title,img) VALUES ('" + pk + "','" + title + "','" + filePath + "')", con);

                cmd.ExecuteNonQuery();

                con.Close();

                warn.Text = " ";
                warn.Text = "Image has been added";
                warn.ForeColor = Color.Black;

                Response.Redirect(Request.RawUrl);
            }
            else
            {
                // Display an error message if the uploaded file is not an image
                Response.Write("<script>alert('Please upload a valid image file!');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string id = this.TextBox2.Text.Trim();
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
                    SqlCommand cmd = new SqlCommand("DELETE FROM gallery WHERE ID=@Id", con);
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