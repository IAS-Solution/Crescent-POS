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
            LoadSupplierID();

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

          
            DataLoardgrn();


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
                    MySqlConnection con1 = new MySqlConnection(connectionString);
                    con1.Open();
                    try
                    {
                        MySqlCommand command = new MySqlCommand("select max(grnID) from tblgrn", con1);
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
                        con1.Close();
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
            savealert1.Visible = false;
            savealert2.Visible = false;
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
        public void gridclear()
        {
            prdctgv.DataSource = null;
            prdctgv.DataBind();
        }
        protected void clear_Click(object sender, EventArgs e)
        {
            gridclear();
        }
            protected void addbtn_Click(object sender, EventArgs e)
        {
            gvprdctdiv1.Visible = true;
            gvprdctdiv.Visible = true;
            hidealert();

            try
            {


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

                if (TextBox8.Text == "")
                {
                    wrningamt.Visible = true;

                    return;
                }
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
                        int val1 = Convert.ToInt32(txtCostPrice.Text);
                        int val2 = Convert.ToInt32(txtQty.Text);
                        int tot = val1 * val2;
                        dt = (DataTable)ViewState["Details"];
                        dt.Rows.Add(txtbarcode.Text, txtBrand.Text, txtCategory.Text, txtdes.Text, txtCostPrice.Text, txtQty.Text, tot, TextBox8.Text, lblGRNID.Text);
                        ViewState["Details"] = dt;
                        prdctgv.DataSource = dt;
                       
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

                        
                        txtboxclear();
                    }
                    else
                    {
                        wrningbarcodedup.Visible = true;
                    }



                }



            }
            catch (Exception ex)
            {
                lblex.Text = ex.Message;
                wrningex.Visible = true;
            }
        }
        protected void prdctgv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (ViewState["Details"] != null)
            {
                DataTable dt = (DataTable)ViewState["Details"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 0)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["Details"] = dt;
                    prdctgv.DataSource = dt;
                    prdctgv.DataBind();
                }
            }
        }
        protected void savebtn_Click(object sender, EventArgs e)
        {
            hidealert();

            try
            {

                //////data insert grntbl
                MySqlConnection con1 = new MySqlConnection(connectionString);
                con1.Open();
                MySqlCommand cm = new MySqlCommand("Insert into tblgrn (GRNID,Date,Company,refname)  values(@grnid,@date,@comname,@repname)", con1);

                cm.Parameters.AddWithValue("@grnid", lblGRNID.Text);
                cm.Parameters.AddWithValue("@date", Convert.ToDateTime(lblDate.Text, System.Globalization.CultureInfo.CurrentCulture));
                cm.Parameters.AddWithValue("@comname", ddlSupplierID.Text);
                cm.Parameters.AddWithValue("@repname", ddlUserLevel.Text);


                cm.ExecuteNonQuery();
                cm.Dispose();

                savealert.Visible = true;
                con1.Close();

                //data insert prdcttbl

                for (int i = 0; i <= prdctgv.Rows.Count - 1; i++)
                {
                    MySqlConnection con2 = new MySqlConnection(connectionString);

                    string cd = "Insert into grnproduct (description,barcode,brand,category,costprice,sellingprice,qty,totalprice,grnid)  values(@description,@barcode,@brand,@category,@costprice,@sellingprice,@qty,@totalprice,@grnid)";
                    cmd = new MySqlCommand(cd);
                    cmd.Connection = con2;

                    
                    cmd.Parameters.AddWithValue("description", prdctgv.Rows[i].Cells[4].Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("barcode", prdctgv.Rows[i].Cells[1].Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("brand", prdctgv.Rows[i].Cells[2].Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("category", prdctgv.Rows[i].Cells[3].Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("costprice", prdctgv.Rows[i].Cells[5].Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("sellingprice", prdctgv.Rows[i].Cells[8].Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("qty", prdctgv.Rows[i].Cells[6].Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("totalprice", prdctgv.Rows[i].Cells[7].Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("grnid", prdctgv.Rows[i].Cells[9].Text.Replace("&nbsp;", ""));

                    con2.Open();
                    cmd.ExecuteNonQuery();
                    con2.Close();
                    savealert1.Visible = true;



                }

                //insert tbl stock

                for (int q = 0; q <= prdctgv.Rows.Count - 1; q++)
                {
                    MySqlConnection conn = new MySqlConnection(connectionString);
                    conn.Open();
                    MySqlCommand com = new MySqlCommand();

                    com.Connection = conn;
                    com.CommandText = "SELECT COUNT(*) from tblstock";

                    int result = int.Parse(com.ExecuteScalar().ToString());
                    conn.Close();
                    if (result == 0)
                    {
                        MySqlConnection con33 = new MySqlConnection(connectionString);

                        string cd = "Insert into tblstock (description,barcode,brand,category,costprice,sellingprice,qty)  values(@productid,@description,@barcode,@brand,@category,@costprice,@sellingprice,@qty)";
                        MySqlCommand cmdd = new MySqlCommand(cd);
                        cmdd.Connection = con33;


                        cmdd.Parameters.AddWithValue("description", prdctgv.Rows[q].Cells[4].Text.Replace("&nbsp;", ""));
                        cmdd.Parameters.AddWithValue("barcode", prdctgv.Rows[q].Cells[1].Text.Replace("&nbsp;", ""));
                        cmdd.Parameters.AddWithValue("brand", prdctgv.Rows[q].Cells[2].Text.Replace("&nbsp;", ""));
                        cmdd.Parameters.AddWithValue("category", prdctgv.Rows[q].Cells[3].Text.Replace("&nbsp;", ""));
                        cmdd.Parameters.AddWithValue("costprice", prdctgv.Rows[q].Cells[5].Text.Replace("&nbsp;", ""));
                        cmdd.Parameters.AddWithValue("sellingprice", prdctgv.Rows[q].Cells[8].Text.Replace("&nbsp;", ""));
                        cmdd.Parameters.AddWithValue("qty", prdctgv.Rows[q].Cells[6].Text.Replace("&nbsp;", ""));


                        con33.Open();
                        cmdd.ExecuteNonQuery();
                        con33.Close();
                    }
                    MySqlConnection newcon = new MySqlConnection(connectionString);
                    DataTable dt = new DataTable();
                    try
                    {
                        newcon.Open();


                        String sql = "Select * from tblstock where barcode= @barcode";
                        MySqlCommand newcmd = new MySqlCommand(sql, newcon);
                        newcmd.Parameters.AddWithValue("@barcode", prdctgv.Rows[q].Cells[1].Text);
                        MySqlDataAdapter ad = new MySqlDataAdapter(newcmd);
                        ad.Fill(dt);


                        if (dt.Rows.Count > 0)
                        {

                            // Update code 
                            MySqlConnection con99 = new MySqlConnection(connectionString);
                            string upcd = " UPDATE tblstock SET qty=qty+@newqty WHERE barcode = @barcode";
                            MySqlCommand cmd99 = new MySqlCommand(upcd);
                            cmd99.Connection = con99;

                            cmd99.Parameters.AddWithValue("barcode", prdctgv.Rows[q].Cells[1].Text);
                            cmd99.Parameters.AddWithValue("newqty", prdctgv.Rows[q].Cells[6].Text);

                            con99.Open();
                            cmd99.ExecuteNonQuery();
                            con99.Close();
                        }
                        else
                        {

                            // INSERT codes 
                            MySqlConnection con3 = new MySqlConnection(connectionString);

                            string cd = "Insert into tblstock (description,barcode,brand,category,costprice,sellingprice,qty)  values(@description,@barcode,@brand,@category,@costprice,@sellingprice,@qty)";
                            MySqlCommand cmddd = new MySqlCommand(cd);
                            cmddd.Connection = con3;


                            cmddd.Parameters.AddWithValue("description", prdctgv.Rows[q].Cells[4].Text.Replace("&nbsp;", ""));
                            cmddd.Parameters.AddWithValue("barcode", prdctgv.Rows[q].Cells[1].Text.Replace("&nbsp;", ""));
                            cmddd.Parameters.AddWithValue("brand", prdctgv.Rows[q].Cells[2].Text.Replace("&nbsp;", ""));
                            cmddd.Parameters.AddWithValue("category", prdctgv.Rows[q].Cells[3].Text.Replace("&nbsp;", ""));
                            cmddd.Parameters.AddWithValue("costprice", prdctgv.Rows[q].Cells[5].Text.Replace("&nbsp;", ""));
                            cmddd.Parameters.AddWithValue("sellingprice", prdctgv.Rows[q].Cells[8].Text.Replace("&nbsp;", ""));
                            cmddd.Parameters.AddWithValue("qty", prdctgv.Rows[q].Cells[6].Text.Replace("&nbsp;", ""));


                            con3.Open();
                            cmddd.ExecuteNonQuery();
                            con3.Close();
                        }
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        lblex.Text = ex.Message;
                        wrningex.Visible = true;


                    }
                    finally
                    {
                        newcon.Close();
                    }
                    

                }
                savealert2.Visible = true;
                DataLoardgrn();
                
                gvprdctdiv1.Visible = false;
                gvprdctdiv.Visible = false;
            }

            catch (Exception ex)
            {
                lblex.Text = ex.Message;
                wrningex.Visible = true;
            }
            gridclear();

        }
       
        public void LoadSupplierID()
        {

            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("select * from tblcompany", con);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddlSupplierID.DataSource = dt;
            ddlSupplierID.DataBind();


            
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

        protected void ddlSupplierID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
        public void DataLoardgrn()
        {
            con.Close();
            string cmd = "select * from tblgrn";
            MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd, con);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            myAdapter.Fill(ds);
            dt = ds.Tables[0];

            //Bind the fetched data to gridview
            gvgrn.DataSource = dt;
            gvgrn.DataBind();

            
        }
        protected void ddlSupplierID_TextChanged(object sender, EventArgs e)
        {

            //ddlUserLevel.Items.Clear();
            //ddlUserLevel.Items.Add("Select State");

            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT * from tblsupplier where cid=" + ddlSupplierID.SelectedItem.Value, con);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddlUserLevel.DataSource = dt;
            ddlUserLevel.DataBind();

           
        }
    }

}