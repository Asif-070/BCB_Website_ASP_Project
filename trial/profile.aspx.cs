using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace trial
{
    public partial class profile : System.Web.UI.Page
    {
        string email;
        string passreal;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["email"] != null)
                {
                    email = Request.QueryString["email"];
                    DataTable dt = GetUserData(email);

                    if (dt.Rows.Count > 0)
                    {
                        lblEmail.Text = dt.Rows[0]["Email"].ToString();
                        lblName.Text = dt.Rows[0]["Name"].ToString();
                        lblPhone.Text = dt.Rows[0]["Phone_no"].ToString();
                        passreal = dt.Rows[0]["Pass"].ToString();
                        Session["name"] = lblName.Text;
                        Session["phone"] = lblPhone.Text;
                        lblMessage.Text = passreal;
                        lblMessage.Visible = false;
                    }
                    else
                    {
                        lblMessage.Text = "Profile not found";
                    }
                }
                else
                {
                    lblMessage.Text = "Fatal Error";
                }
            }
        }

        private DataTable GetUserData(string email)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE Email=@Email", con);
                cmd.Parameters.AddWithValue("@Email", email);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            string passog = this.ogbox.Text.Trim();
            string pass = this.passbox.Text.Trim();
            string pass2 = this.passbox2.Text.Trim();
            string pass3 = this.lblMessage.Text.Trim();

            if (string.IsNullOrEmpty(passog) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(pass2))
            {
                lblMessage2.Text = "Please fillup all necessary information";
            }
            else if (pass.Length < 8)
            {
                lblMessage2.Text = "Password must be at least 8 characters long";
            }
            else if (!pass.Equals(pass2))
            {
                lblMessage2.Text = "Password in both feilds does not match";
            }
            else if (!VerifyPassword(passog, pass3))
            {
                lblMessage2.Text = "Orginal Password is not correct";
            }
            else
            {
                string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                string hashedPassword = HashPassword(pass);
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE users SET Pass = @NewPassword WHERE Email = @Email", con);
                cmd.Parameters.AddWithValue("@NewPassword", hashedPassword);
                cmd.Parameters.AddWithValue("@Email", lblEmail.Text.Trim());

                cmd.ExecuteNonQuery();

                con.Close();
                Response.Redirect(Request.RawUrl);

            }
        }

        private string HashPassword(string password)
        {
            // Generate a salt
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            // Hash the password with the salt
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            // Combine the salt and password hash
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // Convert the combined salt and password hash to a string for storage
            string hashedPassword = Convert.ToBase64String(hashBytes);

            return hashedPassword;
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