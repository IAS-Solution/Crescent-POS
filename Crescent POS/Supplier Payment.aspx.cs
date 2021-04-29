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
    public partial class Supplier_Payment : System.Web.UI.Page
    {

        public static string connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        MySqlConnection con = new MySqlConnection(connectionString);
        DataTable dt = new DataTable();
        MySqlCommand cmd = new MySqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGRNID();
        }

        public void LoadGRNID()
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT grnid FROM tblgrn", con);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            ddlGRNID.DataSource = cmd.ExecuteReader();
            ddlGRNID.DataTextField = "grnid";
            ddlGRNID.DataValueField = "grnid";
            ddlGRNID.DataBind();
            con.Close();
                    
            ddlGRNID.Items.Insert(0, new ListItem("--Select GRN ID--", "0"));
            
        }

        protected void ddlGRNID_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT Cusid,customerName,amt from tblcustomer where grnid = '" + ddlGRNID.Text + "' ", con);
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    //txtCustomerName.Text = (dr["customerName"].ToString());
                    //txtCustomerID.Text = (dr["Cusid"].ToString());
                    //txtPreReceivable.Text = (dr["amt"].ToString());
                    //rdLoyalty.Checked = true;
                    

                }
            }
        }

       
    }
}