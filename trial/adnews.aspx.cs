using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace trial
{
    public partial class adnews : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void add_Click(object sender, EventArgs e)
        {
            string title = this.TextBox1.Text.Trim();
            string details = this.TextArea1.Value;
            string fileName = imageUpload.FileName;
            string fileExtension = System.IO.Path.GetExtension(fileName);
            string pk = GeneratePrimaryKey();

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(details))
            {
                warn.Text = "Please fill up all necessary information";
                warn.ForeColor = Color.Red;
            }
            else if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".jpeg" || fileExtension.ToLower() == ".png")
            {
                try
                {
                    // Save the uploaded image to a folder with the ID as the file name
                    string filePath = Server.MapPath("~/storage/news/" + pk + fileExtension);
                    imageUpload.SaveAs(filePath);

                    // Insert the data into the database
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO news (id, title, details, img) VALUES ('" + pk + "', '" + title + "', '" + details + "', '" + filePath + "')", con);

                    cmd.ExecuteNonQuery();

                    con.Close();

                    warn.Text = "News has been added";
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
                warn.Text = "Please upload a valid image file!";
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