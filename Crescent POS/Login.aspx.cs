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
               
                string cd = ("select full_name,user_name,password,user_level  from tbllogin where username=@d1 and password=@d2 ");
                con.Open();
                MySqlCommand cmd = new MySqlCommand(cd, con);
                MySqlDataReader rdr;
                cmd.Parameters.AddWithValue("d1", txtUser.Text.Trim());
                cmd.Parameters.AddWithValue("d2", txtpassword.Text.Trim());
                cmd.ExecuteNonQuery();
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Session["full_name"] = (rdr.GetString(0));
                    //string name = (rdr.GetString(0));
                    Session["user_name"] = (rdr.GetString(1));
                    Session["user_level"] = (rdr.GetString(2));
                    Response.Redirect("index.aspx");
                }
                else
                {
                    string script = "alert(\"Incorrect User Name or Password!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                }





            }
            catch
            {

            }
        }
    }
}