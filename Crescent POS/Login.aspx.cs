using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace Crescent_POS
{
    public partial class Login : System.Web.UI.Page
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        MySqlConnection con = new MySqlConnection(connectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            Session["user_name"] = null;
            Session["user_level"] = null;
            Session["full_name"] = null;

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            try
            {

                string cd = ("SELECT user_name,password, user_level, full_name FROM tbllogin WHERE  user_name=@uname and password=@pword ");
                con.Open();
                MySqlCommand cmd = new MySqlCommand(cd, con);
                MySqlDataReader rdr;
                cmd.Parameters.AddWithValue("@uname", txtUser.Text.Trim());
                cmd.Parameters.AddWithValue("@pword", txtpassword.Text.Trim());
                cmd.ExecuteNonQuery();
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Session["user_name"] = (rdr.GetString(0));
                    Session["user_level"] = (rdr.GetString(2));
                    Session["full_name"] = (rdr.GetString(3));
                    Response.Redirect("index.aspx");
                }
                else
                {
                    string script="alert(\"Incorrect User Name Or Password!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                string script = "alert(\"" +ex.StackTrace+"\")";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
    }
}