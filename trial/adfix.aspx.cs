using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace trial
{
    public partial class adfix : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Specify the location of the photo to be displayed
            string photoPath = Server.MapPath("~/storage/fix/fix.jpg");

            string imageUrl = "~/storage/fix/fix.jpg?" + DateTime.Now.Ticks;
            // Check if the photo exists
            if (File.Exists(photoPath))
            {
                // Set the Image control's ImageUrl to the photo path
                Image1.ImageUrl = "~/storage/fix/fix.jpg";

                // Show the Image control
                Image1.Visible = true;
            }
            else
            {
                // Display an error message if the photo doesn't exist
                warn.Text = "The photo does not exist.";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (imageUpload.HasFile)
            {
                // Get the selected image file
                HttpPostedFile postedFile = imageUpload.PostedFile;

                // Get the file extension
                string fileExtension = Path.GetExtension(postedFile.FileName).ToLower();

                // Check if the selected file is an image
                string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
                if (allowedExtensions.Contains(fileExtension))
                {
                    try
                    {
                        // Specify the location of the photo to be replaced
                        string photoPath = Server.MapPath("~/storage/fix/fix.jpg");

                        // Save the selected image file to the specified location, replacing the existing photo
                        imageUpload.SaveAs(photoPath);

                        // Display a success message
                        Response.Redirect(Request.RawUrl);
                        warn.Text = "Photo replaced successfully.";
                        
                    }
                    catch (Exception ex)
                    {
                        // Display an error message if there is an exception
                        warn.Text = "An error occurred: " + ex.Message;
                    }
                }
                else
                {
                    // Display an error message if the selected file is not an image
                    warn.Text = "Please select a valid image file.";
                }
            }
            else
            {
                // Display a message if no file is selected
                warn.Text = "Please select an image file.";
            }
        }


    }
}