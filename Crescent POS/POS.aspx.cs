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

        protected void Page_Load(object sender, EventArgs e)
        {
            Showdate();
            //ShowTime();
            txtBarCodeSearch.Focus();
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

        protected void txtBarCodeSearch_TextChanged(object sender, EventArgs e)
        {

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
                    //MessageBox.Show(ex.Message);
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