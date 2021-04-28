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

            PIDLoard();
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
                    catch (Exception ex)
                    {
                        lblex.Text = ex.Message;
                        wrningex.Visible = true;
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
                        dt.Rows.Add(txtprdctid.Text, txtbarcode.Text, txtBrand.Text, txtCategory.Text, txtdes.Text, txtCostPrice.Text, txtQty.Text, tot, TextBox8.Text, lblGRNID.Text);
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

                    string cd = "Insert into grnproduct (productid,description,barcode,brand,category,costprice,sellingprice,qty,totalprice,grnid)  values(@productid,@description,@barcode,@brand,@category,@costprice,@sellingprice,@qty,@totalprice,@grnid)";
                    cmd = new MySqlCommand(cd);
                    cmd.Connection = con2;

                    cmd.Parameters.AddWithValue("productid", prdctgv.Rows[i].Cells[1].Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("description", prdctgv.Rows[i].Cells[5].Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("barcode", prdctgv.Rows[i].Cells[2].Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("brand", prdctgv.Rows[i].Cells[3].Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("category", prdctgv.Rows[i].Cells[4].Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("costprice", prdctgv.Rows[i].Cells[6].Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("sellingprice", prdctgv.Rows[i].Cells[9].Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("qty", prdctgv.Rows[i].Cells[7].Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("totalprice", prdctgv.Rows[i].Cells[8].Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("grnid", prdctgv.Rows[i].Cells[10].Text.Replace("&nbsp;", ""));

                    con2.Open();
                    cmd.ExecuteNonQuery();
                    con2.Close();
                    savealert1.Visible = true;



                }

                //insert tbl stock

                for (int q = 0; q <= prdctgv.Rows.Count - 1; q++)
                {
                    MySqlConnection conn3 = new MySqlConnection(connectionString);

                    MySqlCommand cmd = new MySqlCommand("Select * from tblstock where productid= @productid", conn3);
                    cmd.Parameters.AddWithValue("@productid", prdctgv.Rows[q].Cells[1].Text);
                    conn3.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();
                    conn3.Close();
                    while (dr.Read())
                    {
                        if (dr.HasRows == true)
                        {
                            MySqlConnection con33 = new MySqlConnection(connectionString);
                            string upcd = " UPDATE tblstock SET qty=qty+@newqty WHERE productid = @productid";
                            MySqlCommand cmd1 = new MySqlCommand(upcd);
                            cmd1.Connection = con33;

                            cmd1.Parameters.AddWithValue("productid", prdctgv.Rows[q].Cells[1].Text);
                            cmd1.Parameters.AddWithValue("newqty", prdctgv.Rows[q].Cells[5].Text);

                            con33.Open();
                            cmd1.ExecuteNonQuery();
                            con33.Close();
                        }
                        else
                        {
                           
                                MySqlConnection con3 = new MySqlConnection(connectionString);

                                string cd = "Insert into tblstock (productid,description,barcode,brand,category,costprice,sellingprice,qty)  values(@productid,@description,@barcode,@brand,@category,@costprice,@sellingprice,@qty)";
                                cmd = new MySqlCommand(cd);
                                cmd.Connection = con3;

                                cmd.Parameters.AddWithValue("productid", prdctgv.Rows[q].Cells[1].Text.Replace("&nbsp;", ""));
                                cmd.Parameters.AddWithValue("description", prdctgv.Rows[q].Cells[5].Text.Replace("&nbsp;", ""));
                                cmd.Parameters.AddWithValue("barcode", prdctgv.Rows[q].Cells[2].Text.Replace("&nbsp;", ""));
                                cmd.Parameters.AddWithValue("brand", prdctgv.Rows[q].Cells[3].Text.Replace("&nbsp;", ""));
                                cmd.Parameters.AddWithValue("category", prdctgv.Rows[q].Cells[4].Text.Replace("&nbsp;", ""));
                                cmd.Parameters.AddWithValue("costprice", prdctgv.Rows[q].Cells[6].Text.Replace("&nbsp;", ""));
                                cmd.Parameters.AddWithValue("sellingprice", prdctgv.Rows[q].Cells[9].Text.Replace("&nbsp;", ""));
                                cmd.Parameters.AddWithValue("qty", prdctgv.Rows[q].Cells[7].Text.Replace("&nbsp;", ""));


                                con3.Open();
                                cmd.ExecuteNonQuery();
                                con3.Close();
                               

                            
                        }
                    }
                    
   
                }
                savealert2.Visible = true;
                DataLoardgrn();
                prdctgv.DataSource = null;
                prdctgv.DataBind();
                gvprdctdiv1.Visible = false;
                gvprdctdiv.Visible = false;
            }

            catch (Exception ex)
            {
                lblex.Text = ex.Message;
                wrningex.Visible = true;
            }
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


            //SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");
            //con.Open();
            //MySqlCommand cmd = new MySqlCommand("select * from tblcompany", con);
            //MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //ddlSupplierID.DataSource = dt;
            //ddlSupplierID.DataBind();



            //con.Open();

            //MySqlCommand cmd = new MySqlCommand("select DISTINCT suppliername  from tblSupplier", con);
            // table name   
            //MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);  // fill dataset  
            //ddlSupplierID.DataTextField = ds.Tables[0].Columns["SupplierName"].ToString();     
            //ddlSupplierID.DataValueField = ds.Tables[0].Columns[""].ToString();
            // to retrive specific  textfield name   
            //ddlSupplierID.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            //ddlSupplierID.DataBind();  //binding dropdownlist  
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

            //con.Open();
            //MySqlCommand cmd = new MySqlCommand("SELECT * from tblsupplier where cid=" + ddlSupplierID.SelectedItem.Value, con);
            //MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //ddlUserLevel.DataSource = dt;
            //ddlUserLevel.DataBind();

            // ddlUserLevel.Items.Clear();
            // ddlUserLevel.Items.Add("repname");
            //con.Open();
            //SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");
            //MySqlCommand cmd = new MySqlCommand("SELECT * from tblsupplier where cid=" + ddlSupplierID.SelectedItem.Value, con);
            //MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //ddlUserLevel.DataSource = dt;
            //ddlUserLevel.DataBind();

            //con.Open();
            //MySqlCommand cmd = new MySqlCommand("SELECT repname from tblsupplier WHERE suppliername='" + ddlSupplierID.Text + "'", con);
            //MySqlDataReader dr = cmd.ExecuteReader();

            //if (dr.HasRows)
            //{
            //while (dr.Read())
            //{

            //    ddlUserLevel.SelectedValue = (dr["repname"].ToString());
            //txtCustomerID.Text = (dr["Cusid"].ToString());
            //txtPreReceivable.Text = (dr["amt"].ToString());
            //rdLoyalty.Checked = true;
            //MessageBox.Show("Search Completed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            //}
            //}
        }
    }

}