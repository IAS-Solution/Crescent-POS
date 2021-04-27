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

        public static string connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        MySqlConnection con = new MySqlConnection(connectionString);
        MySqlDataReader rdr;
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            Showdate();
            //ShowTime();
        
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

        public void ShowTime()
        {
            DateTime time = DateTime.Now;
        }

        protected void txtqty_TextChanged(object sender, EventArgs e)
        {
            try
            {
            string query = "SELECT productid,brand,description,sellingprice from tblstock where barcode = '" + txtBarCodeSearch.Text + "' ";
            DataTable tempdt = new DataTable();
            MySqlConnection sqlConn = new MySqlConnection(connectionString);
            sqlConn.Open();
            MySqlCommand cmd = new MySqlCommand(query, sqlConn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            
            da.Fill(tempdt);
            sqlConn.Close();

            int pid = Convert.ToInt32(tempdt.Rows[0]["productid"]);
                string brand = tempdt.Rows[0]["brand"].ToString();
                string des = tempdt.Rows[0]["description"].ToString();
                decimal sp = Convert.ToDecimal(tempdt.Rows[0]["sellingprice"]);
                int qty = Convert.ToInt32(txtqty.Text);
                decimal tot = qty * sp;

                dt = (DataTable)ViewState["Details"];
                dt.Rows.Add(pid, brand, des, sp, qty, tot);
                ViewState["Details"] = dt;
                gvbillitem.DataSource = dt;
                gvbillitem.EmptyDataText = "Product ID";
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
            txtCustomerName.Text="";
            txtCustomerID.Text="";
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

                        txtPhoneSearch.Text="";
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
            decimal sum = ((100 - discount) * amount)/100;
            txtTotalAmount.Text = sum.ToString();
        }

        protected void txtRAmount_TextChanged(object sender, EventArgs e)
        {
            decimal total = decimal.Parse(txtTotalAmount.Text);
            decimal ramount = decimal.Parse(txtRAmount.Text);
            decimal sum = ramount-total;
            txtBalance.Text = sum.ToString();
        }
    }
}