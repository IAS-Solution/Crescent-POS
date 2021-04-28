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
        MySqlCommand cmd;
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
            cidload();
            DataLoard();
        }

        public void cidload()
        {
            
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand com = new MySqlCommand();
              
                com.Connection = conn;
                com.CommandText = "SELECT COUNT(*) from tblcompany";

                int result = int.Parse(com.ExecuteScalar().ToString());
                conn.Close();
                if (result == 0)
                {
                    txtcid.Text = "1";
                }
                else
                {
                    con.Open();
                    try
                    {
                        MySqlCommand command = new MySqlCommand("select max(id) from tblcompany", con);
                        string id = command.ExecuteScalar().ToString();
                        int uid = Convert.ToInt32(id);
                        int uuid = uid + 1;
                        txtcid.Text = uuid.ToString();
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
            txtcname.Text = "";
            //txtrepphone.Text = "";
            txtcaddress.Text = "";
            txtcphone.Text = "";
            txtcemail.Text = "";
            //txtrepname.Text = "";
            //txtamt.Text = "";
            //ddlcreditperiod.SelectedIndex = 0;

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
            string cmd = "select id,cName,cAddress,cemail,cnumber from tblcompany";
            MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd, con);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            myAdapter.Fill(ds);
            dt = ds.Tables[0];

            //Bind the fetched data to gridview
            gvcompany.DataSource = dt;
            gvcompany.DataBind();

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //if (cbCredi.Checked == false)
            //{
            //    txtamt.Text = "0.00";
            //    ddlcreditperiod.SelectedIndex = 0;
            //}
            hidealert();

            try
            {
                if (txtcname.Text == "")
                {
                    wrningfullname.Visible = true;

                    return;
                }
                 if (txtcaddress.Text == "")
                {
                    wrningaddress.Visible = true;

                    return;
                }
                // if (txtrepphone.Text == "")
                //{
                //    wrningrepphone.Visible = true;

                //    return;
                //}
                 if (txtcphone.Text == "")
                {
                    wrningphone.Visible = true;

                    return;
                }
                 if (txtcemail.Text == "")
                {
                    wrningemail.Visible = true;

                    return;
                }
                // if (txtrepname.Text == "")
                //{
                //    wrningrepname.Visible = true;

                //    return;
                //}
                // if (cbCredi.Checked==true)
                //{
                //     if (txtamt.Text == "")
                //    {
                //        wrningamt.Visible = true;

                //        return;
                //    }
                //}
                

                 
                    //data insert company
                    MySqlConnection con = new MySqlConnection(connectionString);
                    con.Open();
                    MySqlCommand cm = new MySqlCommand("Insert into tblcompany(id,cName,cAddress,cemail,cnumber)  values(@id,@cName,@cAddress,@cemail,@cnumber)", con);

                    cm.Parameters.AddWithValue("@id", txtcid.Text);
                    cm.Parameters.AddWithValue("@cName", txtcname.Text);
                    cm.Parameters.AddWithValue("@cAddress", txtcaddress.Text);
                    cm.Parameters.AddWithValue("@cemail", txtcemail.Text);
                    cm.Parameters.AddWithValue("@cnumber", txtcphone.Text);
                    //cm.Parameters.AddWithValue("@RepName", txtrepname.Text);
                    //cm.Parameters.AddWithValue("@RepPhonenum", txtrepphone.Text);
                    //cm.Parameters.AddWithValue("@Creditamt", txtamt.Text);
                    //cm.Parameters.AddWithValue("@Creditperiod", ddlcreditperiod.Text);

                    cm.ExecuteNonQuery();
                    cm.Dispose();

                    savealert.Visible = true;
                    con.Close();
                
                
            }
            catch (Exception ex)
            {
                lblex.Text = ex.Message;
                wrningex.Visible = true;
            }
            txtboxclear();
            DataLoard();
            cidload();

        }
        //protected void cbCredit_ServerChange(object sender, EventArgs e)
        //{
        //    pnl1.Visible = true;
        //}

        //protected void cbCredi_CheckedChanged(object sender, EventArgs e)
        //{
        //    pnl1.Visible = cbCredi.Checked;
        //}
   
        protected void gvcompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            sidload();
            txtcid.Text = gvcompany.SelectedRow.Cells[1].Text;
            txtcname.Text = gvcompany.SelectedRow.Cells[2].Text;
            txtcaddress.Text = gvcompany.SelectedRow.Cells[3].Text;
            txtcemail.Text = gvcompany.SelectedRow.Cells[4].Text;
            txtcphone.Text = gvcompany.SelectedRow.Cells[5].Text;

            txtsname.ReadOnly = false;
            txtsphone.ReadOnly = false;
            cbCredit.Enabled = true;
        }

        protected void cbCredit_CheckedChanged(object sender, EventArgs e)
        {
            pnl1.Visible = cbCredit.Checked;
        }

        public void sidload()
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
                    txtsid.Text = "1";
                }
                else
                {
                    con.Open();
                    try
                    {
                        MySqlCommand command = new MySqlCommand("select max(id) from tblsupplier", con);
                        string id = command.ExecuteScalar().ToString();
                        int uid = Convert.ToInt32(id);
                        int uuid = uid + 1;
                        txtsid.Text = uuid.ToString();
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

        protected void btn_Click(object sender, EventArgs e)
        {
            
            
                    try
                    {
                        con = new MySqlConnection(connectionString);

                        string cd = "insert Into tblsupplier(id,cid,repname,repphonenum,creditamt,creditperiod) VALUES (@id,@cid,@repname,@repphonenum,@creditamt,@creditperiod)";
                        cmd = new MySqlCommand(cd);
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@id", txtsid.Text);
                        cmd.Parameters.AddWithValue("@cid", txtcid.Text);
                        cmd.Parameters.AddWithValue("@repname", txtsname.Text);
                        cmd.Parameters.AddWithValue("@repphonenum", txtsphone.Text);
                        cmd.Parameters.AddWithValue("@creditamt", txtcamount.Text);
                        cmd.Parameters.AddWithValue("@creditperiod", ddlcperiod.SelectedItem.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        //getmealsupplement();
                        //clear_meal_form();
                    }
                    catch (Exception ex)
                    {
                lblex.Text = ex.Message;
                wrningex.Visible = true;
            }
            sidload();
                



                //else
                //{
                //    BindGrid_meal(1);
                //    clear_meal_form();
                //}

            
        }

        public void getmealsupplement()
        {
            try
            {
                string message = string.Empty;
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    if (conn != null && string.IsNullOrEmpty(message))
                    {
                        string cmd = "select id,Person,Meal,Charge from HotelHeader, Hotel_meal where HotelHeader.HID = Hotel_meal.HID and HotelHeader.HID = '" + txtcid.Text + "'";
                        MySqlDataAdapter dAdapter = new MySqlDataAdapter(cmd, conn);
                        DataTable dt = new DataTable();
                        DataSet ds = new DataSet();
                        dAdapter.Fill(ds);
                        dt = ds.Tables[0];
                        //Bind the fetched data to gridview
                        gvsupp.DataSource = dt;
                        gvsupp.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {

                lblex.Text = ex.Message;
                wrningex.Visible = true;
            }
        }
    

        //public void getmealsupplement()
        //{
        //    try
        //    {
        //        string message = string.Empty;
        //        using (SqlConnection conn = new SqlConnection(cs))
        //        {
        //            if (conn != null && string.IsNullOrEmpty(message))
        //            {
        //                string cmd = "select id,Person,Meal,Charge from HotelHeader, Hotel_meal where HotelHeader.HID = Hotel_meal.HID and HotelHeader.HID = '" + txtID.Text + "'";
        //                SqlDataAdapter dAdapter = new SqlDataAdapter(cmd, conn);
        //                DataTable dt = new DataTable();
        //                DataSet ds = new DataSet();
        //                dAdapter.Fill(ds);
        //                dt = ds.Tables[0];
        //                //Bind the fetched data to gridview
        //                gv_meal_sup.DataSource = dt;
        //                gv_meal_sup.DataBind();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
    }
}