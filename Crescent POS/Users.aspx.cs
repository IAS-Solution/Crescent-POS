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
    public partial class Users : System.Web.UI.Page
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        MySqlConnection con = new MySqlConnection(connectionString);
        MySqlDataReader rdr;
        MySqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            DataLoard();
            if (!Page.IsPostBack)
            {
                if (Session["user_name"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFullName.Text == "")
                {
                    string script = "alert(\"Please give the name to save!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    return;
                }
                if (txtUserName.Text == "")
                {
                    string script = "alert(\"Please give a username to save!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    return;
                }
                if (txtPassword.Text == "")
                {
                    string script = "alert(\"Please give a password to save!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    return;
                }

                con.Open();
                string ct = "select user_name from tbllogin where user_name=@find";
                MySqlCommand cmd = new MySqlCommand(ct);
                cmd.Connection = con;
                // cmd.Parameters.Add(new MySqlParameter("@find", System.Data.SqlDbType.NChar, 30, "UserName"));
                cmd.Parameters.Add(new MySqlParameter("@find", MySqlDbType.VarChar, 30, "user_name"));
                cmd.Parameters["@find"].Value = txtUserName.Text;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    string script = "alert(\"The username already exist please select a new one!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    txtUserName.Text = "";
                    txtUserName.Focus();


                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

              
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    string cd = "insert into tbllogin(Full_name,user_name,user_level,password) values(@Full_name,@user_name,@user_level,@password)";
                    cmd = new MySqlCommand(cd);
                    cmd.Parameters.AddWithValue("@Full_name", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@user_name", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@user_level", ddlUserLevel.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    string script = "alert(\"Data saved!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                   // clear();
                   // DataLoad();

                }
            }
            catch(Exception ex)
            {

            }
        }

        public void DataLoard()
        {
            string cmd = "select full_name,user_name,user_level,password from tbllogin";
            MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd, con);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            myAdapter.Fill(ds);
            dt = ds.Tables[0];

            //Bind the fetched data to gridview
            gvUsers.DataSource = dt;
            gvUsers.DataBind();

        }

        protected void gvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFullName.Text = gvUsers.SelectedRow.Cells[1].Text;
            txtUserName.Text = gvUsers.SelectedRow.Cells[2].Text;
            ddlUserLevel.Text = gvUsers.SelectedRow.Cells[3].Text;
            txtPassword.Text = gvUsers.SelectedRow.Cells[4].Text;
        }
    }
}