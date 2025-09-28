using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

namespace trial
{
    public partial class login : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the cookie exists
                if (Request.Cookies["mailtext"] != null)
                {
                    // Retrieve the cookie value and populate TextBox1
                    string username = Request.Cookies["mailtext"].Value;
                    mailtext.Text = username;
                }
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string mail = this.mailtext.Text.Trim();
            string pass = this.passtext.Text.Trim();

            if (string.IsNullOrEmpty(mail) && string.IsNullOrEmpty(pass))
            {
                lbl.Text = "";
                lbl.Text = lbl.Text + "Please fillup all fields";
                lbl.ForeColor = Color.Red;
            }
            else
            {
                //string hashedPassword = HashPassword(pass);

                SqlConnection con = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE Email=@Email", con);
                cmd.Parameters.AddWithValue("@Email", mail);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                con.Open();

                if (dt.Rows.Count > 0)
                {
                    string storedPassword = dt.Rows[0]["Pass"].ToString();

                    if (VerifyPassword(pass, storedPassword))
                    {
                        string redirectUrl = "profile.aspx?email=" + HttpUtility.UrlEncode(mail);
                        Session["email"] = mail;

                        // Create a new cookie to store the username
                        HttpCookie cookie = new HttpCookie("mailtext", mail);
                        // Set the cookie to expire at the end of the session
                        cookie.Expires = DateTime.Now.AddMinutes(60); // You can adjust the expiration time as needed

                        // Add the cookie to the response
                        Response.Cookies.Add(cookie);

                        Response.Redirect(redirectUrl);
                    }
                    else
                    {
                        lbl.Text = "Your username or password is incorrect";
                        lbl.ForeColor = Color.Red;
                    }
                }
                else if (mail.Equals("admin") && pass.Equals("admin"))
                {
                    Response.Redirect("adhome.aspx");
                }
                else
                {
                    lbl.Text = "Your username or password is incorrect";
                    lbl.ForeColor = Color.Red;
                }

                con.Close();

            }
        }

        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(storedPassword);

            // Extract the salt from the stored password hash
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            // Hash the entered password using the extracted salt
            var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            // Compare the hashed passwords
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}