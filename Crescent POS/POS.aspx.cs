using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace Crescent_POS
{
    public partial class POS : System.Web.UI.Page
    {
        public static string paymethod = "null";
        public static string connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        MySqlConnection con = new MySqlConnection(connectionString);
        MySqlDataReader rdr;
        MySqlCommand cmd;
        DataTable dt = new DataTable();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            Invoicenoload();
            Showdate();
            //ShowTime();
            inlineRadio1.Checked = true;

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

                    dt.Columns.Add("Stock ID");
                    dt.Columns.Add("Brand");
                    dt.Columns.Add("Description");
                    dt.Columns.Add("Selling Price");
                    dt.Columns.Add("Qty");
                    dt.Columns.Add("Total Price");
                    ViewState["Details"] = dt;
                }
            }

        }

        public void Showdate()
        {
            DateTime date = DateTime.Now;
            lblDate.Text = date.ToString("MM/dd/yyyy");
        }

        public void Invoicenoload()
        {

            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand com = new MySqlCommand();

                com.Connection = conn;
                com.CommandText = "SELECT COUNT(*) from tblcart";

                int result = int.Parse(com.ExecuteScalar().ToString());
                conn.Close();
                if (result == 0)
                {
                    txtinvoiceno.Text = "1";
                }
                else
                {
                    MySqlConnection con1 = new MySqlConnection(connectionString);
                    con1.Open();
                    try
                    {
                        MySqlCommand command = new MySqlCommand("select max(Invoiceno) from tblcart", con1);
                        string id = command.ExecuteScalar().ToString();
                        int uid = Convert.ToInt32(id);
                        int uuid = uid + 1;
                        txtinvoiceno.Text = uuid.ToString();
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

        public void ShowTime()
        {
            DateTime time = DateTime.Now;
        }

        protected void txtqty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT stockid,brand,description,sellingprice from tblstock where barcode = '" + txtBarCodeSearch.Text + "' ";
                DataTable tempdt = new DataTable();
                MySqlConnection sqlConn = new MySqlConnection(connectionString);
                sqlConn.Open();
                MySqlCommand cmd = new MySqlCommand(query, sqlConn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(tempdt);
                sqlConn.Close();

                int pid = Convert.ToInt32(tempdt.Rows[0]["stockid"]);
                string brand = tempdt.Rows[0]["brand"].ToString();
                string des = tempdt.Rows[0]["description"].ToString();
                decimal sp = Convert.ToDecimal(tempdt.Rows[0]["sellingprice"]);
                int qty = Convert.ToInt32(txtqty.Text);
                decimal tot = qty * sp;

                dt = (DataTable)ViewState["Details"];
                dt.Rows.Add(pid, brand, des, sp, qty, tot);
                ViewState["Details"] = dt;
                gvbillitem.DataSource = dt;
                gvbillitem.EmptyDataText = "Stock ID";
                gvbillitem.EmptyDataText = "Brand";
                gvbillitem.EmptyDataText = "Description";
                gvbillitem.EmptyDataText = "Selling Price";
                gvbillitem.EmptyDataText = "Qty";
                gvbillitem.EmptyDataText = "Total Price";
                gvbillitem.DataBind();


                int sum = 0;
                for (int i = 0; i < gvbillitem.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(gvbillitem.Rows[i].Cells[6].Text);
                }
                txtAmount.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                lblex.Text = ex.Message;
                wrningex.Visible = true;
            }
            txtqty.Visible = false;
            txtqty.Text = "";
            txtBarCodeSearch.Text = "";

        }
        protected void txtBarCodeSearch_TextChanged(object sender, EventArgs e)
        {
            txtqty.Visible = true;
            txtqty.Focus();
        }

        protected void txtPhoneSearch_TextChanged(object sender, EventArgs e)
        {
            txtCustomerName.Text = "";
            txtCustomerID.Text = "";
            if (txtPhoneSearch.Text == null)
            {
                // MessageBox.Show("Search failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    //SqlConnection conn = new SqlConnection(connection_string);
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT Cusid,customerName,amt from tblcustomer where mobile = '" + txtPhoneSearch.Text + "' ", con);
                    MySqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            txtCustomerName.Text = (dr["customerName"].ToString());
                            txtCustomerID.Text = (dr["Cusid"].ToString());
                            txtPreReceivable.Text = (dr["amt"].ToString());
                            rdLoyalty.Checked = true;
                            //MessageBox.Show("Search Completed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        }
                    }
                    else
                    {

                        txtPhoneSearch.Text = "";
                        //MessageBox.Show("Customer not registered", "No Search Matching", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        rdGuest.Checked = true;
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    lblex.Text = ex.Message;
                    wrningex.Visible = true;
                }

            }
        }
        public void gridclear()
        {
            gvbillitem.DataSource = null;
            gvbillitem.DataBind();
        }
        protected void gvbillitem_RowDeleting(object sender, GridViewDeleteEventArgs e)
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
                    gvbillitem.DataSource = dt;
                    gvbillitem.DataBind();
                }
            }
        }
        protected void ddlDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal amount = decimal.Parse(txtAmount.Text);
            decimal discount = decimal.Parse(ddlDiscount.Text);
            decimal sum = ((100 - discount) * amount) / 100;
            txtTotalAmount.Text = sum.ToString();
        }

        protected void txtRAmount_TextChanged(object sender, EventArgs e)
        {
            decimal total = decimal.Parse(txtTotalAmount.Text);
            decimal ramount = decimal.Parse(txtRAmount.Text);
            decimal sum = ramount - total;
            txtBalance.Text = sum.ToString();
        }
        protected void btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (inlineRadio1.Checked == true)
                {
                    paymethod = "Cash";
                }
                else if (inlineRadio2.Checked == true)
                { paymethod = "Card"; }
                else if (inlineRadio3.Checked == true)
                { paymethod = "Cheque"; }

                //insert data to billtble
                for (int i = 0; i <= gvbillitem.Rows.Count - 1; i++)
                {
                    MySqlConnection con2 = new MySqlConnection(connectionString);
                    string sts = "temp";
                    string cd = "Insert into tblcart (Invoiceno,pid,brand,description,sellingprice,qty,total,sdate,status,billtotal,Amount,Discount,RAmount,Balance,paymethod)  values(@Invoiceno,@pid,@brand,@description,@sellingprice,@qty,@total,@sdate,@status,@billtotal,@Amount,@Discount,@RAmount,@Balance,@paymethod)";
                    MySqlCommand cmd = new MySqlCommand(cd);
                    cmd.Connection = con2;

                    cmd.Parameters.AddWithValue("Invoiceno", txtinvoiceno.Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("pid", gvbillitem.Rows[i].Cells[1].Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("brand", gvbillitem.Rows[i].Cells[2].Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("description", gvbillitem.Rows[i].Cells[3].Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("sellingprice", gvbillitem.Rows[i].Cells[4].Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("qty", gvbillitem.Rows[i].Cells[5].Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("total", gvbillitem.Rows[i].Cells[6].Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("sdate", Convert.ToDateTime(lblDate.Text, System.Globalization.CultureInfo.CurrentCulture));
                    cmd.Parameters.AddWithValue("status", sts.ToString().Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("billtotal", txtTotalAmount.Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("Amount", txtAmount.Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("Discount", ddlDiscount.Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("RAmount", txtRAmount.Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("Balance", txtBalance.Text.Replace("&nbsp;", ""));
                    cmd.Parameters.AddWithValue("paymethod", paymethod.ToString().Replace("&nbsp;", ""));


                    con2.Open();
                    cmd.ExecuteNonQuery();
                    con2.Close();
                   

                   
                }
                   
                //stock deduction
                for (int q = 0; q <= gvbillitem.Rows.Count - 1; q++)
                {
                    MySqlConnection conn3 = new MySqlConnection(connectionString);
                    string upcd = " UPDATE tblstock SET qty=qty-@newqty WHERE stockid = @stockid";
                    MySqlCommand cmd1 = new MySqlCommand(upcd);
                    cmd1.Connection = conn3;

                    cmd1.Parameters.AddWithValue("stockid", gvbillitem.Rows[q].Cells[1].Text);
                    cmd1.Parameters.AddWithValue("newqty", gvbillitem.Rows[q].Cells[5].Text);

                    conn3.Open();
                    cmd1.ExecuteNonQuery();
                    conn3.Close();
                }
                savealert.Visible = true;
            }
            catch (Exception ex)
            {
                lblex.Text = ex.Message;
                wrningex.Visible = true;
            }
            PritBill();
            gridclear();
        }

        public void PritBill()
        {
            rptBill rpt = new rptBill();
            cmd = new MySqlCommand();
            DataSet ds = new DataSet();
            con = new MySqlConnection(connectionString);
            con.Open();
            cmd = new MySqlCommand("select * from tblcart where Invoiceno ='" + txtinvoiceno.Text + "'", con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(ds);
            ds.Tables[0].TableName = "tblCart";
            rpt.SetDataSource(ds);
            System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
            rpt.PrintOptions.PrinterName = printDocument.PrinterSettings.PrinterName;
            rpt.PrintToPrinter(1, true, 0, 0);
           // Cursor = Cursors.Default;
        }
    }

}