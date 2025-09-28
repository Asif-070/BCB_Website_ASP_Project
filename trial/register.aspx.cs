using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace trial
{
    public partial class register : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Click(object sender, EventArgs e)
        {
            //message.Text = "You have successfuly Registered";

            string name = this.namebox.Text.Trim();
            string pass = this.passbox.Text.Trim();
            string pass2 = this.passbox2.Text.Trim();
            string email = this.mailbox.Text.Trim();
            string phone = this.phonebox.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(pass2) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone))
            {
                lbl.Text = "Please fillup all necessary information";
                lbl.ForeColor = Color.Red;
            }
            else if (pass.Length < 8)
            {
                lbl.Text = "Password must be at least 8 characters long";
                lbl.ForeColor = Color.Red;
            }
            else if (!pass.Equals(pass2))
            {
                lbl.Text = "Password in both feilds does not match";
                lbl.ForeColor = Color.Red;
            }
            else if (!(email.Contains("@") && email.Contains(".com")))
            {
                lbl.Text = "Please enter valid email";
                lbl.ForeColor = Color.Red;
            }
            else if (!(phone.Contains("019") || phone.Contains("017") || phone.Contains("016") || phone.Contains("015") || phone.Contains("018")) || phone.Length != 11)
            {
                lbl.Text = "Please enter valid phone no";
                lbl.ForeColor = Color.Red;
            }
            else if (!CheckBox.Checked)
            {
                lbl.Text = "Please check the above agreement";
                lbl.ForeColor = Color.Red;
            }
            else
            {
                string hashedPassword = HashPassword(pass);
                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                // Check if the email already exists in the database
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM users WHERE Email=@Email", con);
                checkCmd.Parameters.AddWithValue("@Email", email);
                int emailCount = (int)checkCmd.ExecuteScalar();

                if (emailCount > 0)
                {
                    lbl.Text = "Account with given Email already exists";
                    lbl.ForeColor = Color.Red;
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO users (email,name,pass,phone_no,count) VALUES ('" + email + "','" + name + "','" + hashedPassword + "','" + phone + "',  0)", con);

                    cmd.ExecuteNonQuery();

                    con.Close();

                    Response.Redirect("login.aspx");
                }

                    
            }


        }

        // Hash the password using bcrypt
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
    }
}