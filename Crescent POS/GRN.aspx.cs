using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace Crescent_POS
{
    public partial class GRN : System.Web.UI.Page
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        MySqlConnection con = new MySqlConnection(connectionString);
        DataTable dt = new DataTable();
        MySqlCommand cmd = new MySqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (Session["user_name"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
            if (!IsPostBack)
            {
                if (ViewState["Details"] == null)
                {
                   

                    dt.Columns.Add("Product ID");
                    dt.Columns.Add("Barcode");
                    dt.Columns.Add("Brand");

                    dt.Columns.Add("Category");
                    dt.Columns.Add("Description");
                    dt.Columns.Add("Cost Price");

                    dt.Columns.Add("Qty");
                    dt.Columns.Add("Total Price");

                    dt.Columns.Add("Selling Price");
                    dt.Columns.Add("Grn ID");
                    ViewState["Details"] = dt;
                }
            }
            GRNIDLoard();
            Showdate();
            LoadSupplierID();
            PIDLoard();


        }
        protected void txtQty_TextChanged(object sender, EventArgs e)
        {
            decimal val1 = decimal.Parse(txtCostPrice.Text);
            decimal val2 = decimal.Parse(txtQty.Text);
            decimal sum = val1 * val2;
            txtTotalPrice.Text = sum.ToString("#,#00.00");
        }
        public void Showdate()
        {
            DateTime date = DateTime.Now;
            lblDate.Text = date.ToString("MM/dd/yyyy");
        }

        public void GRNIDLoard()
        {

            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand com = new MySqlCommand();

                com.Connection = conn;
                com.CommandText = "SELECT COUNT(*) from tblgrn";

                int result = int.Parse(com.ExecuteScalar().ToString());
                conn.Close();
                if (result == 0)
                {
                    lblGRNID.Text = "1";
                }
                else
                {
                    con.Open();
                    try
                    {
                        MySqlCommand command = new MySqlCommand("select max(grnID) from tblgrn", con);
                        string id = command.ExecuteScalar().ToString();
                        int uid = Convert.ToInt32(id);
                        int uuid = uid + 1;
                        lblGRNID.Text = uuid.ToString();
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
        public void PIDLoard()
        {

            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand com = new MySqlCommand();

                com.Connection = conn;
                com.CommandText = "SELECT COUNT(*) from grnproduct";

                int result = int.Parse(com.ExecuteScalar().ToString());
                conn.Close();
                if (result == 0)
                {
                    txtprdctid.Text = "1";
                }
                else
                {
                    MySqlConnection conn1 = new MySqlConnection(connectionString);
                    conn1.Open();
                    try
                    {
                        MySqlCommand command = new MySqlCommand("select max(productid) from grnproduct", conn1);
                        string id = command.ExecuteScalar().ToString();
                        int uid = Convert.ToInt32(id);
                        int uuid = uid + 1;
                        txtprdctid.Text = uuid.ToString();
                    }
                    catch (Exception)
                    {
                        return;
                    }
                    finally
                    {
                        conn1.Close();
                    }
                }

            }

            finally
            {

            }

        }
        public void hidealert()
        {
            warningalert.Visible = false;
            wrningdes.Visible = false;
            wrningtxtCostPrice.Visible = false;
            wrningtxtQty.Visible = false;
            wrningtxtTotalPrice.Visible = false;
            wrningbarcodedup.Visible = false;
            wrningamt.Visible = false;
            savealert.Visible = false;
            warningalert.Visible = false;
            updatealert.Visible = false;
            deletealert.Visible = false;
            wrningex.Visible = false;
        }
        public void txtboxclear()
        {
            txtbarcode.Text = "";
            txtdes.Text = "";
            txtCostPrice.Text = "";
            txtQty.Text = "";
            txtTotalPrice.Text = "";
            TextBox8.Text = "";
            txtBrand.Text = "";
            txtCategory.Text = "";

        }

        protected void addbtn_Click(object sender, EventArgs e)
        {
            hidealert();

            try
            {
                if (!string.IsNullOrWhiteSpace(this.txtbarcode.Text))

                {
                    DataTable dt = (DataTable)ViewState["Details"];
                    bool ifExist = false;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["Barcode"].ToString() == txtbarcode.Text.Trim())
                        {
                            ifExist = true;
                        }

                    }
                    if (!ifExist)
                    {
                    }
                    else
                    {
                        wrningbarcodedup.Visible = true;
                    }



                } 
                   

                if (txtbarcode.Text == "")
                {
                    warningalert.Visible = true;

                    return;
                }
                if (txtdes.Text == "")
                {
                    wrningdes.Visible = true;

                    return;
                }
                if (txtCostPrice.Text == "")
                {
                    wrningtxtCostPrice.Visible = true;

                    return;
                }
                if (txtQty.Text == "")
                {
                    wrningtxtQty.Visible = true;

                    return;
                }
                if (txtTotalPrice.Text == "")
                {
                    wrningtxtTotalPrice.Visible = true;

                    return;
                }
                if (TextBox8.Text == "")
                {
                    wrningamt.Visible = true;

                    return;
                }

                dt = (DataTable)ViewState["Details"];
                dt.Rows.Add(txtprdctid.Text, txtbarcode.Text,txtBrand.Text, txtCategory.Text, txtdes.Text, txtCostPrice.Text, txtQty.Text, txtTotalPrice.Text, TextBox8.Text, lblGRNID.Text);
                ViewState["Details"] = dt;
                prdctgv.DataSource = dt;
                prdctgv.EmptyDataText = "Product ID";
                prdctgv.EmptyDataText = "Barcode";
                prdctgv.EmptyDataText = "Brand";
                prdctgv.EmptyDataText = "Category";
                prdctgv.EmptyDataText = "Description";
                prdctgv.EmptyDataText = "Cost Price";
                prdctgv.EmptyDataText = "Qty";
                prdctgv.EmptyDataText = "Total Price";
                prdctgv.EmptyDataText = "Selling Price";
                prdctgv.EmptyDataText = "Grn ID";
                prdctgv.DataBind();

                int pid = int.Parse(txtprdctid.Text);
                int npid = pid + 1;
                txtprdctid.Text = npid.ToString();
                txtboxclear();
            }
            catch(Exception ex)
            {
                lblex.Text = ex.Message;
                wrningex.Visible = true;
            }
        }
        //protected void txtQty_TextChanged(object sender, EventArgs e)
        //{
        //    decimal val1 = decimal.Parse(txtCostPrice.Text);
        //    decimal val2 = decimal.Parse(txtQty.Text);
        //    decimal sum = val1 * val2;
        //    txtTotalPrice.Text = sum.ToString("#,#00.00");
        //}

        public void LoadSupplierID()
        {
            con.Open();

            MySqlCommand cmd = new MySqlCommand("select * from tblSupplier", con);
            // table name   
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  
            ddlSupplierID.DataTextField = ds.Tables[0].Columns["SupplierID"].ToString(); // text field name of table dispalyed in dropdown       
            ddlSupplierID.DataValueField = ds.Tables[0].Columns["SupplierID"].ToString();
            // to retrive specific  textfield name   
            ddlSupplierID.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            ddlSupplierID.DataBind();  //binding dropdownlist  
        }


        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] SearchBrand(string prefixText, int count)
        {
            string cs = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                string sql = String.Format("SELECT DISTINCT brand FROM grnproduct where brand like '{0}%'", prefixText);
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "grnproduct");
                int rcount, size;
                rcount = ds.Tables[0].Rows.Count;
                if (rcount >= count)
                    size = count;
                else
                    size = rcount;
                string[] pnames = new string[size];
                for (int i = 0; i < size; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    pnames[i] = row["brand"].ToString();
                }
                return pnames;
            }
        }


        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] SearchCategory(string prefixText, int count)
        {
            string cs = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                string sql = String.Format("SELECT DISTINCT category FROM grnproduct where category like '{0}%'", prefixText);
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "grnproduct");
                int rcount, size;
                rcount = ds.Tables[0].Rows.Count;
                if (rcount >= count)
                    size = count;
                else
                    size = rcount;
                string[] pnames = new string[size];
                for (int i = 0; i < size; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    pnames[i] = row["category"].ToString();
                }
                return pnames;
            }
        }

       
    }
}