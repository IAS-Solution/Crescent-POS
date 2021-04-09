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
    public partial class Customer : System.Web.UI.Page
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
            supidload();
            DataLoard();
        }
        public void supidload()
        {

            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand com = new MySqlCommand();

                com.Connection = conn;
                com.CommandText = "SELECT COUNT(*) from tblcustomer";

                int result = int.Parse(com.ExecuteScalar().ToString());
                conn.Close();
                if (result == 0)
                {
                    txtcusid.Text = "1";
                }
                else
                {
                    con.Open();
                    try
                    {
                        MySqlCommand command = new MySqlCommand("select max(cusid) from tblcustomer", con);
                        string id = command.ExecuteScalar().ToString();
                        int uid = Convert.ToInt32(id);
                        int uuid = uid + 1;
                        txtcusid.Text = uuid.ToString();
                    }
                    catch (Exception)
                    {
                        return;
                    }
                    finally
                    {
                        con.Close();
                    }
                }

            }

            finally
            {

            }

        }
        public void txtboxclear()
        {
            txtFullName.Text = "";
            txtmobile.Text = "";
            txtnic.Text = "";
            txtemail.Text = "";
            txtaddress.Text = "";
            txtamt.Text = "";
            ddlgender.SelectedIndex = 0;

        }
        public void hidealert()
        {
            warningalert.Visible = false;
            wrningaddress.Visible = false;
            wrningnic.Visible = false;
            wrningphone.Visible = false;
            wrningemail.Visible = false;
            
            wrningamt.Visible = false;
            savealert.Visible = false;
            warningalert.Visible = false;
            updatealert.Visible = false;
            deletealert.Visible = false;
            wrningex.Visible = false;
        }
        public void DataLoard()
        {
            con.Close();
            string cmd = "select CustomerName,Address,Mobile,email,gender,nic,amt from tblcustomer";
            MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd, con);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            myAdapter.Fill(ds);
            dt = ds.Tables[0];

            //Bind the fetched data to gridview
            gvsuplier.DataSource = dt;
            gvsuplier.DataBind();

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            hidealert();

            try
            {
                if (txtFullName.Text == "")
                {
                    warningalert.Visible = true;

                    return;
                }
                if (txtaddress.Text == "")
                {
                    wrningaddress.Visible = true;

                    return;
                }
                if (txtemail.Text == "")
                {
                    wrningemail.Visible = true;

                    return;
                }
                if (txtmobile.Text == "")
                {
                    wrningphone.Visible = true;

                    return;
                }
                if (txtnic.Text == "")
                {
                    wrningnic.Visible = true;

                    return;
                }
                if (txtamt.Text == "")
                {
                    wrningamt.Visible = true;

                    return;
                }
                



                //data insert
                MySqlConnection con1 = new MySqlConnection(connectionString);
                con1.Open();
                MySqlCommand cm = new MySqlCommand("Insert into tblcustomer (cusid,CustomerName,Address,Mobile,email,gender,nic,amt)  values(@cusid,@CustomerName,@Address,@Mobile,@email,@gender,@nic,@amt)", con1);

                cm.Parameters.AddWithValue("@cusid", txtcusid.Text);
                cm.Parameters.AddWithValue("@CustomerName", txtFullName.Text);
                cm.Parameters.AddWithValue("@Address", txtaddress.Text);
                cm.Parameters.AddWithValue("@Mobile", txtmobile.Text);
                cm.Parameters.AddWithValue("@email", txtemail.Text);
                cm.Parameters.AddWithValue("@gender", ddlgender.Text);
                cm.Parameters.AddWithValue("@nic", txtnic.Text);
                cm.Parameters.AddWithValue("@amt", txtamt.Text);
                
                cm.ExecuteNonQuery();
                cm.Dispose();

                savealert.Visible = true;
                con1.Close();


            }
            catch (MySqlException ex)
            {
                lblex.Text = ex.Message;
                wrningex.Visible = true;
            }
            txtboxclear();
            DataLoard();
            supidload();

        }
    }
}