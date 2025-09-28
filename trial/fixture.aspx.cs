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
    public partial class fixture : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Specify the location of the photo to be displayed
            string photoPath = Server.MapPath("~/storage/fix/fix.jpg");

            // Check if the photo exists
            if (File.Exists(photoPath))
            {
                // Set the Image control's ImageUrl to the photo path
                Image1.ImageUrl = "~/storage/fix/fix.jpg";

                // Show the Image control
                Image1.Visible = true;
            }
        }
    }
}