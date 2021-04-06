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
        public void hidealert()
        {
            wrningfullname.Visible = false;
            wrninguname.Visible = false;
            wrningpword.Visible = false;
            wrningunamechk.Visible = false;
            savealert.Visible = false;
            warningalert.Visible = false;
            updatealert.Visible = false;
            deletealert.Visible = false;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            hidealert();

            try
            {
                if (txtFullName.Text == "")
                {
                    wrningfullname.Visible = true;
                    
                    return;
                }
                if (txtUserName.Text == "")
                {
                    wrninguname.Visible = true;
                  
                    return;
                }
                if (txtPassword.Text == "")
                {
                    wrningpword.Visible = true;
                    
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
                    wrningunamechk.Visible = true;
                   
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
                //Response.Write("<script>alert('Data inserted successfully!')</script>");
                savealert.Visible = true;
                con1.Close();
            }
            catch (MySqlException ex)
            {
                Response.Write("<script>alert(" + ex + ")</script>");
            }
            txtboxclear();
            DataLoard();
            
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            hidealert();
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                warningalert.Visible = true;
            }
            else
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
                    updatealert.Visible = true;
                    //Response.Write("<script>alert('Data update successfully!')</script>");
                    con2.Close();

                }

                catch (MySqlException ex)
                {
                    Response.Write("<script>alert(" + ex + ")</script>");
                }
                DataLoard();
                txtboxclear();
            }
        }
        protected void btndelete_Click(object sender, EventArgs e)
        {
            hidealert();

            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                warningalert.Visible = true;
            }
            else
            {
                MySqlConnection con3 = new MySqlConnection(connectionString);


                try
                {
                    con3.Open();
                    MySqlCommand cm = new MySqlCommand("DELETE FROM tbllogin WHERE user_name = @user_name", con3);
                    cm.Parameters.AddWithValue("@user_name", txtUserName.Text);
                    

                    cm.ExecuteNonQuery();
                    cm.Dispose();
                    deletealert.Visible = true;
                    //Response.Write("<script>alert('Data update successfully!')</script>");
                    con3.Close();

                }

                catch (MySqlException ex)
                {
                    Response.Write("<script>alert(" + ex + ")</script>");
                }
                DataLoard();
                txtboxclear();
            }

        }

        public void txtboxclear()
        {
            txtFullName.Text = "";
            txtPassword.Text = "";
            txtUserName.Text = "";
            txtFullName.Text = "";



        }
        public void DataLoard()
        {
            con.Close();
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
            hidealert();
            txtFullName.Text = gvUsers.SelectedRow.Cells[1].Text;
            txtUserName.Text = gvUsers.SelectedRow.Cells[2].Text;
            ddlUserLevel.Text = gvUsers.SelectedRow.Cells[3].Text;
            txtPassword.Text = gvUsers.SelectedRow.Cells[4].Text;
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string message = string.Empty;

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    if (con != null && string.IsNullOrEmpty(message))
                    {

                        string cmd = "select * from tbllogin where user_name like '" + txtUserName.Text + "%'";

                        MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd, con);
                        DataTable dt = new DataTable();
                        DataSet ds = new DataSet();

                        myAdapter.Fill(ds);

                        dt = ds.Tables[0];

                        //Bind the fetched data to gridview

                        gvUsers.DataSource = dt;

                        gvUsers.DataBind();
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}