﻿using System;
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


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (Session["user_name"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
            DataLoard();
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
                //data insert
                MySqlConnection con1 = new MySqlConnection(connectionString);
                con1.Open();
                MySqlCommand cm = new MySqlCommand("Insert into tbllogin (user_name,password,user_level,full_name )  values( @user_name, @password, @user_level,@full_name)", con1);


                cm.Parameters.AddWithValue("@user_name", txtUserName.Text);
                cm.Parameters.AddWithValue("@password", txtPassword.Text);
                cm.Parameters.AddWithValue("@user_level", ddlUserLevel.Text);
                cm.Parameters.AddWithValue("@full_name", txtFullName.Text);
                cm.ExecuteNonQuery();
                cm.Dispose();
                Response.Write("<script>alert('Data inserted successfully!')</script>");
                con1.Close();
            }
            catch (MySqlException ex)
            {
                Response.Write("<script>alert(" + ex + ")</script>");
            }

        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            MySqlConnection con2 = new MySqlConnection(connectionString);


            try
            {
                con2.Open();
                MySqlCommand cm = new MySqlCommand("update tbllogin Set  user_name = @user_name, password = @password, user_level = @user_level, full_name = @full_name where user_name = @user_name", con2);
                cm.Parameters.AddWithValue("@user_name", txtUserName.Text);
                cm.Parameters.AddWithValue("@password", txtPassword.Text);
                cm.Parameters.AddWithValue("@user_level", ddlUserLevel.Text);
                cm.Parameters.AddWithValue("@full_name", txtFullName.Text);

                cm.ExecuteNonQuery();
                cm.Dispose();
                Response.Write("<script>alert('Data update successfully!')</script>");
                con2.Close();

            }

            catch (MySqlException ex)
            {
                Response.Write("<script>alert(" + ex + ")</script>");
            }
            DataLoard();


        }

        public void txtboxclear()
        {
            txtFullName.Text = null;
            txtPassword.Text = null;
            txtUserName.Text = null;
            txtFullName.Text = null;



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