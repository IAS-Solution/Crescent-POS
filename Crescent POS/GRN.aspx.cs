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

            GRNIDLoard();
            Showdate();
            LoadSupplierID();
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

        protected void txtQty_TextChanged(object sender, EventArgs e)
        {
            decimal val1 = decimal.Parse(txtCostPrice.Text);
            decimal val2 = decimal.Parse(txtQty.Text);
            decimal sum = val1 * val2;
            txtTotalPrice.Text = sum.ToString("#,#00.00");
        }

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
        public static string[] GetCompletionList_hotel(string prefixText, int count)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                string sql = String.Format("SELECT brand FROM grnproduct where brand like '{0}%'", prefixText);
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

    }
}