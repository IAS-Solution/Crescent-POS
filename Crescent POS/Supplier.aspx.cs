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
    public partial class Supplier : System.Web.UI.Page
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
                com.CommandText = "SELECT COUNT(*) from tblsupplier";

                int result = int.Parse(com.ExecuteScalar().ToString());
                conn.Close();
                if (result == 0)
                {
                    txtsupid.Text = "1";
                }
                else
                {
                    con.Open();
                    try
                    {
                        MySqlCommand command = new MySqlCommand("select max(SupplierID) from tblsupplier", con);
                        string id = command.ExecuteScalar().ToString();
                        int uid = Convert.ToInt32(id);
                        int uuid = uid + 1;
                        txtsupid.Text = uuid.ToString();
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
            txtrepphone.Text = "";
            txtaddress.Text = "";
            txtphone.Text = "";
            txtemail.Text = "";
            txtrepname.Text = "";
            txtamt.Text = "";
            ddlcreditperiod.SelectedIndex = 0;

        }
        public void hidealert()
        {
            wrningfullname.Visible = false;
            wrningaddress.Visible = false;
            wrningrepphone.Visible = false;
            wrningphone.Visible = false;
            wrningemail.Visible = false;
            wrningrepname.Visible = false;
            wrningamt.Visible = false;
            savealert.Visible = false;
            warningalert.Visible = false;
            updatealert.Visible = false;
            deletealert.Visible = false;
        }
        public void DataLoard()
        {
            con.Close();
            string cmd = "select SupplierName,MobileNumber,Email,Address,RepName,RepPhonenum,Creditamt,Creditperiod from tblsupplier";
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
            if (cbCredi.Checked == false)
            {
                txtamt.Text = "0.00";
                ddlcreditperiod.SelectedIndex = 0;
            }
            hidealert();

            try
            {
                if (txtFullName.Text == "")
                {
                    wrningfullname.Visible = true;

                    return;
                }
                 if (txtaddress.Text == "")
                {
                    wrningaddress.Visible = true;

                    return;
                }
                 if (txtrepphone.Text == "")
                {
                    wrningrepphone.Visible = true;

                    return;
                }
                 if (txtphone.Text == "")
                {
                    wrningphone.Visible = true;

                    return;
                }
                 if (txtemail.Text == "")
                {
                    wrningemail.Visible = true;

                    return;
                }
                 if (txtrepname.Text == "")
                {
                    wrningrepname.Visible = true;

                    return;
                }
                 if (cbCredi.Checked==true)
                {
                     if (txtamt.Text == "")
                    {
                        wrningamt.Visible = true;

                        return;
                    }
                }
                

                 
                    //data insert
                    MySqlConnection con1 = new MySqlConnection(connectionString);
                    con1.Open();
                    MySqlCommand cm = new MySqlCommand("Insert into tblsupplier (SupplierID,SupplierName,MobileNumber,Email,Address,RepName,RepPhonenum,Creditamt,Creditperiod )  values(@SupplierID,@SupplierName,@MobileNumber,@Email,@Address,@RepName,@RepPhonenum,@Creditamt,@Creditperiod)", con1);

                    cm.Parameters.AddWithValue("@SupplierID", txtsupid.Text);
                    cm.Parameters.AddWithValue("@SupplierName", txtFullName.Text);
                    cm.Parameters.AddWithValue("@MobileNumber", txtphone.Text);
                    cm.Parameters.AddWithValue("@Email", txtemail.Text);
                    cm.Parameters.AddWithValue("@Address", txtaddress.Text);
                    cm.Parameters.AddWithValue("@RepName", txtrepname.Text);
                    cm.Parameters.AddWithValue("@RepPhonenum", txtrepphone.Text);
                    cm.Parameters.AddWithValue("@Creditamt", txtamt.Text);
                    cm.Parameters.AddWithValue("@Creditperiod", ddlcreditperiod.Text);

                    cm.ExecuteNonQuery();
                    cm.Dispose();

                    savealert.Visible = true;
                    con1.Close();
                
                
            }
            catch (MySqlException ex)
            {
                Response.Write("<script>alert(" + ex + ")</script>");
            }
            txtboxclear();
            DataLoard();
            supidload();

        }
        protected void cbCredit_ServerChange(object sender, EventArgs e)
        {
            //pnl1.Visible = true;
        }

        protected void cbCredi_CheckedChanged(object sender, EventArgs e)
        {
            pnl1.Visible = cbCredi.Checked;
        }
    }
}